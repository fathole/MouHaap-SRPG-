using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        #region Declaration

        public static GameManager instance;

        #endregion

        #region Function - Unity Event

        private void Start()
        {
            instance = this;
            
        }

        #endregion
    }
}