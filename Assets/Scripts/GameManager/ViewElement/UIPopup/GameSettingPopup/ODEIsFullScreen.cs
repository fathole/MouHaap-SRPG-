using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class ODEIsFullScreen : MonoBehaviour
    {
        #region Declaration

        [Header("Child")]
        [SerializeField] private ODEIsFullScreenToggleButton toggleButton;

        [Header("Text")]
        [SerializeField] private TMP_Text headerText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Child
            toggleButton.InitElement();

            // Init Text
            headerText001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEIsFullScreen textContent, bool isEnable, Action onToggleButtonPointerClickCallback)
        {
            // Setup Font Asset
            headerText001.font = fontAsset;

            // Setup Text Content
            headerText001.text = textContent.headerText001;

            //Setup Child
            toggleButton.SetupElement(onToggleButtonPointerClickCallback, isEnable);
        }

        #endregion

        #region Main Fuinction

        public void SetToggle(bool isEnable)
        {
            toggleButton.SetIsEnable(isEnable);
        }

        #endregion
    }
}