using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.HomePage
{
    public class UDEHeader : MonoBehaviour
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

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.HomePage.UDEHeader textContent)
        {
            // Setup Font Asset
            text001.font = fontAsset;

            // Setup Text Content
            text001.text = textContent.text001;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}