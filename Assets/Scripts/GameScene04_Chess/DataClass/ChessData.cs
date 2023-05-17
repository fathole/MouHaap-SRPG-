using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    [System.Serializable]
    public class ChessData
    {
        [SerializeField]
        public struct CharacterInfoProperties
        {
            public string characterName;
            public int level;// 角色等級
            public int maxHealthPoint;// 最大生命值
            public int currentHealthPoint;// 當前生命值
            public int strength;// 力量: 1 力量 = 1 物理攻擊
            public int magic;// 魔法: 1 魔法= 1 魔法攻擊
            public int dexterity;// 技巧: 1 技巧 = 1 暴擊率 及 3 命中率
            public int speed;// 速度: 1 速度 = 2 閃避
            public int luck;// 幸運: 1 幸運= 1 閃避 及 關係到命中率，暴擊率，閃避率機制
            public int defense;// 防衛:  1 防衛 = 1 物理傷害減免
            public int resistance;// 抗性: 1 抗性 = 1 魔法傷害減免
            public int move;// 1 移動力 = 1可移動步數            
        }

        [SerializeField]
        public struct ChessInfoProperties
        {
            public ChessTypeOption chessType;// 棋子種類
            public ChessStatusOption chessStatus;// 棋子狀態          
            public int physicalAttackDamage;// 物理攻擊傷害 = 力量 + 裝備 + ...
            public int magicalAttackDamage;// 魔法攻擊傷害 = 魔法 + 裝備 + ...
            public int physicalDamageReduction;// 物理傷害減免 = 防衛 + 裝備 + ...
            public int magicalDamageReduction;// 魔法傷害減免 = 防衛 + 裝備 + ...
            public Tile chessTile;

            public bool isMoving;
        }        

        // ToDo: 裝備欄
        // ToDo: 等級上升成長率

        public CharacterInfoProperties characterInfo;
        public ChessInfoProperties chessInfo;                               
    }

    public enum ChessTypeOption
    {
        None = 0,
        Ally = 1,
        Enemy = 2,
    }
    public enum ChessStatusOption
    {
        None = 0,
        Waiting = 1, // Waiting Action
        Finished = 2, // Finished Action
    }
}