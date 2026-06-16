using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 战斗管理器 - 处理战斗逻辑
/// </summary>
public class BattleManager : MonoBehaviour
{
    [System.Serializable]
    public class BattleState
    {
        public bool isInBattle = false;
        public float battleSpeed = 1.0f;
        public int currentWave = 0;
        public List<Character> playerTeam = new List<Character>();
        public List<Character> enemyTeam = new List<Character>();
    }

    private BattleState battleState = new BattleState();
    private float battleTimer = 0f;
    private const float ATTACK_INTERVAL = 1.0f;

    public void Initialize()
    {
        Debug.Log("[BattleManager] 战斗系统初始化");
    }

    public void Update()
    {
        if (!battleState.isInBattle)
            return;

        battleTimer += Time.deltaTime * battleState.battleSpeed;

        if (battleTimer >= ATTACK_INTERVAL)
        {
            battleTimer = 0f;
            ExecuteRound();
        }
    }

    /// <summary>
    /// 执行战斗回合
    /// </summary>
    private void ExecuteRound()
    {
        // 玩家队伍攻击
        foreach (var player in battleState.playerTeam)
        {
            if (player.IsAlive() && battleState.enemyTeam.Count > 0)
            {
                var target = battleState.enemyTeam[0];
                int damage = player.CalculateDamage();
                target.TakeDamage(damage);
                Debug.Log($"[Battle] {player.GetName()} 造成 {damage} 伤害");
            }
        }

        // 移除死亡的敌人
        battleState.enemyTeam.RemoveAll(e => !e.IsAlive());

        // 检查战斗状态
        if (battleState.enemyTeam.Count == 0)
        {
            WinBattle();
        }
    }

    /// <summary>
    /// 开始战斗
    /// </summary>
    public void StartBattle(List<Character> players, List<Character> enemies)
    {
        battleState.isInBattle = true;
        battleState.playerTeam = players;
        battleState.enemyTeam = enemies;
        battleState.currentWave = 1;
        Debug.Log("[BattleManager] 战斗开始");
    }

    /// <summary>
    /// 获胜
    /// </summary>
    private void WinBattle()
    {
        battleState.isInBattle = false;
        Debug.Log("[BattleManager] 战斗胜利");
    }

    public BattleState GetBattleState() => battleState;
}

/// <summary>
/// 角色基类
/// </summary>
public class Character
{
    protected string name;
    protected int hp;
    protected int maxHp;
    protected int attack;
    protected int defense;

    public virtual int CalculateDamage()
    {
        return attack + Random.Range(-attack / 4, attack / 4);
    }

    public virtual void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(1, damage - defense / 2);
        hp -= actualDamage;
    }

    public bool IsAlive() => hp > 0;
    public string GetName() => name;
}
