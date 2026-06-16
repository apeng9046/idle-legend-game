# 山海传奇游戏 - API文档

## GameManager API

### 初始化

```csharp
GameManager.Instance.Initialize();
```

### 获取各系统

```csharp
PlayerData playerData = GameManager.Instance.GetPlayerData();
LevelManager levelManager = GameManager.Instance.GetLevelManager();
BattleManager battleManager = GameManager.Instance.GetBattleManager();
UIManager uiManager = GameManager.Instance.GetUIManager();
```

---

## PlayerData API

### 读写操作

```csharp
// 获取资源
long gold = playerData.GetGold();
long gems = playerData.GetGems();
int level = playerData.GetLevel();
long exp = playerData.GetExp();

// 增加资源
playerData.AddGold(100);
playerData.AddGems(10);
playerData.AddExp(50);

// 管理英雄
playerData.AddHero(1);
List<int> heroIds = playerData.GetHeroIds();

// 关卡进度
int currentLevel = playerData.GetCurrentLevel();
playerData.SetCurrentLevel(5);

// 保存
playerData.SaveData();
playerData.LoadData();
```

---

## LevelManager API

### 关卡查询

```csharp
LevelManager.LevelData levelData = levelManager.GetLevelData(1);
int chapter = levelManager.GetChapter(50);
int totalLevels = levelManager.GetTotalLevels();
```

### LevelData 结构

```csharp
public class LevelData
{
    public int levelId;              // 关卡ID
    public int waves;                // 波次数
    public List<int> monsterIds;     // 怪物列表
    public long goldReward;          // 金币奖励
    public long expReward;           // 经验奖励
    public float difficulty;         // 难度系数
}
```

---

## BattleManager API

### 战斗控制

```csharp
// 开始战斗
List<Character> players = new List<Character>();
List<Character> enemies = new List<Character>();
battleManager.StartBattle(players, enemies);

// 获取战斗状态
BattleManager.BattleState state = battleManager.GetBattleState();
bool isInBattle = state.isInBattle;
float battleSpeed = state.battleSpeed;
```

### 角色接口

```csharp
int damage = character.CalculateDamage();
character.TakeDamage(50);
bool alive = character.IsAlive();
string name = character.GetName();
```

---

## HeroConfig API

### 英雄查询

```csharp
HeroConfig.Initialize();

// 获取单个英雄
HeroData hero = HeroConfig.GetHeroData(1);

// 获取所有英雄
List<HeroData> allHeroes = HeroConfig.GetAllHeroes();
```

### HeroData 结构

```csharp
public class HeroData
{
    public int heroId;               // 英雄ID
    public string heroName;          // 英雄名称
    public string description;       // 描述
    public int rarity;               // 稀有度(1-5)
    public int baseAttack;           // 基础攻击
    public int baseDefense;          // 基础防御
    public int baseHp;               // 基础血量
    public List<int> skills;         // 技能列表
    public string modelPath;         // 模型路径
    public string portraitPath;      // 肖像路径
    public bool isFemale;            // 是否为女性
}
```

---

## MonsterConfig API

### 怪物查询

```csharp
MonsterConfig.Initialize();

// 获取单个怪物
MonsterData monster = MonsterConfig.GetMonsterData(1);

// 获取所有怪物
List<MonsterData> allMonsters = MonsterConfig.GetAllMonsters();
```

### MonsterData 结构

```csharp
public class MonsterData
{
    public int monsterId;            // 怪物ID
    public string monsterName;       // 怪物名称
    public string description;       // 描述
    public string chineseOrigin;     // 山海经出处
    public int baseAttack;           // 基础攻击
    public int baseDefense;          // 基础防御
    public int baseHp;               // 基础血量
    public List<int> skills;         // 技能列表
    public string modelPath;         // 模型路径
    public long goldReward;          // 金币奖励
    public long expReward;           // 经验奖励
}
```

---

## UIManager API

### UI 更新

```csharp
uiManager.UpdateUI();
uiManager.ShowMessage("战斗胜利！");
```

---

## 使用示例

### 招募英雄

```csharp
HeroData heroData = HeroConfig.GetHeroData(1);
GameManager.Instance.GetPlayerData().AddHero(1);
GameManager.Instance.GetUIManager().ShowMessage($"成功招募 {heroData.heroName}!");
```

### 开始关卡

```csharp
int levelId = GameManager.Instance.GetPlayerData().GetCurrentLevel();
LevelManager.LevelData levelData = GameManager.Instance.GetLevelManager().GetLevelData(levelId);

// 创建敌方队伍
List<Character> enemies = new List<Character>();
foreach (int monsterId in levelData.monsterIds)
{
    MonsterData monsterData = MonsterConfig.GetMonsterData(monsterId);
    // 创建怪物角色
}

// 创建玩家队伍
List<Character> players = new List<Character>();
// 添加招募的英雄

// 开始战斗
GameManager.Instance.GetBattleManager().StartBattle(players, enemies);
```

---

**持续更新中...**
