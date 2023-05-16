using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public enum TileNoticeOption
    {
        None = 0,
        Frontier = 1,// The Path From Current Chess To Target Tile
        Current = 2,// The Tail Of Current Chess
        Valid = 3,// The Tail That Current Chess Can Reach
        Attack = 4,// The Tile That Current Chess Can Attack
    }
}