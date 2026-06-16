# 山海传奇游戏 (Idle Legend Game)

一款融合古代英雄与山海经神兽的放置游戏，拥有1000个关卡、精美3D角色和环境。

## 项目特性

- 🎮 **放置游戏机制** - 自动战斗、离线收益
- 🏛️ **古代背景** - 中国古代英雄与山海经神兽
- 👸 **美女角色** - 多位精美3D女性英雄
- 🐉 **神兽敌人** - 山海经中的各种神兽
- 🎯 **1000+关卡** - 循序渐进的游戏内容
- 🌍 **3D环保** - 精美3D场景与特效
- 📱 **单机体验** - 完整的离线游戏体验

## 项目结构

```
idle-legend-game/
├── Assets/                    # Unity资源目录
│   ├── Scripts/              # 游戏脚本
│   │   ├── Core/            # 核心系统
│   │   ├── Game/            # 游戏逻辑
│   │   ├── UI/              # UI系统
│   │   ├── Data/            # 数据管理
│   │   └── Managers/        # 各类管理器
│   ├── Prefabs/             # 预制件
│   ├── Scenes/              # 场景文件
│   ├── Models/              # 3D模型
│   ├── Animations/          # 动画文件
│   ├── Materials/           # 材质
│   ├── Audio/               # 音乐音效
│   └── UI/                  # UI资源
├── Configs/                  # 游戏配置
│   ├── Heroes/              # 英雄数据配置
│   ├── Monsters/            # 怪物数据配置
│   ├── Levels/              # 关卡数据
│   └── GameSettings.json    # 全局设置
├── Documentation/            # 文档
├── ProjectSettings/         # Unity项目设置
└── .gitignore              # Git忽略文件
```

## 核心系统

### 1. 角色系统
- 招募机制
- 升级系统
- 技能系统
- 装备系统

### 2. 战斗系统
- 自动战斗
- 伤害计算
- 特殊技能
- 战斗特效

### 3. 进度系统
- 1000个关卡
- 敌人波次
- 难度递进
- 奖励机制

### 4. 资源系统
- 金币
- 钻石
- 经验值
- 特殊材料

### 5. UI系统
- 主菜单
- 游戏界面
- 角色界面
- 商店界面
- 设置菜单

## 快速开始

### 环境要求
- Unity 2021.3 LTS 或更新版本
- Visual Studio 2019+

### 项目设置

1. 克隆项目
```bash
git clone https://github.com/apeng9046/idle-legend-game.git
```

2. 在Unity Hub中打开项目

3. 等待资源导入完成

4. 打开 `Assets/Scenes/MainMenu.unity` 开始游戏

## 开发文档

- [架构设计](Documentation/Architecture.md) - 详细的系统架构
- [API文档](Documentation/API.md) - 完整的API参考
- [数据配置](Documentation/DataConfiguration.md) - 配置和数据结构

## 游戏特色

### 英雄角色
- 云雾仙子 - 风属性英雄
- 月华公主 - 月光战士
- 火焰女王 - 火属性法师
- ...更多角色持续更新

### 山海经神兽
- 青龙 - 东方守护
- 白虎 - 西方凶兽
- 朱雀 - 南方火鸟
- 玄武 - 北方冰兽
- 麒麟 - 中央仁兽
- ...共200+种神兽

### 关卡内容
- 20个章节
- 每章50个关卡
- 循序渐进的难度
- 丰富的敌人配置

## 贡献指南

欢迎提交Issue和Pull Request！

## 许可证

MIT License

## 开发团队

- 项目负责人: apeng9046

---

**最后更新**: 2026年6月16日
