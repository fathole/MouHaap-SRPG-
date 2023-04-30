using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.MiddlePopup
{
    public class ODESecondaryButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text contentText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            contentText001.text = "";

            // Init Action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MiddlePopup.ODESecondaryButton textContent, Action onPointerClickCallback)
        {
            // Setup FontAsset
            contentText001.font = fontAsset;

            // Setup TextContent
            contentText001.text = textContent.contentText001;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}