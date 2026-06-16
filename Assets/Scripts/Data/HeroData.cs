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
    /// 生成所有英雄数据
    /// </summary>
    private static void GenerateHeroes()
    {
        // 女性英雄示例
        var heroes = new List<HeroData>
        {
            new HeroData
            {
                heroId = 1,
                heroName = "云雾仙子",
                description = "掌控风属性的古代仙女",
                rarity = 5,
                baseAttack = 100,
                baseDefense = 50,
                baseHp = 200,
                isFemale = true,
                modelPath = "Models/Heroes/Heroine_01"
            },
            new HeroData
            {
                heroId = 2,
                heroName = "月华公主",
                description = "月光之下的优雅战士",
                rarity = 5,
                baseAttack = 110,
                baseDefense = 45,
                baseHp = 180,
                isFemale = true,
                modelPath = "Models/Heroes/Heroine_02"
            },
            new HeroData
            {
                heroId = 3,
                heroName = "火焰女王",
                description = "炽热火焰的掌控者",
                rarity = 4,
                baseAttack = 120,
                baseDefense = 40,
                baseHp = 160,
                isFemale = true,
                modelPath = "Models/Heroes/Heroine_03"
            }
        };

        foreach (var hero in heroes)
        {
            heroDatabase[hero.heroId] = hero;
        }

        Debug.Log($"[HeroConfig] 已加载 {heroDatabase.Count} 个英雄");
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
}
