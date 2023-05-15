using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    [System.Serializable]
    public struct ChessData
    {
        // Basic Info
        public string characterName;// 角色名稱
        public int level;// 角色等級
        public int strength;// 1 力量= 1 點物理攻擊
        public int magic;// 1 魔法= 1 點魔法攻擊
        public int dexterity;// 1 技巧= 1 暴擊率，3 命中率
        public int speed;// 1 速度= 2 閃避
        public int luck;//1 幸運= 1 閃避，同時關係到命機率，暴擊率，閃避率機制
        public int defense;// 1 防衛 = 抵抗1點物理攻擊
        public int resistance;// 1 抗性 = 抵抗1點魔法攻擊
        public int move;// 1 移動力 = 1可移動步數
        public int maxHealthPoint;// 最大生命值
        public int currentHealthPoint;// 當前生命值         

        // Chess info
        public GameObject chessModel;
        public ChessType chessType;// 棋子種類
        public ChessStatus chessStatus;// 棋子狀態                                  
        public Tile chessTile;
        public LayerMask groundLayerMask;
        public bool isMoving;// May Move To Chess.cs
        
        // ToDo: 等級上升成長率
    }

    public enum ChessType
    {
        None = 0,
        Ally = 1,
        Enemy = 2,
    }
    public enum ChessStatus
    {
        None = 0,
        Waiting = 1, // Waiting Action
        Finished = 2, // Finished Action
    }
}