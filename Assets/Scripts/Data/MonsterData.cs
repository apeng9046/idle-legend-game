using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 怪物/神兽数据定义
/// </summary>
[System.Serializable]
public class MonsterData
{
    public int monsterId;
    public string monsterName;
    public string description;
    public string chineseOrigin; // 山海经出处
    public int baseAttack;
    public int baseDefense;
    public int baseHp;
    public List<int> skills = new List<int>();
    public string modelPath;
    public long goldReward;
    public long expReward;
}

/// <summary>
/// 怪物配置管理
/// </summary>
public class MonsterConfig : MonoBehaviour
{
    private static Dictionary<int, MonsterData> monsterDatabase = new Dictionary<int, MonsterData>();

    public static void Initialize()
    {
        GenerateMonsters();
    }

    /// <summary>
    /// 生成所有怪物数据
    /// </summary>
    private static void GenerateMonsters()
    {
        // 山海经神兽示例
        var monsters = new List<MonsterData>
        {
            new MonsterData
            {
                monsterId = 1,
                monsterName = "青龙",
                description = "东方守护神兽",
                chineseOrigin = "山海经·东方",
                baseAttack = 50,
                baseDefense = 30,
                baseHp = 150,
                modelPath = "Models/Monsters/Dragon_Blue",
                goldReward = 100,
                expReward = 50
            },
            new MonsterData
            {
                monsterId = 2,
                monsterName = "白虎",
                description = "西方凶兽",
                chineseOrigin = "山海经·西方",
                baseAttack = 60,
                baseDefense = 25,
                baseHp = 120,
                modelPath = "Models/Monsters/Tiger_White",
                goldReward = 120,
                expReward = 60
            },
            new MonsterData
            {
                monsterId = 3,
                monsterName = "朱雀",
                description = "南方火鸟",
                chineseOrigin = "山海经·南方",
                baseAttack = 70,
                baseDefense = 20,
                baseHp = 100,
                modelPath = "Models/Monsters/Phoenix_Red",
                goldReward = 140,
                expReward = 70
            },
            new MonsterData
            {
                monsterId = 4,
                monsterName = "玄武",
                description = "北方冰兽",
                chineseOrigin = "山海经·北方",
                baseAttack = 40,
                baseDefense = 50,
                baseHp = 200,
                modelPath = "Models/Monsters/Tortoise_Black",
                goldReward = 110,
                expReward = 55
            },
            new MonsterData
            {
                monsterId = 5,
                monsterName = "麒麟",
                description = "中央仁兽",
                chineseOrigin = "山海经·中央",
                baseAttack = 80,
                baseDefense = 40,
                baseHp = 180,
                modelPath = "Models/Monsters/Qilin_Gold",
                goldReward = 200,
                expReward = 100
            }
        };

        foreach (var monster in monsters)
        {
            monsterDatabase[monster.monsterId] = monster;
        }

        Debug.Log($"[MonsterConfig] 已加载 {monsterDatabase.Count} 个怪物");
    }

    /// <summary>
    /// 获取怪物数据
    /// </summary>
    public static MonsterData GetMonsterData(int monsterId)
    {
        if (monsterDatabase.TryGetValue(monsterId, out var monster))
        {
            return monster;
        }
        return null;
    }

    /// <summary>
    /// 获取所有怪物
    /// </summary>
    public static List<MonsterData> GetAllMonsters()
    {
        return new List<MonsterData>(monsterDatabase.Values);
    }
}
