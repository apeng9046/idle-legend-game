using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 游戏管理器 - 核心系统的中央控制器
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerData playerData;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private BattleManager battleManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private OfflineEarningsManager offlineEarningsManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    private void Initialize()
    {
        Debug.Log("[GameManager] 游戏初始化开始");
        
        // 初始化所有子系统
        playerData?.Initialize();
        levelManager?.Initialize();
        battleManager?.Initialize();
        uiManager?.Initialize();
        shopManager?.Initialize();
        offlineEarningsManager?.Initialize();
        
        // 初始化配置系统
        HeroConfig.Initialize();
        SkillConfig.Initialize();
        MonsterConfig.Initialize();

        // 计算离线收益
        if (offlineEarningsManager != null)
        {
            offlineEarningsManager.CalculateAndApplyOfflineEarnings(playerData);
        }

        Debug.Log("[GameManager] 游戏初始化完成");
    }

    private void Update()
    {
        // 离线收益计算
        HandleOfflineEarnings();
        
        // 自动战斗
        battleManager?.Update();
    }

    /// <summary>
    /// 处理离线收益
    /// </summary>
    private void HandleOfflineEarnings()
    {
        // 已在登录时计算
    }

    // Getters
    public PlayerData GetPlayerData() => playerData;
    public LevelManager GetLevelManager() => levelManager;
    public BattleManager GetBattleManager() => battleManager;
    public UIManager GetUIManager() => uiManager;
    public ShopManager GetShopManager() => shopManager;
    public OfflineEarningsManager GetOfflineEarningsManager() => offlineEarningsManager;
}
