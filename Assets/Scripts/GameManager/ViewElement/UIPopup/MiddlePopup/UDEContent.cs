using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.MiddlePopup
{
    public class UDEContent : MonoBehaviour
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text viewportText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            viewportText001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MiddlePopup.UDEContent textContent)
        {
            // Setup FontAsset
            viewportText001.font = fontAsset;

            // Setup TextContent
            viewportText001.text = textContent.text001;
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}