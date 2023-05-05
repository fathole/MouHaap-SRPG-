using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIPopup;
using TMPro;

namespace HomeScene
{
    public class LoadGamePopupManager : MonoBehaviour
    {
        #region Declaration

        private UIPopup.LoadGamePopup.LoadGamePopup loadGamePopup;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset loadGamePopupMoveInTimeline;
        [SerializeField] private PlayableAsset loadGamePopupMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            loadGamePopup = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIPopup.LoadGamePopup.LoadGamePopup loadGamePopup)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.loadGamePopup = loadGamePopup;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            loadGamePopup.uDETitle.InitElement();
            loadGamePopup.uSEBackground.InitElement();
            loadGamePopup.oDESaveFileScrollView.InitElement();
            loadGamePopup.oSECrossButton.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupUDETitle(TMP_FontAsset fontAsset, TextContentBase.LoadGamePopup.UDETitle textContent)
        {
            loadGamePopup.uDETitle.SetupElement(fontAsset, textContent);
        }

        public void SetupUSEBackground()
        {
            loadGamePopup.uSEBackground.SetupElement();
        }

        public void SetupODESaveFileScrollView(TMP_FontAsset fontAsset, TextContentBase.LoadGamePopup.ODESaveFileScrollViewSaveButton textContent, List<SaveButtonData> saveButtonDataList, Action<string> onSaveButtonPointerClickCallback, Action<string> onSaveButtonCrossButtonPointerClickCallback)
        {
            loadGamePopup.oDESaveFileScrollView.SetupElement(fontAsset, textContent, saveButtonDataList, onSaveButtonPointerClickCallback, onSaveButtonCrossButtonPointerClickCallback);
        }

        public void SetupOSECrossButton(Action onPointerClickCallback)
        {
            loadGamePopup.oSECrossButton.SetupElement(onPointerClickCallback);
        }

        /* ----- Function ----- */

        public void DeleteSaveButton(string fileName)
        {
            loadGamePopup.oDESaveFileScrollView.DeleteSaveButton(fileName);
        }

        /* ----- Timeline ----- */

        public void PlayLoadGamePopupMoveInTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(loadGamePopupMoveInTimeline, finishCallback);
        }

        public void PlayLoadGamePopupMoveOutTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(loadGamePopupMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}