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
            homePage.oDEGalleryButton.InitElement();
            homePage.oDEIntroButton.InitElement();
            homePage.oDEMusicButton.InitElement();
            homePage.oDESentenceButton.InitElement();
            homePage.uDEHeader.InitElement();
            homePage.uSEBackground.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupODEGalleryButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEGalleryButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEGalleryButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEIntroButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEIntroButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEIntroButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEMusicButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEMusicButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEMusicButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODESentenceButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODESentenceButton textContent, Action onPointerClickCallback)
        {
            homePage.oDESentenceButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupUDEHeader(TMP_FontAsset fontAsset, TextContentBase.HomePage.UDEHeader textContent)
        {
            homePage.uDEHeader.SetupElement(fontAsset, textContent);
        }

        public void SetupUSEBackground()
        {
            homePage.uSEBackground.SetupElement();
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