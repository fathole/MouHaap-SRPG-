using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManager.UIPopup;
using GameManager.UIPopup.MiddlePopup;
using TMPro;

namespace GameManager
{
    public class MiddlePopupManager : MonoBehaviour
    {
        #region Declaration

        private MiddlePopup middlePopupPrefab;
        private List<GameObject> popupList;

        [SerializeField] private Transform popupParent;
        [SerializeField] private PlayableAsset moveInTimeline;
        [SerializeField] private PlayableAsset moveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            middlePopupPrefab = null;
            popupList = new List<GameObject>();
        }

        #endregion

        #region Setup Stage

        public void SetupManager(MiddlePopup middlePopupPrefab)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.middlePopupPrefab = middlePopupPrefab;
            popupList = new List<GameObject>();
        }

        #endregion

        #region Main Function

        public void OpenPopup(string popupName, TMP_FontAsset fontAsset, TextContentBase.MiddlePopup textContent, Action onPrimaryButtonPointerClickCallback, Action onSecondaryButtonPointerClickCallback, Action onAnimationFinishCallback)
        {
            InstantiatePopup(popupName);
            InitPopup(popupName);
            SetupPopup(popupName, fontAsset, textContent, onPrimaryButtonPointerClickCallback, onSecondaryButtonPointerClickCallback);
            MoveInPopup(popupName, onAnimationFinishCallback);
        }

        private void InstantiatePopup(string popupName)
        {
            // Instantiate Popup
            GameObject popup = Instantiate(middlePopupPrefab, popupParent).gameObject;
            popup.name = popupName;

            // Add Popup To List
            popupList.Add(popup);
        }

        private void InitPopup(string popupName)
        {
            // Find Popup
            MiddlePopup popup = popupList.Find(x => x.name == popupName).GetComponent<MiddlePopup>();

            // Init Popup Element
            popup.uSEBackground.InitElement();
            popup.uDETitle.InitElement();
            popup.uDEContent.InitElement();
            popup.oDEPrimaryButton.InitElement();
            popup.oDESecondaryButton.InitElement();
        }

        private void SetupPopup(string popupName, TMP_FontAsset fontAsset, TextContentBase.MiddlePopup textContent, Action onPrimaryButtonPointerClickCallback, Action onSecondaryButtonPointerClickCallback)
        {
            // Find Popup
            MiddlePopup popup = popupList.Find(x => x.name == popupName).GetComponent<MiddlePopup>();

            // Setup Popup Element
            popup.uSEBackground.SetupElement();
            popup.uDETitle.SetupElement(fontAsset, textContent.uDETitle);
            popup.uDEContent.SetupElement(fontAsset, textContent.uDEContent);
            popup.oDEPrimaryButton.SetupElement(fontAsset, textContent.oDEPrimaryButton, onPrimaryButtonPointerClickCallback);
            
            if(onSecondaryButtonPointerClickCallback == null)
            {
                popup.oDESecondaryButton.gameObject.SetActive(false);
            }
            else
            {
                popup.oDESecondaryButton.gameObject.SetActive(true);
                popup.oDESecondaryButton.SetupElement(fontAsset, textContent.oDESecondaryButton, onSecondaryButtonPointerClickCallback);
            }
            
        }

        private void MoveInPopup(string popupName, Action onAnimationFinishCallback)
        {
            // Find Popup
            GameObject popup = popupList.Find(x => x.name == popupName);

            // Get Timeline That Need Update GameObject
            List<string> timelineTrackName = new List<string> { "Activation Track", "Animation Track" };

            // Play Timeline
            UIPopupManager.PlayTimeline(moveInTimeline, onAnimationFinishCallback, timelineTrackName, popup);
        }

        public void ClosePopup(string popupName, Action onAnimationFinishCallback)
        {
            // Find Popup
            MiddlePopup popup = popupList.Find(x => x.name == popupName).GetComponent<MiddlePopup>();

            BlockPopupInput(popupName);
            MoveOutPopup(popupName, () => { Destroy(popup.gameObject); popupList.Remove(popup.gameObject); onAnimationFinishCallback?.Invoke(); });
        }

        private void BlockPopupInput(string popupName)
        {
            // Get Popup Canvas Group
            CanvasGroup canvasGroup = popupList.Find(x => x.name == popupName).GetComponent<CanvasGroup>();

            // Set Interactable
            canvasGroup.blocksRaycasts = false;
        }

        private void MoveOutPopup(string popupName, Action onAnimationFinishCallback)
        {
            // Find Popup
            GameObject popup = popupList.Find(x => x.name == popupName);

            // Get Track That Need Update GameObject
            List<string> timelineTrackName = new List<string> { "Activation Track", "Animation Track" };

            // Play Timeline
            UIPopupManager.PlayTimeline(moveOutTimeline, onAnimationFinishCallback, timelineTrackName, popup);
        }       

        #endregion
    }
}