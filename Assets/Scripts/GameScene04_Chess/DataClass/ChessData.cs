using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    [System.Serializable]
    public struct ChessData
    {
        // Basic Info
        public string characterName;// ����W��
        public int level;// ���ⵥ��
        public int strength;// 1 �O�q= 1 �I���z����
        public int magic;// 1 �]�k= 1 �I�]�k����
        public int dexterity;// 1 �ޥ�= 1 �����v�A3 �R���v
        public int speed;// 1 �t��= 2 �{��
        public int luck;//1 ���B= 1 �{�סA�P�����Y��R���v�A�����v�A�{�ײv����
        public int defense;// 1 ���� = ���1�I���z����
        public int resistance;// 1 �ܩ� = ���1�I�]�k����
        public int move;// 1 ���ʤO = 1�i���ʨB��
        public int maxHealthPoint;// �̤j�ͩR��
        public int currentHealthPoint;// ��e�ͩR��         

        // Chess info
        public GameObject chessModel;
        public ChessType chessType;// �Ѥl����
        public ChessStatus chessStatus;// �Ѥl���A                                  
        public Tile chessTile;
        public LayerMask groundLayerMask;
        public bool isMoving;// May Move To Chess.cs
        
        // ToDo: ���ŤW�ɦ����v
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