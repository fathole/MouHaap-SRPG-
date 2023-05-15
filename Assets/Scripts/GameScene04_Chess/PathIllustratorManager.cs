using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessScene
{
    public class PathIllustratorManager : MonoBehaviour
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion

        #region Init Stage

        public void InitManager()
        {
            // Comment: Nothing Init
        }

        #endregion

        #region Setup Stage

        public void SetupManager()
        {
            // Comment: Nothing Setup
        }

        #endregion

        #region Main Function

        public void IllustratePath(Path path)
        {           
            foreach (Tile item in path.tileArray)
            {
                item.SetNotice(TileNoticeOption.Frontier);
            }
        }

        #endregion
    }
}