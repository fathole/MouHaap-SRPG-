using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    [RequireComponent(typeof(PathIllustrator))]
    public class PathFinder : MonoBehaviour
    {
        [SerializeField] private PathIllustrator pathIllustrator;
        [SerializeField] private LayerMask tileMask;
        private List<Tile> frontierList = new List<Tile>();

        // ToDo: Show Current Chess Attack Tail
        // ToDo: Show Current Chess Reach Tail
        
        public Path FindPath(Tile originTile, Tile destination)
        {
            ResetPathFinder();

            List<Tile> openSet = new List<Tile>();
            List<Tile> closedSet = new List<Tile>();

            openSet.Add(originTile);
            originTile.costFromOrigin = 0;

            float tileDistance = originTile.GetComponent<MeshFilter>().sharedMesh.bounds.extents.z * 2;

            while (openSet.Count > 0)
            {
                openSet.Sort((x, y) => x.totalCost.CompareTo(y.totalCost));
                Tile currentTile = openSet[0];

                openSet.Remove(currentTile);
                closedSet.Add(currentTile);

                //Destination reached
                if (currentTile == destination)
                {
                    frontierList = PathBetween(destination, originTile).tiles.ToList();
                    pathIllustrator.IllustrateFrontier(frontierList);
                    return PathBetween(destination, originTile);
                }

                foreach (Tile neighbour in NeighbourTiles(currentTile))
                {
                    if (closedSet.Contains(neighbour))
                    {
                        continue;
                    }

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
            const float HEXAGONAL_OFFSET = 1.75f;
            List<Tile> tiles = new List<Tile>();
            Vector3 direction = Vector3.forward * (origin.GetComponent<MeshFilter>().sharedMesh.bounds.extents.x * HEXAGONAL_OFFSET);
            float rayLength = 4f;
            float rayHeightOffset = 1f;

            //Rotate a raycast in 60 degree steps and find all adjacent tiles
            for (int i = 0; i < 6; i++)
            {
                direction = Quaternion.Euler(0f, 60f, 0f) * direction;

                Vector3 aboveTilePos = (origin.transform.position + direction).With(y: origin.transform.position.y + rayHeightOffset);

                if (Physics.Raycast(aboveTilePos, Vector3.down, out RaycastHit hit, rayLength, tileMask))
                {
                    Tile hitTile = hit.transform.GetComponent<Tile>();
                    if (hitTile.occupied == false)
                    {
                        tiles.Add(hitTile);
                    }
                }

                Debug.DrawRay(aboveTilePos, Vector3.down * rayLength, Color.blue);
            }

            //Additionally add connected tiles such as ladders
            if (origin.connectedTile != null)
            {
                tiles.Add(origin.connectedTile);
            }

            return tiles;
        }

        public Path PathBetween(Tile dest, Tile source)
        {
            Path path = MakePath(dest, source);
            //pathIllustrator.IllistratePath(path);
            return path;
        }

        private Path MakePath(Tile destination, Tile origin)
        {
            List<Tile> tiles = new List<Tile>();
            Tile current = destination;

            while (current != origin)
            {
                tiles.Add(current);
                if (current.parentTile != null)
                {
                    current = current.parentTile;
                }
                else
                {
                    break;
                }
            }

            tiles.Add(origin);
            tiles.Reverse();

            Path path = new Path();
            path.tiles = tiles.ToArray();

            return path;
        }

        public void ResetPathFinder()
        {
            foreach (Tile item in frontierList)
            {
                item.SetNotice(TileNoticeOption.None);                
            }

            frontierList.Clear();
        }
    }
}