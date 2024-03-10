using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MainUI
{
    public class O_SettingButton : Common_Button
    {
        #region Declaration

        [SerializeField] private TMP_Text text001;
            
        #endregion

        #region Function - Init

        public void InitObject(Action onPointerClickCallback)
        {
            // Init Text Font
            text001.font = MainUIManager.fontAsset;

            // Init Text Content
            text001.text = MainUIManager.textContent.o_SettingButton.text001;

            // Init Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion
    }
}