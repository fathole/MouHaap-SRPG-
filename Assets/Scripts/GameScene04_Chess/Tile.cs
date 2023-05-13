using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class Tile : MonoBehaviour
    {
        #region Declaration

        public Tile parentTile;
        public Tile connectedTile;
        public Chess occupyingChess;

        public float costFromOrigin;
        public float costToDestination;
        public int terrainCost;
        public float totalCost { get { return costFromOrigin + costToDestination + terrainCost; } }
        public bool occupied;               

        [SerializeField] private GameObject frontierNotice;
        [SerializeField] private GameObject currentNotice;

        #endregion

        #region Main Function

        public void SetNotice(TileNoticeOption tileNoticeOption)
        {
            ClearNotice();

            switch (tileNoticeOption)
            {
                case TileNoticeOption.Frontier:
                    frontierNotice.SetActive(true);
                    break;
                case TileNoticeOption.Current:
                    currentNotice.SetActive(true);
                    break;
                default:
                    frontierNotice.SetActive(false);
                    currentNotice.SetActive(false);
                    break;
            }
        }

        private void ClearNotice()
        {            
            frontierNotice.SetActive(false);
            currentNotice.SetActive(false);
        }

        #endregion
    }

    public enum TileNoticeOption
    {
        None = 0,
        Frontier = 1,// The Path From Current Chess To Target Tile
        Current = 2,// The Tail Of Current Chess
        Valid = 3,// The Tail That Current Chess Can Reach
        Attack = 4,// The Tile That Current Chess Can Attack
    }
}