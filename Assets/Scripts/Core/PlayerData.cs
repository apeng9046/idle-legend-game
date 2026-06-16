using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 玩家数据管理
/// </summary>
public class PlayerData : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int level = 1;
        public long exp = 0;
        public long gold = 0;
        public long gems = 0;
        public int currentLevel = 1;
        public List<int> heroIds = new List<int>();
    }

    private Data data = new Data();
    private const string SAVE_KEY = "PlayerData";

    public void Initialize()
    {
        LoadData();
        Debug.Log($"[PlayerData] 玩家等级: {data.level}, 金币: {data.gold}, 钻石: {data.gems}");
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    public void SaveData()
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
        Debug.Log("[PlayerData] 数据已保存");
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            data = JsonUtility.FromJson<Data>(json);
            Debug.Log("[PlayerData] 数据已读取");
        }
        else
        {
            Debug.Log("[PlayerData] 创建新档案");
        }
    }

    // Getters
    public int GetLevel() => data.level;
    public long GetExp() => data.exp;
    public long GetGold() => data.gold;
    public long GetGems() => data.gems;
    public int GetCurrentLevel() => data.currentLevel;
    public List<int> GetHeroIds() => data.heroIds;

    // Setters
    public void AddGold(long amount)
    {
        data.gold += amount;
        SaveData();
    }

    public void AddGems(long amount)
    {
        data.gems += amount;
        SaveData();
    }

    public void AddExp(long amount)
    {
        data.exp += amount;
        SaveData();
    }

    public void SetCurrentLevel(int level)
    {
        data.currentLevel = level;
        SaveData();
    }

    public void AddHero(int heroId)
    {
        if (!data.heroIds.Contains(heroId))
        {
            data.heroIds.Add(heroId);
            SaveData();
        }
    }
}
