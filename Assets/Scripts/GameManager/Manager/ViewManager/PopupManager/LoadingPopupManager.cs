using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManager.UIPopup;
using TMPro;

namespace GameManager
{
    public class LoadingPopupManager : MonoBehaviour
    {
        #region Declaration

        private UIPopup.LoadingPopup.LoadingPopup loadingPopup;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset loadingPopupMoveInTimeline;
        [SerializeField] private PlayableAsset loadingPopupMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            loadingPopup = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIPopup.LoadingPopup.LoadingPopup loadingPopup)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.loadingPopup = loadingPopup;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            loadingPopup.uDETitle.InitElement();
            loadingPopup.uSEBackground.InitElement();
    }

        /* ----- Setup Element ----- */

        public void SetupUDETitle(TMP_FontAsset fontAsset, TextContentBase.LoadingPopup.UDETitle textContent)
        {
            loadingPopup.uDETitle.SetupElement(fontAsset, textContent);
        }

        public void SetupUSEBackground()
        {
            loadingPopup.uSEBackground.SetupElement();
        }

        /* ----- Timeline ----- */

        public void PlayLoadingPopupMoveInTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(loadingPopupMoveInTimeline, finishCallback);
        }

        public void PlayLoadingPopupMoveOutTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(loadingPopupMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}