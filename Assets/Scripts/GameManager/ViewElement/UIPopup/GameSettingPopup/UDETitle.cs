using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class UDETitle : MonoBehaviour
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text text001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            text001.text = "";            
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.UDETitle textContent)
        {
            // Setup FontAsset
            text001.font = fontAsset;

            // Setup TextContent
            text001.text = textContent.text001;
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}