using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 玩家社交数据
/// </summary>
[System.Serializable]
public class PlayerProfile
{
    public string playerId;
    public string playerName;
    public int level;
    public long totalPower; // 总战力
    public string guildName;
    public int ranking; // 排行榜排名
    public List<string> friendIds = new List<string>();
    public string signature; // 个性签名
}

/// <summary>
/// 公会数据
/// </summary>
[System.Serializable]
public class GuildData
{
    public string guildId;
    public string guildName;
    public string guildLeader;
    public int memberCount;
    public int level;
    public string description;
    public long guildFund; // 公会资金
    public List<string> members = new List<string>();
}

/// <summary>
/// 社交系统
/// </summary>
public class SocialSystem : MonoBehaviour
{
    private PlayerProfile playerProfile;
    private List<PlayerProfile> friendsList = new List<PlayerProfile>();
    private GuildData currentGuild;
    private List<PlayerProfile> rankings = new List<PlayerProfile>();
    private const int MAX_FRIENDS = 50;
    private const int RANKING_DISPLAY_COUNT = 100;

    public void Initialize()
    {
        InitializePlayerProfile();
        Debug.Log("[SocialSystem] 社交系统已初始化");
    }

    /// <summary>
    /// 初始化玩家档案
    /// </summary>
    private void InitializePlayerProfile()
    {
        playerProfile = new PlayerProfile
        {
            playerId = System.Guid.NewGuid().ToString(),
            playerName = "山海冒险者",
            level = 1,
            totalPower = 0,
            guildName = "无",
            ranking = 99999,
            signature = "欢迎来到山海传奇！"
        };
    }

    /// <summary>
    /// 添加好友
    /// </summary>
    public bool AddFriend(string friendPlayerId, PlayerProfile friendProfile)
    {
        if (friendsList.Count >= MAX_FRIENDS)
        {
            Debug.LogWarning("[SocialSystem] 好友列表已满");
            return false;
        }

        if (playerProfile.friendIds.Contains(friendPlayerId))
        {
            Debug.LogWarning("[SocialSystem] 该玩家已是好友");
            return false;
        }

        playerProfile.friendIds.Add(friendPlayerId);
        friendsList.Add(friendProfile);
        Debug.Log($"[SocialSystem] 添加好友: {friendProfile.playerName}");
        return true;
    }

    /// <summary>
    /// 移除好友
    /// </summary>
    public bool RemoveFriend(string friendPlayerId)
    {
        if (playerProfile.friendIds.Remove(friendPlayerId))
        {
            friendsList.RemoveAll(f => f.playerId == friendPlayerId);
            Debug.Log("[SocialSystem] 已移除好友");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获取好友列表
    /// </summary>
    public List<PlayerProfile> GetFriendsList()
    {
        return new List<PlayerProfile>(friendsList);
    }

    /// <summary>
    /// 创建公会
    /// </summary>
    public bool CreateGuild(string guildName, string description)
    {
        if (currentGuild != null)
        {
            Debug.LogWarning("[SocialSystem] 已在公会中");
            return false;
        }

        currentGuild = new GuildData
        {
            guildId = System.Guid.NewGuid().ToString(),
            guildName = guildName,
            guildLeader = playerProfile.playerId,
            memberCount = 1,
            level = 1,
            description = description,
            guildFund = 0
        };
        currentGuild.members.Add(playerProfile.playerId);

        playerProfile.guildName = guildName;
        Debug.Log($"[SocialSystem] 创建公会: {guildName}");
        return true;
    }

    /// <summary>
    /// 申请加入公会
    /// </summary>
    public bool JoinGuild(GuildData guild)
    {
        if (currentGuild != null)
        {
            Debug.LogWarning("[SocialSystem] 已在公会中");
            return false;
        }

        if (guild.members.Count >= 50)
        {
            Debug.LogWarning("[SocialSystem] 公会成员已满");
            return false;
        }

        currentGuild = guild;
        guild.members.Add(playerProfile.playerId);
        guild.memberCount = guild.members.Count;
        playerProfile.guildName = guild.guildName;

        Debug.Log($"[SocialSystem] 加入公会: {guild.guildName}");
        return true;
    }

    /// <summary>
    /// 退出公会
    /// </summary>
    public bool LeaveGuild()
    {
        if (currentGuild == null)
        {
            Debug.LogWarning("[SocialSystem] 未加入公会");
            return false;
        }

        // 如果是会长，无法退出
        if (currentGuild.guildLeader == playerProfile.playerId)
        {
            Debug.LogWarning("[SocialSystem] 会长无法退出公会");
            return false;
        }

        currentGuild.members.Remove(playerProfile.playerId);
        currentGuild.memberCount = currentGuild.members.Count;
        string guildName = currentGuild.guildName;
        currentGuild = null;
        playerProfile.guildName = "无";

        Debug.Log($"[SocialSystem] 退出公会: {guildName}");
        return true;
    }

    /// <summary>
    /// 获取当前公会
    /// </summary>
    public GuildData GetCurrentGuild()
    {
        return currentGuild;
    }

    /// <summary>
    /// 更新排行榜
    /// </summary>
    public void UpdateRanking(List<PlayerProfile> allPlayers)
    {
        rankings = new List<PlayerProfile>(allPlayers);
        rankings.Sort((a, b) => b.totalPower.CompareTo(a.totalPower));

        // 更新自己的排名
        for (int i = 0; i < rankings.Count; i++)
        {
            rankings[i].ranking = i + 1;
            if (rankings[i].playerId == playerProfile.playerId)
            {
                playerProfile.ranking = i + 1;
            }
        }

        Debug.Log($"[SocialSystem] 排行榜已更新，您的排名: {playerProfile.ranking}");
    }

    /// <summary>
    /// 获取排行榜
    /// </summary>
    public List<PlayerProfile> GetRankings(int count = RANKING_DISPLAY_COUNT)
    {
        return rankings.GetRange(0, Mathf.Min(count, rankings.Count));
    }

    /// <summary>
    /// 获取玩家档案
    /// </summary>
    public PlayerProfile GetPlayerProfile()
    {
        return playerProfile;
    }

    /// <summary>
    /// 更新玩家档案
    /// </summary>
    public void UpdatePlayerProfile(PlayerData playerData)
    {
        playerProfile.level = playerData.GetLevel();
        // 计算总战力（可根据英雄、装备、等级等计算）
        playerProfile.totalPower = playerData.GetGold() / 100; // 简化计算
    }

    /// <summary>
    /// 修改个性签名
    /// </summary>
    public void SetSignature(string signature)
    {
        playerProfile.signature = signature;
        Debug.Log($"[SocialSystem] 个性签名已更新: {signature}");
    }

    /// <summary>
    /// 获取公会成员列表
    /// </summary>
    public List<string> GetGuildMembers()
    {
        if (currentGuild == null)
            return new List<string>();
        return new List<string>(currentGuild.members);
    }
}
