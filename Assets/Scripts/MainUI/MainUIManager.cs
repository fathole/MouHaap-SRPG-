using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MainUI
{
    public class MainUIManager : ModuleManagerBase 
    {
        #region Declaration

        public static MainUIManager instance;
        
        #endregion

        #region Function - Unity Event

        private void Awake()
        {
            instance = this;
        }

        #endregion

        #region Function - Init

        public override void InitModule(TMP_FontAsset fontAsset, TextContentBase textContent)
        {
            Debug.Log("--- MainUIManager: InitModule ---");

            // Init Base
            base.InitModule(fontAsset, textContent);
        }

        #endregion
    }
}