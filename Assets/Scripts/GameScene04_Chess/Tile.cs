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

        [HideInInspector] public float costFromOrigin;
        [HideInInspector] public float costToDestination;
        [HideInInspector] public float totalCost { get { return costFromOrigin + costToDestination + terrainCost; } }

        public int terrainCost;        
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
}