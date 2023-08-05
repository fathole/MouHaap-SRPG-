using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessData : MonoBehaviour
{
    public ChessJobOption chessJobOption;// ¾�~
    public int level;// ����
    public int movement;// ���ʤO�G�v�T���ʨB��
    public int health;// HP�G��q
    public int strength;// �O�q�G�v�T���z�����O
    public int magic; // �]�O�G�v�T�]�k�����O
    public int skill; // �ޥ��G�v�T�R���Υ���
    public int speed;// �t�סG�v�T�^�׻P�l��
    public int physicalAttack;// ���z�����G�O�q+�Z���\�����O
    public int magicAttack;// �]�k�����G�]�O+�]�k�¤O
    public int defence;// ���z������K
    public int magicDefence;// �]�k������K
    public int luck;// �v�T�R���B�j�שM����

    // ToDo: �����v

    public static ChessData defaultChessData = new ChessData()
    {
        chessJobOption = ChessJobOption.None,
        level = 0,
        movement = 0,
        health = 0,
    };
}

public enum ChessJobOption
{
   None = 0,
   //,,, (�C�h, �M��...)
}