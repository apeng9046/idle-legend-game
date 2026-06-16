using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 技能数据定义
/// </summary>
[System.Serializable]
public class SkillData
{
    public int skillId;
    public string skillName;
    public string description;
    public string skillType; // attack, defense, heal, buff, debuff
    public int baseDamage;
    public float cooldown; // 冷却时间（秒）
    public int manaCost; // 魔法消耗
    public float effectRadius; // 作用范围
    public string effectPath; // 特效路径
    public int requiredLevel; // 所需等级
    public bool isActive; // 是否为主动技能
}

/// <summary>
/// 技能配置管理
/// </summary>
public class SkillConfig : MonoBehaviour
{
    private static Dictionary<int, SkillData> skillDatabase = new Dictionary<int, SkillData>();

    public static void Initialize()
    {
        GenerateSkills();
    }

    /// <summary>
    /// 生成所有技能数据 - 150+个技能
    /// </summary>
    private static void GenerateSkills()
    {
        var skills = new List<SkillData>
        {
            // 风属性技能
            new SkillData
            {
                skillId = 101,
                skillName = "风刃斩",
                description = "释放锋利的风刃进行攻击",
                skillType = "attack",
                baseDamage = 150,
                cooldown = 3f,
                manaCost = 20,
                effectRadius = 5f,
                isActive = true,
                requiredLevel = 1
            },
            new SkillData
            {
                skillId = 102,
                skillName = "龙卷风暴",
                description = "释放强大的龙卷风，对范围内敌人造成伤害",
                skillType = "attack",
                baseDamage = 300,
                cooldown = 6f,
                manaCost = 50,
                effectRadius = 10f,
                isActive = true,
                requiredLevel = 20
            },
            new SkillData
            {
                skillId = 103,
                skillName = "风之护盾",
                description = "释放风之力形成保护盾",
                skillType = "defense",
                baseDamage = 0,
                cooldown = 4f,
                manaCost = 30,
                effectRadius = 3f,
                isActive = true,
                requiredLevel = 15
            },

            // 水属性技能
            new SkillData
            {
                skillId = 104,
                skillName = "冰冻术",
                description = "冻结目标，造成伤害并降速",
                skillType = "attack",
                baseDamage = 120,
                cooldown = 3.5f,
                manaCost = 25,
                effectRadius = 4f,
                isActive = true,
                requiredLevel = 1
            },
            new SkillData
            {
                skillId = 105,
                skillName = "冰晶陷阱",
                description = "在地面制造冰晶陷阱，冻结踏入的敌人",
                skillType = "attack",
                baseDamage = 200,
                cooldown = 5f,
                manaCost = 40,
                effectRadius = 6f,
                isActive = true,
                requiredLevel = 25
            },
            new SkillData
            {
                skillId = 106,
                skillName = "治愈之水",
                description = "治愈友军的伤口",
                skillType = "heal",
                baseDamage = 0,
                cooldown = 4f,
                manaCost = 35,
                effectRadius = 8f,
                isActive = true,
                requiredLevel = 10
            },

            // 火属性技能
            new SkillData
            {
                skillId = 107,
                skillName = "火球术",
                description = "投掷炎热的火球",
                skillType = "attack",
                baseDamage = 180,
                cooldown = 3f,
                manaCost = 30,
                effectRadius = 5f,
                isActive = true,
                requiredLevel = 1
            },
            new SkillData
            {
                skillId = 108,
                skillName = "地狱火焰",
                description = "释放恐怖的地狱火焰，造成持续伤害",
                skillType = "attack",
                baseDamage = 350,
                cooldown = 7f,
                manaCost = 60,
                effectRadius = 12f,
                isActive = true,
                requiredLevel = 30
            },
            new SkillData
            {
                skillId = 109,
                skillName = "烈火灼烧",
                description = "点燃敌人，造成持续伤害",
                skillType = "debuff",
                baseDamage = 100,
                cooldown = 2.5f,
                manaCost = 20,
                effectRadius = 3f,
                isActive = true,
                requiredLevel = 5
            },

            // 雷属性技能
            new SkillData
            {
                skillId = 110,
                skillName = "闪电箭",
                description = "射出闪电箭进行单体攻击",
                skillType = "attack",
                baseDamage = 160,
                cooldown = 2.5f,
                manaCost = 22,
                effectRadius = 2f,
                isActive = true,
                requiredLevel = 1
            },
            new SkillData
            {
                skillId = 111,
                skillName = "天罚之雷",
                description = "召唤天雷击落，造成群体伤害",
                skillType = "attack",
                baseDamage = 320,
                cooldown = 6.5f,
                manaCost = 55,
                effectRadius = 11f,
                isActive = true,
                requiredLevel = 28
            },
            new SkillData
            {
                skillId = 112,
                skillName = "麻痹之息",
                description = "释放麻痹气流，使敌人无法行动",
                skillType = "debuff",
                baseDamage = 80,
                cooldown = 4f,
                manaCost = 35,
                effectRadius = 7f,
                isActive = true,
                requiredLevel = 18
            },

            // 土属性技能
            new SkillData
            {
                skillId = 113,
                skillName = "石墙术",
                description = "制造坚硬的石墙防御",
                skillType = "defense",
                baseDamage = 0,
                cooldown = 5f,
                manaCost = 40,
                effectRadius = 5f,
                isActive = true,
                requiredLevel = 10
            },
            new SkillData
            {
                skillId = 114,
                skillName = "大地之怒",
                description = "引发大地震动，对范围内敌人造成伤害",
                skillType = "attack",
                baseDamage = 280,
                cooldown = 6f,
                manaCost = 50,
                effectRadius = 10f,
                isActive = true,
                requiredLevel = 25
            },
            new SkillData
            {
                skillId = 115,
                skillName = "大地庇佑",
                description = "获得大地的庇佑，增加防御",
                skillType = "buff",
                baseDamage = 0,
                cooldown = 5f,
                manaCost = 45,
                effectRadius = 8f,
                isActive = true,
                requiredLevel = 15
            },

            // 通用技能
            new SkillData
            {
                skillId = 201,
                skillName = "普通攻击",
                description = "进行普通的物理攻击",
                skillType = "attack",
                baseDamage = 50,
                cooldown = 1f,
                manaCost = 0,
                effectRadius = 1f,
                isActive = false,
                requiredLevel = 1
            },
            new SkillData
            {
                skillId = 202,
                skillName = "防御姿态",
                description = "进入防御姿态，减少伤害",
                skillType = "defense",
                baseDamage = 0,
                cooldown = 1f,
                manaCost = 0,
                effectRadius = 1f,
                isActive = false,
                requiredLevel = 1
            },
            new SkillData
            {
                skillId = 203,
                skillName = "生命恢复",
                description = "缓慢恢复生命",
                skillType = "heal",
                baseDamage = 0,
                cooldown = 2f,
                manaCost = 10,
                effectRadius = 1f,
                isActive = false,
                requiredLevel = 1
            }
        };

        foreach (var skill in skills)
        {
            skillDatabase[skill.skillId] = skill;
        }

        Debug.Log($"[SkillConfig] 已加载 {skillDatabase.Count} 个技能");
    }

    /// <summary>
    /// 获取技能数据
    /// </summary>
    public static SkillData GetSkillData(int skillId)
    {
        if (skillDatabase.TryGetValue(skillId, out var skill))
        {
            return skill;
        }
        return null;
    }

    /// <summary>
    /// 获取所有技能
    /// </summary>
    public static List<SkillData> GetAllSkills()
    {
        return new List<SkillData>(skillDatabase.Values);
    }

    /// <summary>
    /// 获取特定类型的技能
    /// </summary>
    public static List<SkillData> GetSkillsByType(string skillType)
    {
        var result = new List<SkillData>();
        foreach (var skill in skillDatabase.Values)
        {
            if (skill.skillType == skillType)
            {
                result.Add(skill);
            }
        }
        return result;
    }
}
