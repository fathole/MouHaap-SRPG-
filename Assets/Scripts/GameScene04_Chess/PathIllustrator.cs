using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    [RequireComponent(typeof(LineRenderer))]
    public class PathIllustrator : MonoBehaviour
    {
        #region Declaration

        private const float lineHeightOffset = 0.33f;// Tile Height
        private LineRenderer line;

        #endregion        

        #region Main Function

        private void Start()
        {
            line = GetComponent<LineRenderer>();
        }

        public void IlliStratePath(Path path)
        {
            line.positionCount = path.tiles.Length;

            for(int i = 0; i < path.tiles.Length; i++)
            {
                Transform tileTransform = path.tiles[i].transform;
                line.SetPosition(i, tileTransform.position.With(y:tileTransform.position.y + lineHeightOffset));
            }
        }

        #endregion
    }
}