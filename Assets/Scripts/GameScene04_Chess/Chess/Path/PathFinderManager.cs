using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class PathFinderManager : MonoBehaviour
    {
        #region Declaration

         private LayerMask tileLayerMask;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            // Comment: Nothing Init
        }

        #endregion

        #region Setup Stage

        public void SetupManager(LayerMask tileLayerMask)
        {
            this.tileLayerMask = tileLayerMask;
        }

        #endregion

        #region Main Function

        // ToDo: Show Current Chess Attack Tail

        // ToDo: Show Current Chess Reach Tail

        public Path FindPath(Tile originTile, Tile destination)
        {
            List<Tile> openSet = new List<Tile>();
            List<Tile> closedSet = new List<Tile>();

            openSet.Add(originTile);
            originTile.costFromOrigin = 0;

            float tileDistance = originTile.GetComponent<MeshFilter>().sharedMesh.bounds.extents.z * 2;

            while (openSet.Count > 0)
            {
                // Get The Lower Cost Tile, Add To ClosedSet
                openSet.Sort((x, y) => x.totalCost.CompareTo(y.totalCost));
                Tile currentTile = openSet[0];

                openSet.Remove(currentTile);
                closedSet.Add(currentTile);

                // If Destination Reached
                if (currentTile == destination)
                {
                  // Return The Path
                    return PathBetween(destination, originTile);
                }

                foreach (Tile neighbour in NeighbourTiles(currentTile))
                {
                    if (closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    // Get The Cost To Neighbour
                    float costToNeighbour = currentTile.costFromOrigin + neighbour.terrainCost + tileDistance;
                    
                    if (costToNeighbour < neighbour.costFromOrigin || !openSet.Contains(neighbour))
                    {
                        neighbour.costFromOrigin = costToNeighbour;
                        neighbour.costToDestination = Vector3.Distance(destination.transform.position, neighbour.transform.position);
                        neighbour.parentTile = currentTile;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                        }
                }
            }

            return null;
        }

        private List<Tile> NeighbourTiles(Tile origin)
        {
            const float offset = 1.75f;
            List<Tile> tileList = new List<Tile>();
            Vector3 direction = Vector3.forward * (origin.GetComponent<MeshFilter>().sharedMesh.bounds.extents.x * offset);
            float rayLength = 4f;
            float rayHeightOffset = 1f;

            //Rotate a raycast in 90 degree steps and find all adjacent tiles
            for (int i = 0; i < 4; i++)
            {
                direction = Quaternion.Euler(0f, 90f, 0f) * direction;

                Vector3 aboveTilePos = (origin.transform.position + direction).With(y: origin.transform.position.y + rayHeightOffset);

                if (Physics.Raycast(aboveTilePos, Vector3.down, out RaycastHit hit, rayLength, tileLayerMask))
                {
                    Tile hitTile = hit.transform.GetComponent<Tile>();
                    if (hitTile.occupied == false)
                    {
                        tileList.Add(hitTile);
                    }
                }
            }

            //Additionally add connected tiles such as ladders
            if (origin.connectedTile != null)
            {
                tileList.Add(origin.connectedTile);
            }

            return tileList;
        }

        public Path PathBetween(Tile destination, Tile origin)
        {
            List<Tile> tileList = new List<Tile>();
            Tile current = destination;

            while (current != origin)
            {
                tileList.Add(current);
                if (current.parentTile != null)
                {
                    current = current.parentTile;
                }
                else
                {
                    break;
                }
            }

            tileList.Add(origin);
            tileList.Reverse();

            Path path = new Path();
            path.tileArray = tileList.ToArray();
            return path;
        }

        public void ResetPathFinder(Path path)
        {
            foreach (Tile tile in path.tileArray)
            {
                tile.SetNotice(TileNoticeOption.None);                
            }
        }

        #endregion
    }
}