using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 英雄数据定义
/// </summary>
[System.Serializable]
public class HeroData
{
    public int heroId;
    public string heroName;
    public string description;
    public int rarity; // 1-5 星
    public int baseAttack;
    public int baseDefense;
    public int baseHp;
    public List<int> skills = new List<int>();
    public string modelPath;
    public string portraitPath;
    public bool isFemale;
    public string element; // 属性: 风、火、水、雷、土
    public int recruitmentCost; // 招募消耗
}

/// <summary>
/// 英雄配置管理
/// </summary>
public class HeroConfig : MonoBehaviour
{
    private static Dictionary<int, HeroData> heroDatabase = new Dictionary<int, HeroData>();

    public static void Initialize()
    {
        GenerateHeroes();
    }

    /// <summary>
    /// 生成所有英雄数据 - 30+个美女角色
    /// </summary>
    private static void GenerateHeroes()
    {
        var heroes = new List<HeroData>
        {
            // 5星 - 极品传说
            new HeroData
            {
                heroId = 1,
                heroName = "云雾仙子",
                description = "掌控风属性的古代仙女，能释放致命的风刃攻击",
                rarity = 5,
                baseAttack = 120,
                baseDefense = 60,
                baseHp = 250,
                element = "风",
                isFemale = true,
                skills = new List<int> { 101, 102, 103 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_CloudMist"
            },
            new HeroData
            {
                heroId = 2,
                heroName = "月华公主",
                description = "月光之下的优雅战士，掌控冰冷的月华力量",
                rarity = 5,
                baseAttack = 110,
                baseDefense = 65,
                baseHp = 220,
                element = "水",
                isFemale = true,
                skills = new List<int> { 104, 105, 106 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_MoonPrincess"
            },
            new HeroData
            {
                heroId = 3,
                heroName = "火焰女王",
                description = "炽热火焰的掌控者，释放毁灭性的火属性魔法",
                rarity = 5,
                baseAttack = 130,
                baseDefense = 50,
                baseHp = 200,
                element = "火",
                isFemale = true,
                skills = new List<int> { 107, 108, 109 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_FireQueen"
            },
            new HeroData
            {
                heroId = 4,
                heroName = "雷鸣仙后",
                description = "掌控雷电之力的古代仙后，能引发天罚之雷",
                rarity = 5,
                baseAttack = 125,
                baseDefense = 55,
                baseHp = 210,
                element = "雷",
                isFemale = true,
                skills = new List<int> { 110, 111, 112 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_ThunderImmortals"
            },
            new HeroData
            {
                heroId = 5,
                heroName = "地母娘娘",
                description = "大地之力的化身，能驾驭山石大地之力",
                rarity = 5,
                baseAttack = 100,
                baseDefense = 80,
                baseHp = 300,
                element = "土",
                isFemale = true,
                skills = new List<int> { 113, 114, 115 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_EarthGoddess"
            },

            // 4星 - 稀有精英
            new HeroData
            {
                heroId = 6,
                heroName = "青丝剑客",
                description = "剑术高超的江湖女侠，以速度见长",
                rarity = 4,
                baseAttack = 115,
                baseDefense = 45,
                baseHp = 180,
                element = "风",
                isFemale = true,
                skills = new List<int> { 116, 117 },
                recruitmentCost = 2000,
                modelPath = "Models/Heroes/Heroine_SwordMaster"
            },
            new HeroData
            {
                heroId = 7,
                heroName = "冰晶法师",
                description = "冰系魔法大师，能冻结一切敌人",
                rarity = 4,
                baseAttack = 105,
                baseDefense = 55,
                baseHp = 190,
                element = "水",
                isFemale = true,
                skills = new List<int> { 118, 119 },
                recruitmentCost = 2000,
                modelPath = "Models/Heroes/Heroine_IceMage"
            },
            new HeroData
            {
                heroId = 8,
                heroName = "炎舞绮姬",
                description = "火舞绝伦的炎系战士，融合舞蹈与火焰",
                rarity = 4,
                baseAttack = 120,
                baseDefense = 40,
                baseHp = 170,
                element = "火",
                isFemale = true,
                skills = new List<int> { 120, 121 },
                recruitmentCost = 2000,
                modelPath = "Models/Heroes/Heroine_FlameWarrior"
            },
            new HeroData
            {
                heroId = 9,
                heroName = "雷电骑士",
                description = "雷属性骑士，挥舞闪电之剑",
                rarity = 4,
                baseAttack = 118,
                baseDefense = 50,
                baseHp = 185,
                element = "雷",
                isFemale = true,
                skills = new List<int> { 122, 123 },
                recruitmentCost = 2000,
                modelPath = "Models/Heroes/Heroine_LightningKnight"
            },
            new HeroData
            {
                heroId = 10,
                heroName = "盾牌守护者",
                description = "土系防御高手，是队伍的坚实防线",
                rarity = 4,
                baseAttack = 85,
                baseDefense = 90,
                baseHp = 280,
                element = "土",
                isFemale = true,
                skills = new List<int> { 124, 125 },
                recruitmentCost = 2000,
                modelPath = "Models/Heroes/Heroine_ShieldGuard"
            },

            // 3星 - 常见稀有
            new HeroData
            {
                heroId = 11,
                heroName = "风之精灵",
                description = "轻盈的风系精灵，擅长闪避和输出",
                rarity = 3,
                baseAttack = 100,
                baseDefense = 35,
                baseHp = 150,
                element = "风",
                isFemale = true,
                skills = new List<int> { 126 },
                recruitmentCost = 800,
                modelPath = "Models/Heroes/Heroine_WindSprite"
            },
            new HeroData
            {
                heroId = 12,
                heroName = "水之妖姬",
                description = "水系妖怪，灵活多变的攻击方式",
                rarity = 3,
                baseAttack = 95,
                baseDefense = 40,
                baseHp = 160,
                element = "水",
                isFemale = true,
                skills = new List<int> { 127 },
                recruitmentCost = 800,
                modelPath = "Models/Heroes/Heroine_WaterFairy"
            },
            new HeroData
            {
                heroId = 13,
                heroName = "熔岩战女",
                description = "火系战士，力量型输出角色",
                rarity = 3,
                baseAttack = 110,
                baseDefense = 30,
                baseHp = 140,
                element = "火",
                isFemale = true,
                skills = new List<int> { 128 },
                recruitmentCost = 800,
                modelPath = "Models/Heroes/Heroine_LavaWarrior"
            },
            new HeroData
            {
                heroId = 14,
                heroName = "闪电法术师",
                description = "雷系法师，快速释放强力法术",
                rarity = 3,
                baseAttack = 108,
                baseDefense = 38,
                baseHp = 155,
                element = "雷",
                isFemale = true,
                skills = new List<int> { 129 },
                recruitmentCost = 800,
                modelPath = "Models/Heroes/Heroine_LightningMage"
            },
            new HeroData
            {
                heroId = 15,
                heroName = "岩石保护者",
                description = "土系防御专家，防护能力强",
                rarity = 3,
                baseAttack = 80,
                baseDefense = 70,
                baseHp = 220,
                element = "土",
                isFemale = true,
                skills = new List<int> { 130 },
                recruitmentCost = 800,
                modelPath = "Models/Heroes/Heroine_RockProtector"
            },

            // 2星 - 普通英雄
            new HeroData
            {
                heroId = 16,
                heroName = "初生仙女",
                description = "初级风系仙女，适合新手",
                rarity = 2,
                baseAttack = 70,
                baseDefense = 25,
                baseHp = 120,
                element = "风",
                isFemale = true,
                skills = new List<int> { 131 },
                recruitmentCost = 300,
                modelPath = "Models/Heroes/Heroine_Novice_Wind"
            },
            new HeroData
            {
                heroId = 17,
                heroName = "泉水精灵",
                description = "初级水系精灵，回复能力不错",
                rarity = 2,
                baseAttack = 60,
                baseDefense = 35,
                baseHp = 140,
                element = "水",
                isFemale = true,
                skills = new List<int> { 132 },
                recruitmentCost = 300,
                modelPath = "Models/Heroes/Heroine_Novice_Water"
            },
            new HeroData
            {
                heroId = 18,
                heroName = "烈焰小姐",
                description = "初级火系战士，伤害可观",
                rarity = 2,
                baseAttack = 80,
                baseDefense = 20,
                baseHp = 110,
                element = "火",
                isFemale = true,
                skills = new List<int> { 133 },
                recruitmentCost = 300,
                modelPath = "Models/Heroes/Heroine_Novice_Fire"
            },
            new HeroData
            {
                heroId = 19,
                heroName = "电光少女",
                description = "初级雷系少女，速度型输出",
                rarity = 2,
                baseAttack = 75,
                baseDefense = 28,
                baseHp = 115,
                element = "雷",
                isFemale = true,
                skills = new List<int> { 134 },
                recruitmentCost = 300,
                modelPath = "Models/Heroes/Heroine_Novice_Thunder"
            },
            new HeroData
            {
                heroId = 20,
                heroName = "石墙卫士",
                description = "初级土系卫士，防御坚硬",
                rarity = 2,
                baseAttack = 55,
                baseDefense = 50,
                baseHp = 180,
                element = "土",
                isFemale = true,
                skills = new List<int> { 135 },
                recruitmentCost = 300,
                modelPath = "Models/Heroes/Heroine_Novice_Earth"
            },

            // 1星 - 基础角色
            new HeroData
            {
                heroId = 21,
                heroName = "风之少女",
                description = "最初的风系角色，适合开局",
                rarity = 1,
                baseAttack = 50,
                baseDefense = 15,
                baseHp = 100,
                element = "风",
                isFemale = true,
                skills = new List<int> { 136 },
                recruitmentCost = 100,
                modelPath = "Models/Heroes/Heroine_Basic_Wind"
            },
            new HeroData
            {
                heroId = 22,
                heroName = "水之精怪",
                description = "最初的水系角色，生命力强",
                rarity = 1,
                baseAttack = 40,
                baseDefense = 20,
                baseHp = 120,
                element = "水",
                isFemale = true,
                skills = new List<int> { 137 },
                recruitmentCost = 100,
                modelPath = "Models/Heroes/Heroine_Basic_Water"
            },
            new HeroData
            {
                heroId = 23,
                heroName = "火焰姐妹",
                description = "最初的火系角色，输出稳定",
                rarity = 1,
                baseAttack = 60,
                baseDefense = 10,
                baseHp = 90,
                element = "火",
                isFemale = true,
                skills = new List<int> { 138 },
                recruitmentCost = 100,
                modelPath = "Models/Heroes/Heroine_Basic_Fire"
            },
            new HeroData
            {
                heroId = 24,
                heroName = "雷鸣小妖",
                description = "最初的雷系角色，速度快",
                rarity = 1,
                baseAttack = 55,
                baseDefense = 12,
                baseHp = 95,
                element = "雷",
                isFemale = true,
                skills = new List<int> { 139 },
                recruitmentCost = 100,
                modelPath = "Models/Heroes/Heroine_Basic_Thunder"
            },
            new HeroData
            {
                heroId = 25,
                heroName = "泥土怪物",
                description = "最初的土系角色，防御强悍",
                rarity = 1,
                baseAttack = 35,
                baseDefense = 40,
                baseHp = 150,
                element = "土",
                isFemale = true,
                skills = new List<int> { 140 },
                recruitmentCost = 100,
                modelPath = "Models/Heroes/Heroine_Basic_Earth"
            },

            // 额外稀有角色
            new HeroData
            {
                heroId = 26,
                heroName = "星月魔女",
                description = "神秘的星月魔女，魔法伤害超群",
                rarity = 5,
                baseAttack = 135,
                baseDefense = 45,
                baseHp = 200,
                element = "风",
                isFemale = true,
                skills = new List<int> { 141, 142, 143 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_StarWitch"
            },
            new HeroData
            {
                heroId = 27,
                heroName = "深海冰后",
                description = "深海之力的统治者，冰系魔法最强",
                rarity = 5,
                baseAttack = 115,
                baseDefense = 70,
                baseHp = 240,
                element = "水",
                isFemale = true,
                skills = new List<int> { 144, 145, 146 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_DeepSeaIce"
            },
            new HeroData
            {
                heroId = 28,
                heroName = "炎帝之女",
                description = "炎帝的女儿，掌控最高等级的火焰",
                rarity = 5,
                baseAttack = 140,
                baseDefense = 48,
                baseHp = 190,
                element = "火",
                isFemale = true,
                skills = new List<int> { 147, 148, 149 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_FireEmperor"
            },
            new HeroData
            {
                heroId = 29,
                heroName = "天雷圣女",
                description = "天雷降临的圣女，雷系最强者",
                rarity = 5,
                baseAttack = 130,
                baseDefense = 52,
                baseHp = 205,
                element = "雷",
                isFemale = true,
                skills = new List<int> { 150, 151, 152 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_ThunderSaint"
            },
            new HeroData
            {
                heroId = 30,
                heroName = "大地祖母",
                description = "大地的祖母，土系防御无敌",
                rarity = 5,
                baseAttack = 95,
                baseDefense = 100,
                baseHp = 350,
                element = "土",
                isFemale = true,
                skills = new List<int> { 153, 154, 155 },
                recruitmentCost = 5000,
                modelPath = "Models/Heroes/Heroine_EarthAncestress"
            }
        };

        foreach (var hero in heroes)
        {
            heroDatabase[hero.heroId] = hero;
        }

        Debug.Log($"[HeroConfig] 已加载 {heroDatabase.Count} 个英雄角色");
    }

    /// <summary>
    /// 获取英雄数据
    /// </summary>
    public static HeroData GetHeroData(int heroId)
    {
        if (heroDatabase.TryGetValue(heroId, out var hero))
        {
            return hero;
        }
        return null;
    }

    /// <summary>
    /// 获取所有英雄
    /// </summary>
    public static List<HeroData> GetAllHeroes()
    {
        return new List<HeroData>(heroDatabase.Values);
    }

    /// <summary>
    /// 获取特定稀有度的英雄
    /// </summary>
    public static List<HeroData> GetHeroesByRarity(int rarity)
    {
        var result = new List<HeroData>();
        foreach (var hero in heroDatabase.Values)
        {
            if (hero.rarity == rarity)
            {
                result.Add(hero);
            }
        }
        return result;
    }

    /// <summary>
    /// 获取特定属性的英雄
    /// </summary>
    public static List<HeroData> GetHeroesByElement(string element)
    {
        var result = new List<HeroData>();
        foreach (var hero in heroDatabase.Values)
        {
            if (hero.element == element)
            {
                result.Add(hero);
            }
        }
        return result;
    }

    /// <summary>
    /// 获取女性英雄数量
    /// </summary>
    public static int GetFemaleHeroCount()
    {
        int count = 0;
        foreach (var hero in heroDatabase.Values)
        {
            if (hero.isFemale)
                count++;
        }
        return count;
    }
}
