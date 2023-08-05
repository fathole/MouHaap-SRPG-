using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessData : MonoBehaviour
{
    public ChessJobOption chessJobOption;// 職業
    public int level;// 等級
    public int movement;// 移動力：影響移動步數
    public int health;// HP：血量
    public int strength;// 力量：影響物理攻擊力
    public int magic; // 魔力：影響魔法攻擊力
    public int skill; // 技巧：影響命中及必殺
    public int speed;// 速度：影響回避與追擊
    public int physicalAttack;// 物理攻擊：力量+武器功攻擊力
    public int magicAttack;// 魔法攻擊：魔力+魔法威力
    public int defence;// 物理攻擊減免
    public int magicDefence;// 魔法攻擊減免
    public int luck;// 影響命中、迴避和必避

    // ToDo: 成長率

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
   //,,, (劍士, 刀客...)
}