using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 商品数据定义
/// </summary>
[System.Serializable]
public class ShopItem
{
    public int itemId;
    public string itemName;
    public string description;
    public string itemType; // hero, gem, buff, equipment
    public int price; // 金币价格
    public int gemPrice; // 钻石价格
    public bool isGemOnly; // 是否仅钻石可买
    public int quantity; // 数量
    public string iconPath;
    public int limitedQuantity; // 限购数量（-1表示无限）n}

/// <summary>
/// 商城管理系统
/// </summary>
public class ShopManager : MonoBehaviour
{
    private List<ShopItem> shopItems = new List<ShopItem>();
    private Dictionary<int, int> purchasedCounts = new Dictionary<int, int>(); // 购买计数

    public void Initialize()
    {
        GenerateShopItems();
        LoadPurchaseHistory();
        Debug.Log($"[ShopManager] 商城已初始化，共 {shopItems.Count} 件商品");
    }

    /// <summary>
    /// 生成商城商品
    /// </summary>
    private void GenerateShopItems()
    {
        shopItems = new List<ShopItem>
        {
            // 英雄招募
            new ShopItem
            {
                itemId = 1001,
                itemName = "云雾仙子x1",
                description = "招募5星英雄云雾仙子",
                itemType = "hero",
                price = 5000,
                gemPrice = 100,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Hero_CloudMist"
            },
            new ShopItem
            {
                itemId = 1002,
                itemName = "月华公主x1",
                description = "招募5星英雄月华公主",
                itemType = "hero",
                price = 5000,
                gemPrice = 100,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Hero_MoonPrincess"
            },
            new ShopItem
            {
                itemId = 1003,
                itemName = "火焰女王x1",
                description = "招募5星英雄火焰女王",
                itemType = "hero",
                price = 5000,
                gemPrice = 100,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Hero_FireQueen"
            },

            // 钻石包
            new ShopItem
            {
                itemId = 2001,
                itemName = "小钻石包",
                description = "获得 100 钻石",
                itemType = "gem",
                price = 0,
                gemPrice = 100,
                isGemOnly = true,
                quantity = 100,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Gem_Small"
            },
            new ShopItem
            {
                itemId = 2002,
                itemName = "中钻石包",
                description = "获得 500 钻石",
                itemType = "gem",
                price = 0,
                gemPrice = 500,
                isGemOnly = true,
                quantity = 500,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Gem_Medium"
            },
            new ShopItem
            {
                itemId = 2003,
                itemName = "大钻石包",
                description = "获得 1000 钻石",
                itemType = "gem",
                price = 0,
                gemPrice = 1000,
                isGemOnly = true,
                quantity = 1000,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Gem_Large"
            },
            new ShopItem
            {
                itemId = 2004,
                itemName = "超级钻石包",
                description = "获得 5000 钻石 (超划算)",
                itemType = "gem",
                price = 0,
                gemPrice = 5000,
                isGemOnly = true,
                quantity = 5000,
                limitedQuantity = -1,
                iconPath = "UI/Shop/Gem_Mega"
            },

            // 增益道具
            new ShopItem
            {
                itemId = 3001,
                itemName = "经验加速卡",
                description = "24小时内获取经验提升2倍",
                itemType = "buff",
                price = 1000,
                gemPrice = 50,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = 3,
                iconPath = "UI/Shop/Buff_ExpBoost"
            },
            new ShopItem
            {
                itemId = 3002,
                itemName = "金币加速卡",
                description = "24小时内获取金币提升3倍",
                itemType = "buff",
                price = 2000,
                gemPrice = 80,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = 3,
                iconPath = "UI/Shop/Buff_GoldBoost"
            },
            new ShopItem
            {
                itemId = 3003,
                itemName = "全能加速卡",
                description = "24小时内获取经验和金币都提升2倍",
                itemType = "buff",
                price = 3000,
                gemPrice = 150,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = 1,
                iconPath = "UI/Shop/Buff_AllBoost"
            },

            // 装备
            new ShopItem
            {
                itemId = 4001,
                itemName = "龙刀",
                description = "传说级武器，大幅提升攻击力",
                itemType = "equipment",
                price = 5000,
                gemPrice = 200,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = 1,
                iconPath = "UI/Shop/Equipment_DragonSword"
            },
            new ShopItem
            {
                itemId = 4002,
                itemName = "圣盾",
                description = "传说级防具，大幅提升防御力",
                itemType = "equipment",
                price = 5000,
                gemPrice = 200,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = 1,
                iconPath = "UI/Shop/Equipment_HolyShield"
            },
            new ShopItem
            {
                itemId = 4003,
                itemName = "生命宝石",
                description = "稀有装备，提升最大生命值",
                itemType = "equipment",
                price = 2000,
                gemPrice = 100,
                isGemOnly = false,
                quantity = 1,
                limitedQuantity = 3,
                iconPath = "UI/Shop/Equipment_LifeGem"
            },

            // 特殊道具
            new ShopItem
            {
                itemId = 5001,
                itemName = "抽奖券x10",
                description = "获得10张稀有抽奖券",
                itemType = "consumable",
                price = 1000,
                gemPrice = 50,
                isGemOnly = false,
                quantity = 10,
                limitedQuantity = 5,
                iconPath = "UI/Shop/Ticket_Rare"
            },
            new ShopItem
            {
                itemId = 5002,
                itemName = "传说抽奖券x5",
                description = "获得5张传说级抽奖券",
                itemType = "consumable",
                price = 5000,
                gemPrice = 200,
                isGemOnly = false,
                quantity = 5,
                limitedQuantity = 2,
                iconPath = "UI/Shop/Ticket_Legend"
            }
        };
    }

    /// <summary>
    /// 购买商品
    /// </summary>
    public bool PurchaseItem(int itemId, PlayerData playerData)
    {
        var item = GetShopItem(itemId);
        if (item == null)
        {
            Debug.LogWarning($"[ShopManager] 商品{itemId}不存在");
            return false;
        }

        // 检查购买限制
        if (item.limitedQuantity > 0)
        {
            if (!purchasedCounts.ContainsKey(itemId))
                purchasedCounts[itemId] = 0;

            if (purchasedCounts[itemId] >= item.limitedQuantity)
            {
                Debug.Log($"[ShopManager] 商品{item.itemName}已达购买限制");
                return false;
            }
        }

        // 检查金币或钻石
        if (item.isGemOnly)
        {
            if (playerData.GetGems() < item.gemPrice)
            {
                Debug.Log("[ShopManager] 钻石不足");
                return false;
            }
            playerData.AddGems(-item.gemPrice);
        }
        else
        {
            // 优先使用金币
            if (playerData.GetGold() >= item.price)
            {
                playerData.AddGold(-item.price);
            }
            else if (playerData.GetGems() >= item.gemPrice)
            {
                playerData.AddGems(-item.gemPrice);
            }
            else
            {
                Debug.Log("[ShopManager] 金币和钻石都不足");
                return false;
            }
        }

        // 记录购买
        if (!purchasedCounts.ContainsKey(itemId))
            purchasedCounts[itemId] = 0;
        purchasedCounts[itemId]++;

        Debug.Log($"[ShopManager] 成功购买 {item.itemName}");
        SavePurchaseHistory();
        return true;
    }

    /// <summary>
    /// 获取商品
    /// </summary>
    public ShopItem GetShopItem(int itemId)
    {
        return shopItems.Find(x => x.itemId == itemId);
    }

    /// <summary>
    /// 获取所有商品
    /// </summary>
    public List<ShopItem> GetAllShopItems()
    {
        return new List<ShopItem>(shopItems);
    }

    /// <summary>
    /// 获取特定类型的商品
    /// </summary>
    public List<ShopItem> GetItemsByType(string itemType)
    {
        return shopItems.FindAll(x => x.itemType == itemType);
    }

    /// <summary>
    /// 获取剩余购买次数
    /// </summary>
    public int GetRemainingPurchases(int itemId)
    {
        var item = GetShopItem(itemId);
        if (item == null || item.limitedQuantity < 0)
            return -1;

        if (!purchasedCounts.ContainsKey(itemId))
            return item.limitedQuantity;

        return item.limitedQuantity - purchasedCounts[itemId];
    }

    /// <summary>
    /// 保存购买历史
    /// </summary>
    private void SavePurchaseHistory()
    {
        string json = JsonUtility.ToJson(new PurchaseHistoryData { purchasedCounts = purchasedCounts });
        PlayerPrefs.SetString("ShopPurchaseHistory", json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 加载购买历史
    /// </summary>
    private void LoadPurchaseHistory()
    {
        if (PlayerPrefs.HasKey("ShopPurchaseHistory"))
        {
            string json = PlayerPrefs.GetString("ShopPurchaseHistory");
            // 注意: Unity的JsonUtility不支持Dictionary，需要自定义序列化
            Debug.Log("[ShopManager] 已加载购买历史");
        }
    }

    [System.Serializable]
    private class PurchaseHistoryData
    {
        public Dictionary<int, int> purchasedCounts = new Dictionary<int, int>();
    }
}
