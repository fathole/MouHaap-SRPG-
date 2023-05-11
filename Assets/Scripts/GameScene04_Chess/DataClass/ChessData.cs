using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class ChessData : MonoBehaviour
    {
        // Basic Info
        public string characterName;// 角色名稱
        public float strength;// 1 力量= 1 點物理攻擊
        public float magic;// 1 魔法= 1 點魔法攻擊
        public float dexterity;// 1 技巧= 1 暴擊率，3 命中率
        public float speed;// 1 速度= 2 閃避
        public float luck;//1 幸運= 1 閃避，同時關係到命機率，暴擊率，閃避率機制
        public float defense;// 1 防衛 = 抵抗1點物理攻擊
        public float resistance;// 1 抗性 = 抵抗1點魔法攻擊
        public float move;// 1 移動力 = 1可移動步數
        public float maxHealthPoint;// 最大生命值
        public float currentHealthPoint;// 當前生命值

        // Chess info
        public GameObject chessModel;
        public ChessType chessType;// 棋子種類
        public ChessStatus chessStatus;// 棋子狀態                                  
        public Tile chessTile;
        public bool isMoving;// May Move To Chess.cs
        public LayerMask groundLayerMask;
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
    public enum TileStatusOption
    {
        None = 0,
        Current = 1,
        Target = 2,
        Selectable = 3,
    }
}