using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class ODEBasicSettingHeader : MonoBehaviour
    {
        #region Declaration

        [Header("Child")]
        [SerializeField] private ODEBasicSettingHeaderRestoreButton restoreButton;

        [Header("Text")]
        [SerializeField] private TMP_Text text001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Child
            restoreButton.InitElement();

            // Init Text
            text001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEBasicSettingHeader textContent, Action onRestoreButtonPointerClickCallback)
        {
            // Setup Font Asset
            text001.font = fontAsset;

            // Setup Text Content
            text001.text = textContent.text001;

            //Setup Child
            restoreButton.SetupElement(onRestoreButtonPointerClickCallback);
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}