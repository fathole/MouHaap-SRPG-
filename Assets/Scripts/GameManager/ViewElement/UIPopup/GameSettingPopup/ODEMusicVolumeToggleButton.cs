using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class ODEMusicVolumeToggleButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Child")]
        [SerializeField]
        private GameObject enableGameObject;
        [SerializeField]
        private GameObject disableGameObject;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Action onPointerClickCallback, bool isEnable)
        {
            // Setup action
            this.onPointerClickCallback = onPointerClickCallback;

            // Setup child
            SetIsEnable(isEnable);
        }

        #endregion

        #region Main Function

        public void SetIsEnable(bool isEnable)
        {
            enableGameObject.SetActive(isEnable == true);
            disableGameObject.SetActive(isEnable == false);
        }

        #endregion
    }
}