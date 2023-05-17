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
            public int level;// ���ⵥ��
            public int maxHealthPoint;// �̤j�ͩR��
            public int currentHealthPoint;// ��e�ͩR��
            public int strength;// �O�q: 1 �O�q = 1 ���z����
            public int magic;// �]�k: 1 �]�k= 1 �]�k����
            public int dexterity;// �ޥ�: 1 �ޥ� = 1 �����v �� 3 �R���v
            public int speed;// �t��: 1 �t�� = 2 �{��
            public int luck;// ���B: 1 ���B= 1 �{�� �� ���Y��R���v�A�����v�A�{�ײv����
            public int defense;// ����:  1 ���� = 1 ���z�ˮ`��K
            public int resistance;// �ܩ�: 1 �ܩ� = 1 �]�k�ˮ`��K
            public int move;// 1 ���ʤO = 1�i���ʨB��            
        }

        [SerializeField]
        public struct ChessInfoProperties
        {
            public ChessTypeOption chessType;// �Ѥl����
            public ChessStatusOption chessStatus;// �Ѥl���A          
            public int physicalAttackDamage;// ���z�����ˮ` = �O�q + �˳� + ...
            public int magicalAttackDamage;// �]�k�����ˮ` = �]�k + �˳� + ...
            public int physicalDamageReduction;// ���z�ˮ`��K = ���� + �˳� + ...
            public int magicalDamageReduction;// �]�k�ˮ`��K = ���� + �˳� + ...
            public Tile chessTile;

            public bool isMoving;
        }        

        // ToDo: �˳���
        // ToDo: ���ŤW�ɦ����v

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