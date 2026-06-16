using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 关卡管理器 - 管理1000个关卡
/// </summary>
public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class LevelData
    {
        public int levelId;
        public int waves;
        public List<int> monsterIds = new List<int>();
        public long goldReward;
        public long expReward;
        public float difficulty;
    }

    private Dictionary<int, LevelData> levels = new Dictionary<int, LevelData>();
    private const int TOTAL_LEVELS = 1000;
    private const int LEVELS_PER_CHAPTER = 50;

    public void Initialize()
    {
        GenerateLevels();
        Debug.Log($"[LevelManager] 已生成{TOTAL_LEVELS}个关卡");
    }

    /// <summary>
    /// 生成所有关卡数据
    /// </summary>
    private void GenerateLevels()
    {
        for (int i = 1; i <= TOTAL_LEVELS; i++)
        {
            LevelData levelData = new LevelData
            {
                levelId = i,
                waves = 1 + (i - 1) / LEVELS_PER_CHAPTER,
                goldReward = (long)(100 * Mathf.Pow(1.05f, i - 1)),
                expReward = (long)(50 * Mathf.Pow(1.05f, i - 1)),
                difficulty = 1.0f + (i - 1) * 0.01f
            };

            // 添加怪物
            int chapter = (i - 1) / LEVELS_PER_CHAPTER;
            int monsterCount = 2 + chapter;
            for (int j = 0; j < monsterCount; j++)
            {
                int monsterId = (chapter * 10) + j + 1;
                levelData.monsterIds.Add(monsterId);
            }

            levels[i] = levelData;
        }
    }

    /// <summary>
    /// 获取关卡数据
    /// </summary>
    public LevelData GetLevelData(int levelId)
    {
        if (levels.TryGetValue(levelId, out var data))
        {
            return data;
        }
        Debug.LogWarning($"[LevelManager] 关卡{levelId}不存在");
        return null;
    }

    /// <summary>
    /// 获取章节信息
    /// </summary>
    public int GetChapter(int levelId)
    {
        return (levelId - 1) / LEVELS_PER_CHAPTER + 1;
    }

    /// <summary>
    /// 获取总关卡数
    /// </summary>
    public int GetTotalLevels() => TOTAL_LEVELS;
}
