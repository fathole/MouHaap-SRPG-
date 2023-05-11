using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class ChessData : MonoBehaviour
    {
        // Basic Info
        public string characterName;// ����W��
        public float strength;// 1 �O�q= 1 �I���z����
        public float magic;// 1 �]�k= 1 �I�]�k����
        public float dexterity;// 1 �ޥ�= 1 �����v�A3 �R���v
        public float speed;// 1 �t��= 2 �{��
        public float luck;//1 ���B= 1 �{�סA�P�����Y��R���v�A�����v�A�{�ײv����
        public float defense;// 1 ���� = ���1�I���z����
        public float resistance;// 1 �ܩ� = ���1�I�]�k����
        public float move;// 1 ���ʤO = 1�i���ʨB��
        public float maxHealthPoint;// �̤j�ͩR��
        public float currentHealthPoint;// ��e�ͩR��

        // Chess info
        public GameObject chessModel;
        public ChessType chessType;// �Ѥl����
        public ChessStatus chessStatus;// �Ѥl���A                                  
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