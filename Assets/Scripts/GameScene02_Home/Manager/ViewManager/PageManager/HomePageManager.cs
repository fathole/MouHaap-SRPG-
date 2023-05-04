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
            homePage.oDEContinueGame.InitElement();
            homePage.oDEGameSettingButton.InitElement();
            homePage.oDEQuitGameButton.InitElement();
            homePage.oDESoloGameButton.InitElement();
            homePage.oDEMultiplayerGameButton.InitElement();
            homePage.oDEGameModeBackButton.InitElement();
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

        public void SetupODEGameSettingButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEGameSettingButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEGameSettingButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEContinueGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEContinueGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEContinueGame.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEQuitGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEQuitGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEQuitGameButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODESoloGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODESoloGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDESoloGameButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEMultiplayerGameButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEMultiplayerGameButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEMultiplayerGameButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODEGameModeBackButton(TMP_FontAsset fontAsset, TextContentBase.HomePage.ODEGameModeBackButton textContent, Action onPointerClickCallback)
        {
            homePage.oDEGameModeBackButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        /* ----- Function ----- */

        public void SetActiveButtons(HomePageButtonsOption option)
        {
            homePage.mainMenuButtons.SetActive(option == HomePageButtonsOption.MainMenuButtons);
            homePage.gameModeButtons.SetActive(option == HomePageButtonsOption.GameModeButtons);
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