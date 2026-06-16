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
        // 待实现: 计算玩家离线期间的收益
    }

    /// <summary>
    /// 获取玩家数据
    /// </summary>
    public PlayerData GetPlayerData() => playerData;

    /// <summary>
    /// 获取关卡管理器
    /// </summary>
    public LevelManager GetLevelManager() => levelManager;

    /// <summary>
    /// 获取战斗管理器
    /// </summary>
    public BattleManager GetBattleManager() => battleManager;

    /// <summary>
    /// 获取UI管理器
    /// </summary>
    public UIManager GetUIManager() => uiManager;
}
