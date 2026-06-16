using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 英雄进阶数据
/// </summary>
[System.Serializable]
public class HeroAdvancementData
{
    public int heroId;
    public int level = 1; // 当前等级
    public long exp = 0; // 当前经验
    public int breakthrough = 0; // 突破次数 (0-10)
    public List<int> equippedSkills = new List<int>(); // 装备的技能
    public List<int> equippedEquipment = new List<int>(); // 装备的道具
    public int intimacy = 0; // 亲密度
    public bool isInTeam = false; // 是否在队伍中
}

/// <summary>
/// 英雄进阶系统
/// </summary>
public class HeroAdvancementSystem : MonoBehaviour
{
    private Dictionary<int, HeroAdvancementData> heroAdvancementData = new Dictionary<int, HeroAdvancementData>();
    private const int MAX_LEVEL = 100;
    private const int MAX_BREAKTHROUGH = 10;

    public void Initialize()
    {
        Debug.Log("[HeroAdvancementSystem] 英雄进阶系统已初始化");
    }

    /// <summary>
    /// 获取或创建英雄进阶数据
    /// </summary>
    public HeroAdvancementData GetOrCreateHeroData(int heroId)
    {
        if (!heroAdvancementData.ContainsKey(heroId))
        {
            heroAdvancementData[heroId] = new HeroAdvancementData { heroId = heroId };
        }
        return heroAdvancementData[heroId];
    }

    /// <summary>
    /// 给英雄增加经验
    /// </summary>
    public bool AddHeroExp(int heroId, long expAmount, PlayerData playerData)
    {
        var heroData = GetOrCreateHeroData(heroId);
        heroData.exp += expAmount;

        // 检查是否升级
        while (heroData.level < MAX_LEVEL && heroData.exp >= GetExpRequiredForLevel(heroData.level + 1))
        {
            heroData.exp -= GetExpRequiredForLevel(heroData.level + 1);
            heroData.level++;
            Debug.Log($"[HeroAdvancementSystem] 英雄{heroId}升级到 {heroData.level} 级");
        }

        return true;
    }

    /// <summary>
    /// 英雄突破
    /// </summary>
    public bool BreakthroughHero(int heroId, PlayerData playerData)
    {
        var heroData = GetOrCreateHeroData(heroId);

        // 检查突破条件
        if (heroData.breakthrough >= MAX_BREAKTHROUGH)
        {
            Debug.LogWarning("[HeroAdvancementSystem] 英雄已达到最大突破次数");
            return false;
        }

        int requiredLevel = 20 + (heroData.breakthrough * 10);
        if (heroData.level < requiredLevel)
        {
            Debug.LogWarning($"[HeroAdvancementSystem] 英雄等级不足，需要 {requiredLevel} 级");
            return false;
        }

        // 消耗资源
        long goldCost = (long)(1000 * Mathf.Pow(2, heroData.breakthrough));
        if (playerData.GetGold() < goldCost)
        {
            Debug.LogWarning("[HeroAdvancementSystem] 金币不足");
            return false;
        }

        // 进行突破
        playerData.AddGold(-goldCost);
        heroData.breakthrough++;
        heroData.level = Mathf.Max(heroData.level, 20 + (heroData.breakthrough * 10));

        Debug.Log($"[HeroAdvancementSystem] 英雄{heroId}突破成功，当前突破数: {heroData.breakthrough}");
        return true;
    }

    /// <summary>
    /// 装备技能
    /// </summary>
    public bool EquipSkill(int heroId, int skillId)
    {
        var heroData = GetOrCreateHeroData(heroId);
        
        if (heroData.equippedSkills.Count >= 3)
        {
            Debug.LogWarning("[HeroAdvancementSystem] 最多只能装备3个技能");
            return false;
        }

        if (!heroData.equippedSkills.Contains(skillId))
        {
            heroData.equippedSkills.Add(skillId);
            Debug.Log($"[HeroAdvancementSystem] 英雄{heroId}装备技能{skillId}");
            return true;
        }

        return false;
    }

    /// <summary>
    /// 卸下技能
    /// </summary>
    public bool UnequipSkill(int heroId, int skillId)
    {
        var heroData = GetOrCreateHeroData(heroId);
        if (heroData.equippedSkills.Remove(skillId))
        {
            Debug.Log($"[HeroAdvancementSystem] 英雄{heroId}卸下技能{skillId}");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 装备道具
    /// </summary>
    public bool EquipItem(int heroId, int itemId)
    {
        var heroData = GetOrCreateHeroData(heroId);
        
        if (heroData.equippedEquipment.Count >= 5)
        {
            Debug.LogWarning("[HeroAdvancementSystem] 最多只能装备5件道具");
            return false;
        }

        if (!heroData.equippedEquipment.Contains(itemId))
        {
            heroData.equippedEquipment.Add(itemId);
            Debug.Log($"[HeroAdvancementSystem] 英雄{heroId}装备道具{itemId}");
            return true;
        }

        return false;
    }

    /// <summary>
    /// 获取升级所需经验
    /// </summary>
    private long GetExpRequiredForLevel(int level)
    {
        return (long)(100 * Mathf.Pow(1.1f, level - 1));
    }

    /// <summary>
    /// 计算英雄属性加成
    /// </summary>
    public float CalculateAttributeBonus(int heroId, string attributeType)
    {
        var heroData = GetOrCreateHeroData(heroId);
        float bonus = 1.0f;

        // 等级加成
        bonus += (heroData.level - 1) * 0.01f;

        // 突破加成
        bonus += heroData.breakthrough * 0.05f;

        // 亲密度加成
        bonus += heroData.intimacy * 0.001f;

        return bonus;
    }

    /// <summary>
    /// 获取英雄数据
    /// </summary>
    public HeroAdvancementData GetHeroData(int heroId)
    {
        if (heroAdvancementData.TryGetValue(heroId, out var data))
        {
            return data;
        }
        return GetOrCreateHeroData(heroId);
    }

    /// <summary>
    /// 获取所有英雄数据
    /// </summary>
    public Dictionary<int, HeroAdvancementData> GetAllHeroData()
    {
        return new Dictionary<int, HeroAdvancementData>(heroAdvancementData);
    }
}
