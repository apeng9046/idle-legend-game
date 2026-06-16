using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// UI管理系统 - 统一管理所有UI界面
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Text goldText;
    [SerializeField] private Text gemsText;
    [SerializeField] private Text levelText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button heroButton;
    [SerializeField] private Button battleButton;
    [SerializeField] private Button settingsButton;

    private PlayerData playerData;
    private Dictionary<string, UIPanel> uiPanels = new Dictionary<string, UIPanel>();
    private UIPanel currentPanel;

    public void Initialize()
    {
        playerData = GameManager.Instance.GetPlayerData();
        InitializeUIElements();
        RegisterButtonListeners();
        UpdateUI();
        Debug.Log("[UIManager] UI系统已初始化");
    }

    /// <summary>
    /// 初始化UI元素
    /// </summary>
    private void InitializeUIElements()
    {
        // 注册所有UI面板
        RegisterUIPanel("MainMenu", new MainMenuPanel());
        RegisterUIPanel("GameScreen", new GameScreenPanel());
        RegisterUIPanel("ShopPanel", new ShopPanel());
        RegisterUIPanel("HeroPanel", new HeroPanel());
        RegisterUIPanel("BattlePanel", new BattlePanel());
        RegisterUIPanel("SettingsPanel", new SettingsPanel());
        RegisterUIPanel("SocialPanel", new SocialPanel());
    }

    /// <summary>
    /// 注册UI面板
    /// </summary>
    private void RegisterUIPanel(string panelName, UIPanel panel)
    {
        if (!uiPanels.ContainsKey(panelName))
        {
            uiPanels[panelName] = panel;
            panel.Initialize();
        }
    }

    /// <summary>
    /// 注册按钮监听
    /// </summary>
    private void RegisterButtonListeners()
    {
        if (shopButton != null)
            shopButton.onClick.AddListener(() => ShowPanel("ShopPanel"));
        if (heroButton != null)
            heroButton.onClick.AddListener(() => ShowPanel("HeroPanel"));
        if (battleButton != null)
            battleButton.onClick.AddListener(() => ShowPanel("BattlePanel"));
        if (settingsButton != null)
            settingsButton.onClick.AddListener(() => ShowPanel("SettingsPanel"));
    }

    /// <summary>
    /// 显示UI面板
    /// </summary>
    public void ShowPanel(string panelName)
    {
        if (currentPanel != null)
        {
            currentPanel.Hide();
        }

        if (uiPanels.TryGetValue(panelName, out var panel))
        {
            panel.Show();
            currentPanel = panel;
            Debug.Log($"[UIManager] 显示面板: {panelName}");
        }
    }

    /// <summary>
    /// 隐藏当前面板
    /// </summary>
    public void HideCurrentPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.Hide();
            currentPanel = null;
        }
    }

    private void Update()
    {
        UpdateUI();
    }

    /// <summary>
    /// 更新UI显示
    /// </summary>
    public void UpdateUI()
    {
        if (playerData == null)
            return;

        if (goldText != null)
            goldText.text = $"金币: {playerData.GetGold():#,0}";

        if (gemsText != null)
            gemsText.text = $"钻石: {playerData.GetGems():#,0}";

        if (levelText != null)
            levelText.text = $"关卡 {playerData.GetCurrentLevel()}/1000";

        if (expSlider != null)
        {
            expSlider.value = (playerData.GetExp() % 1000) / 1000f;
        }
    }

    /// <summary>
    /// 显示消息
    /// </summary>
    public void ShowMessage(string message, float duration = 2f)
    {
        Debug.Log($"[UI Message] {message}");
        // 待实现: 浮窗消息显示
    }

    /// <summary>
    /// 显示提示
    /// </summary>
    public void ShowTip(string title, string message)
    {
        Debug.Log($"[UI Tip] {title}: {message}");
        // 待实现: 提示框显示
    }
}

/// <summary>
/// UI面板基类
/// </summary>
public abstract class UIPanel
{
    protected GameObject panelObject;
    protected bool isVisible = false;

    public virtual void Initialize()
    {
        // 待实现
    }

    public virtual void Show()
    {
        isVisible = true;
        if (panelObject != null)
            panelObject.SetActive(true);
        Debug.Log($"[UIPanel] {GetType().Name} 已显示");
    }

    public virtual void Hide()
    {
        isVisible = false;
        if (panelObject != null)
            panelObject.SetActive(false);
        Debug.Log($"[UIPanel] {GetType().Name} 已隐藏");
    }

    public virtual void Refresh()
    {
        // 待实现
    }
}

/// <summary>
/// 主菜单面板
/// </summary>
public class MainMenuPanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[MainMenuPanel] 主菜单已初始化");
    }
}

/// <summary>
/// 游戏主屏幕面板
/// </summary>
public class GameScreenPanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[GameScreenPanel] 游戏屏幕已初始化");
    }
}

/// <summary>
/// 商城面板
/// </summary>
public class ShopPanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[ShopPanel] 商城面板已初始化");
    }
}

/// <summary>
/// 英雄面板
/// </summary>
public class HeroPanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[HeroPanel] 英雄面板已初始化");
    }
}

/// <summary>
/// 战斗面板
/// </summary>
public class BattlePanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[BattlePanel] 战斗面板已初始化");
    }
}

/// <summary>
/// 设置面板
/// </summary>
public class SettingsPanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[SettingsPanel] 设置面板已初始化");
    }
}

/// <summary>
/// 社交面板
/// </summary>
public class SocialPanel : UIPanel
{
    public override void Initialize()
    {
        Debug.Log("[SocialPanel] 社交面板已初始化");
    }
}
