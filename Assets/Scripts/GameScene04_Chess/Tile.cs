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

        [SerializeField] private GameObject greenChild;
        [SerializeField] private GameObject highlightedChild;

        #endregion

        #region Main Function

        public void SetColor(TileColorOption tileColorOption)
        {
            ClearColor();

            switch (tileColorOption)
            {
                case TileColorOption.Green:
                    greenChild.SetActive(true);
                    break;
                case TileColorOption.Highlighted:
                    highlightedChild.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        private void ClearColor()
        {
            greenChild.SetActive(false);
            highlightedChild.SetActive(false);
        }

        #endregion
    }

    public enum TileColorOption
    {
        None = 0,
        Green = 1,
        Highlighted = 2,
    }
}