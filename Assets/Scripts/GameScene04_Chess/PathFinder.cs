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

        public Path FindPath(Tile originTial, Tile destination)
        {
            

            return null;
        }

    }
}