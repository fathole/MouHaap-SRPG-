using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class Chess : MonoBehaviour
    {
        public ChessData chessData;

        #region Init Stage

        public void InitChess()
        {
            // Comment: Nothing Init
        }

        #endregion

        #region Setup Stage

        public void SetupChess()
        {
            // Setup Tile
            if (chessData.chessTile != null)
            {
                FinalizePosition(chessData.chessTile);
                return;
            }

            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 50f, chessData.groundLayerMask))
            {
                FinalizePosition(hit.transform.GetComponent<Tile>());
                return;
            }

            Debug.LogError("<color=red>----- Unable To Find Chess Tile -----</color>");
        }

        #endregion

        #region Main Function

        private void FinalizePosition(Tile tile)
        {
            transform.position = tile.transform.position;
            chessData.chessTile = tile;
            chessData.isMoving = false;
            tile.occupied = true;
            tile.occupyingChess = this;
        }

        private IEnumerator MoveAlongPath(Path path)
        {
            const float minDistance = 0.05f;

            int currentStep = 0;
            int pathLength = path.tiles.Length - 1;
            Tile currentTile = path.tiles[0];
            float animationTime = 0f;

            while (currentStep <= pathLength)
            {
                yield return null;

                //Move towards the next step in the path until we are closer than MIN_DIST
                Vector3 nextTilePosition = path.tiles[currentStep].transform.position;

                float movementTime = animationTime / 0.5f;
                MoveAndRotate(currentTile.transform.position, nextTilePosition, movementTime);
                animationTime += Time.deltaTime;

                if (Vector3.Distance(transform.position, nextTilePosition) > minDistance)
                    continue;

                //Min dist has been reached, look to next step in path
                currentTile = path.tiles[currentStep];
                currentStep++;
                animationTime = 0f;
            }
        }

        private void MoveAndRotate(Vector3 origin, Vector3 destination, float duration)
        {
            transform.position = Vector3.Lerp(origin, destination, duration);
            transform.rotation = Quaternion.LookRotation(origin.DirectionTo(destination).Flat(), Vector3.up);
        }

        #endregion
    }
}