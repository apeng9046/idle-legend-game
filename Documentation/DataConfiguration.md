# 数据配置指南

## 关卡配置

### 自动生成算法

关卡系统使用算法自动生成1000个关卡：

```
总关卡数: 1000
每章关卡: 50
总章节数: 20

对于第L关：
  章节号 = (L - 1) / 50 + 1
  波次数 = 1 + (L - 1) / 50
  基础金币 = 100 × 1.05^(L-1)
  基础经验 = 50 × 1.05^(L-1)
  难度系数 = 1.0 + (L-1) × 0.01
```

### 怪物分配

```
每章怪物数递增：
  第1-50关: 2只怪物
  第51-100关: 3只怪物
  第101-150关: 4只怪物
  ...
  第951-1000关: 21只怪物
```

## 英雄配置

### 英雄属性

```json
{
  "heroId": 1,
  "heroName": "云雾仙子",
  "rarity": 5,
  "baseAttack": 100,
  "baseDefense": 50,
  "baseHp": 200,
  "isFemale": true,
  "skills": [101, 102, 103]
}
```

### 稀有度等级

| 稀有度 | 获取难度 | 属性加成 |
|------|--------|--------|
| 1星  | 普通   | ×1.0   |
| 2星  | 较难   | ×1.2   |
| 3星  | 困难   | ×1.5   |
| 4星  | 很难   | ×2.0   |
| 5星  | 极难   | ×3.0   |

## 怪物配置

### 山海经神兽

```json
{
  "monsterId": 1,
  "monsterName": "青龙",
  "chineseOrigin": "山海经·东方",
  "baseAttack": 50,
  "baseDefense": 30,
  "baseHp": 150,
  "skills": [201, 202],
  "goldReward": 100,
  "expReward": 50
}
```

## 技能配置

### 技能属性

```json
{
  "skillId": 101,
  "skillName": "风刃斩",
  "description": "释放风刃进行攻击",
  "type": "attack",
  "baseDamage": 150,
  "cooldown": 3.0,
  "manaCost": 20,
  "effectPath": "Effects/WindSlash"
}
```

## 装备配置

### 装备属性

```json
{
  "equipId": 1001,
  "equipName": "龙刀",
  "type": "weapon",
  "rarity": 4,
  "attackBonus": 50,
  "defenseBonus": 0,
  "hpBonus": 0,
  "levelRequired": 10,
  "modelPath": "Models/Equipment/Sword_Dragon"
}
```

## 道具配置

### 消耗品

```json
{
  "itemId": 2001,
  "itemName": "生命药剂",
  "type": "consumable",
  "effect": "恢复500血量",
  "value": 100,
  "iconPath": "UI/Items/Potion_Life"
}
```

## 升级配置

### 等级经验要求

```
升级经验公式:
EXP_Required(L) = 100 × L^1.5

等级1: 100
等级2: 283
等级3: 519
等级4: 800
等级5: 1118
...
等级100: 1000000
```

## 货币配置

### 游戏内货币

| 货币 | 获取方式 | 消费用途 |
|------|--------|--------|
| 金币 | 战斗胜利 | 英雄升级、装备强化 |
| 钻石 | 充值、高级副本 | 加速、特殊招募 |
| 魂石 | 怪物掉落 | 英雄进阶 |

## 关卡奖励

### 首通奖励

```json
{
  "levelId": 1,
  "firstClearBonus": {
    "gems": 10,
    "items": [2001]
  }
}
```

## 配置导入

### JSON格式

所有配置文件统一使用JSON格式，存储在 `Configs/` 目录下：

- `Configs/Heroes/` - 英雄配置
- `Configs/Monsters/` - 怪物配置
- `Configs/Skills/` - 技能配置
- `Configs/Equipment/` - 装备配置
- `Configs/Items/` - 道具配置

### 加载流程

```csharp
public static void LoadConfigFromJSON(string path)
{
    string json = System.IO.File.ReadAllText(path);
    HeroData data = JsonUtility.FromJson<HeroData>(json);
    // 处理数据
}
```

---

**配置文件示例见 `Configs/` 目录**
