using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.HomePage
{
    public class ODEIntroButton : ClickableObjectBase
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

            // Init action
            onPointerClickCallback = null; 
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEIntroButton textContent, Action onPointerClickCallback)
        {
            // Setup Font Asset
            contentText001.font = fontAsset;

            // Setup Text Content
            contentText001.text = textContent.text001;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}