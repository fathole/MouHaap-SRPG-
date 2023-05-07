using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class ODEBasicSettingHeaderRestoreButton : ClickableObjectBase
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Action onPointerClickCallback)
        {
            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}