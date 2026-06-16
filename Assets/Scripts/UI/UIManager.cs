using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI管理器 - 管理所有UI界面
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Text goldText;
    [SerializeField] private Text gemsText;
    [SerializeField] private Text levelText;
    [SerializeField] private Slider expSlider;

    private PlayerData playerData;

    public void Initialize()
    {
        playerData = GameManager.Instance.GetPlayerData();
        UpdateUI();
        Debug.Log("[UIManager] UI系统初始化");
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
            levelText.text = $"关卡 {playerData.GetCurrentLevel()}/{GameManager.Instance.GetLevelManager().GetTotalLevels()}";

        if (expSlider != null)
        {
            // 经验条逻辑
            expSlider.value = (playerData.GetExp() % 1000) / 1000f;
        }
    }

    /// <summary>
    /// 显示消息
    /// </summary>
    public void ShowMessage(string message)
    {
        Debug.Log($"[UI Message] {message}");
        // 待实现: 浮窗消息显示
    }
}
