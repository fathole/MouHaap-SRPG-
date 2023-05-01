using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIMain;
using TMPro;

namespace HomeScene
{
    public class HomePageManager : MonoBehaviour
    {
        #region Declaration

        private UIMain.HomePage.HomePage homePage;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset homePageMoveInTimeline;
        [SerializeField] private PlayableAsset homePageMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            homePage = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIMain.HomePage.HomePage homePage)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.homePage = homePage;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            homePage.oDEStartGameButton.InitElement();
            homePage.uSEBackground.InitElement();
        }

        /* ----- Setup Element ----- */


        public void SetupUSEBackground()
        {
            homePage.uSEBackground.SetupElement();
        }

        public void SetupODEStartGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEStartGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEStartGameButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEContinueGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEContinueGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEContinueGame.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEQuitGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEQuitGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEQuitGameButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        /* ----- Timeline ----- */

        public void PlayHomePageMoveInTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(homePageMoveInTimeline, finishCallback);
        }

        public void PlayHomePageMoveOutTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(homePageMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}