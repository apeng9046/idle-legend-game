using UnityEngine;
using System;

/// <summary>
/// 离线收益管理器
/// </summary>
public class OfflineEarningsManager : MonoBehaviour
{
    private const string LAST_LOGIN_KEY = "LastLoginTime";
    private const string OFFLINE_GOLD_KEY = "OfflineGold";
    private const string OFFLINE_EXP_KEY = "OfflineExp";
    private const int MAX_OFFLINE_HOURS = 8; // 最多计算8小时离线收益
    private const float GOLD_PER_SECOND = 10f; // 每秒获取的金币
    private const float EXP_PER_SECOND = 5f; // 每秒获取的经验

    /// <summary>
    /// 初始化离线收益系统
    /// </summary>
    public void Initialize()
    {
        Debug.Log("[OfflineEarningsManager] 离线收益系统已初始化");
    }

    /// <summary>
    /// 计算并应用离线收益
    /// </summary>
    public void CalculateAndApplyOfflineEarnings(PlayerData playerData)
    {
        // 获取上次登录时间
        string lastLoginTimeStr = PlayerPrefs.GetString(LAST_LOGIN_KEY, "");
        DateTime lastLoginTime = string.IsNullOrEmpty(lastLoginTimeStr) 
            ? DateTime.Now 
            : DateTime.Parse(lastLoginTimeStr);

        // 计算离线时长
        TimeSpan offlineDuration = DateTime.Now - lastLoginTime;
        double offlineHours = Math.Min(offlineDuration.TotalHours, MAX_OFFLINE_HOURS);
        double offlineSeconds = offlineHours * 3600;

        if (offlineSeconds > 0)
        {
            // 计算离线收益
            long offlineGold = (long)(offlineSeconds * GOLD_PER_SECOND);
            long offlineExp = (long)(offlineSeconds * EXP_PER_SECOND);

            // 应用倍数加成（可通过VIP等级增加）
            offlineGold = (long)(offlineGold * GetOfflineMultiplier(playerData));
            offlineExp = (long)(offlineExp * GetOfflineMultiplier(playerData));

            // 将收益添加到玩家
            playerData.AddGold(offlineGold);
            playerData.AddExp(offlineExp);

            // 保存离线收益到存档
            PlayerPrefs.SetString(OFFLINE_GOLD_KEY, offlineGold.ToString());
            PlayerPrefs.SetString(OFFLINE_EXP_KEY, offlineExp.ToString());

            Debug.Log($"[OfflineEarningsManager] 应用离线收益 - 金币:{offlineGold}, 经验:{offlineExp}");
        }

        // 更新登录时间
        UpdateLastLoginTime();
    }

    /// <summary>
    /// 更新上次登录时间
    /// </summary>
    public void UpdateLastLoginTime()
    {
        PlayerPrefs.SetString(LAST_LOGIN_KEY, DateTime.Now.ToString());
        PlayerPrefs.Save();
        Debug.Log("[OfflineEarningsManager] 登录时间已更新");
    }

    /// <summary>
    /// 获取离线倍数
    /// </summary>
    private float GetOfflineMultiplier(PlayerData playerData)
    {
        // 基础倍数1.0
        float multiplier = 1.0f;

        // 可根据VIP等级、道具加成等增加倍数
        // multiplier += vipLevel * 0.1f;
        // multiplier += activeBuff.multiplier;

        return multiplier;
    }

    /// <summary>
    /// 获取最近一次离线收益
    /// </summary>
    public void GetLastOfflineEarnings(out long lastGold, out long lastExp)
    {
        lastGold = long.Parse(PlayerPrefs.GetString(OFFLINE_GOLD_KEY, "0"));
        lastExp = long.Parse(PlayerPrefs.GetString(OFFLINE_EXP_KEY, "0"));
    }

    /// <summary>
    /// 获取离线时长
    /// </summary>
    public TimeSpan GetOfflineDuration()
    {
        string lastLoginTimeStr = PlayerPrefs.GetString(LAST_LOGIN_KEY, "");
        DateTime lastLoginTime = string.IsNullOrEmpty(lastLoginTimeStr) 
            ? DateTime.Now 
            : DateTime.Parse(lastLoginTimeStr);

        return DateTime.Now - lastLoginTime;
    }

    /// <summary>
    /// 预估离线收益
    /// </summary>
    public void EstimateOfflineEarnings(out long estimatedGold, out long estimatedExp)
    {
        TimeSpan offlineDuration = GetOfflineDuration();
        double offlineHours = Math.Min(offlineDuration.TotalHours, MAX_OFFLINE_HOURS);
        double offlineSeconds = offlineHours * 3600;

        estimatedGold = (long)(offlineSeconds * GOLD_PER_SECOND);
        estimatedExp = (long)(offlineSeconds * EXP_PER_SECOND);
    }

    /// <summary>
    /// 重置离线数据（用于测试）
    /// </summary>
    public void ResetOfflineData()
    {
        PlayerPrefs.DeleteKey(LAST_LOGIN_KEY);
        PlayerPrefs.DeleteKey(OFFLINE_GOLD_KEY);
        PlayerPrefs.DeleteKey(OFFLINE_EXP_KEY);
        PlayerPrefs.Save();
        Debug.Log("[OfflineEarningsManager] 离线数据已重置");
    }

    /// <summary>
    /// 设置离线收益速率（用于配置）
    /// </summary>
    public static void SetEarningsRate(float goldPerSecond, float expPerSecond)
    {
        // 注意: 这里应该使用配置系统而不是直接修改常量
        Debug.Log($"[OfflineEarningsManager] 设置收益速率 - 金币:{goldPerSecond}/秒, 经验:{expPerSecond}/秒");
    }

    /// <summary>
    /// 获取最大离线收益时限（小时）
    /// </summary>
    public static int GetMaxOfflineHours()
    {
        return MAX_OFFLINE_HOURS;
    }
}
