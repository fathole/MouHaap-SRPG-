using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class TileGenerator : MonoBehaviour
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion        

        #region Main Function

        private void ClearGrid()
        {
            for (int i = transform.childCount; i >= transform.childCount; i--)
            {
                if (transform.childCount == 0)
                {
                    break;
                }

                int childIndex   = Mathf.Clamp(i - 1, 0, transform.childCount);
                DestroyImmediate(transform.GetChild(childIndex).gameObject);
            }
        }

        private Vector2 DetermineTileSize(Bounds tileBounds)
        {
            return new Vector2((tileBounds.extents.x * 2) * 0.75f, (tileBounds.extents.z * 2));
        }

        private void CreateTile(GameObject tile, Vector3 position,Vector2Int id)
        {
            GameObject newTile = Instantiate(tile.gameObject, position, Quaternion.identity, transform);
            newTile.name = "Tile " + id;

            Debug.Log("Created a tile!");
        }

        public void GenerateGrid(GameObject tile, Vector2Int gridSize)
        {
            ClearGrid();
            Vector2 tileSize = DetermineTileSize(tile.GetComponent<MeshFilter>().sharedMesh.bounds);
            Vector3 position = transform.position;

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    position.x = transform.position.x + 1 * x;
                    position.z = transform.position.z + 1 * y;

                    CreateTile(tile, position, new Vector2Int(x, y));
                }
            }
        }

        #endregion
    }
}