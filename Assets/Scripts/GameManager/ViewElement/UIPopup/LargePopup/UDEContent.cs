using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameManager.UIPopup.LargePopup
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

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.LargePopup.UDEContent textContent)
        {
            // Setup FontAsset
            viewportText001.font = fontAsset;

            // Setup TextContent
            viewportText001.text = textContent.text001;

            // Setup ScrollView
            GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}