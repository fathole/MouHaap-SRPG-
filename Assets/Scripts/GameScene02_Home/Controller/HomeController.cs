using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene
{
    public class HomeController : MonoBehaviour
    {
        #region Declaration

        #region Declaration - Enum

        private enum ControllerModeOption
        {
            None = 0,
            EnterSceneMode = 1,
            RunSceneMode = 2,
            ExitSceneMode = 3,
        }

        private enum PageOption
        {
            None = 0,
            HomePage = 1,
            GalleryPage = 2,
            MusicPage = 3,
            SentencePage = 4,
            IntroPage = 5,
        }

        #endregion

        #region Declaration - Class

        private class HomePageValue
        {
            public bool isUserInputProcessFinished = false;

            public HomePageButtonsOption activeButtons = HomePageButtonsOption.MainMenuButtons;
        }

        #endregion

        #region Declaration - Variable

        [Header("MVC")]
        public static HomeController instance;
        private GameManager.GameManager gameManager = null;
        [SerializeField] private HomeView view;

        [Header("Controller Manager")]
        [SerializeField] private TextManager textManager;

        [Header("Font and Text")]
        private TMP_FontAsset fontAsset = null;
        private TextContentBase textContent = null;

        [Header("Camera And Canvas")]
        private Camera mainCamera = null;
        private ScreenPropertiesData screenPropertiesData = null;

        [Header("Page Value")]
        private HomePageValue homePageValue = null;

        [Header("Game Manager Callback Function")]
        public Action gameManagerOnEnterSceneModeFinishedCallback = null;
        public Action gameManagerOnRunSceneModeFinishedCallback = null;
        public Action<SceneOption> gameManagerOnExitSceneModeFinishedCallback = null;

        private SceneOption nextScene = SceneOption.None;

        private ControllerModeOption currentMode = ControllerModeOption.None;
        private PageOption currentPage = PageOption.None;
        private PageOption previousPage = PageOption.None;

        private bool isSceneFinished = false;

        // Won't Use, Get From GameManager.cs Update Variable
        private HomeSceneOperationValue operationValue = null;

        #endregion

        #endregion

        #region Init Stage

        private void Awake()
        {
            instance = this;
        }

        private void InitScene()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitController();

            view.InitView();
        }

        private void InitController()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitControllerManager();
        }

        private void InitControllerManager()
        {
            textManager.InitManager();
        }

        #endregion

        #region Setup Stage

        private void SetupScene()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupController();

            view.SetupView(mainCamera, screenPropertiesData);
        }

        private void SetupController()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupByOperationValue();

            SetupControllerManager();
        }

        private void SetupByOperationValue()
        {
            gameManager = operationValue.gameManager;
            mainCamera = operationValue.mainCamera;
            screenPropertiesData = operationValue.screenPropertiesData;
            fontAsset = operationValue.fontAsset;
            gameManagerOnEnterSceneModeFinishedCallback = operationValue.onEnterSceneModeFinishedCallback;
            gameManagerOnRunSceneModeFinishedCallback = operationValue.onRunSceneModeFinishedCallback;
            gameManagerOnExitSceneModeFinishedCallback = operationValue.onExitSceneModeFinishedCallback;
        }

        private void SetupControllerManager()
        {
            textManager.SetupManager();
        }

        #endregion

        #region Main Function

        private void Main()
        {
            if (currentMode == ControllerModeOption.EnterSceneMode)
            {
                StartCoroutine(EnterSceneMode(EnterSceneModeFinishCallback));
            }
            else if (currentMode == ControllerModeOption.RunSceneMode)
            {
                StartCoroutine(RunSceneMode(RunSceneModeFinishCallback));
            }
            else if (currentMode == ControllerModeOption.ExitSceneMode)
            {
                StartCoroutine(ExitSceneMode(ExitSceneModeFinishCallback));
            }
        }

        #region Main - Enter Scene Mode

        private IEnumerator EnterSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Enter Scene Mode -----");

            InitScene();

            SetupScene();

            ReadyScene();

            yield return null;

            finishCallback?.Invoke();
        }

        private void EnterSceneModeFinishCallback()
        {
            gameManagerOnEnterSceneModeFinishedCallback?.Invoke();
        }

        private void ReadyScene()
        {
            // Setup Text Content
            textContent = textManager.GetTextContent(gameManager.GetDisplayLanguageOption());
        }

        #endregion

        #region Main - Run Scene Mode

        private IEnumerator RunSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Run Scene Mode -----");

            // Get First Page
            currentPage = GetFirstPage();

            // Go To First Page
            GoToPage(currentPage);

            yield return new WaitUntil(() => isSceneFinished == true);

            finishCallback?.Invoke();
        }

        private void RunSceneModeFinishCallback()
        {
            gameManagerOnRunSceneModeFinishedCallback?.Invoke();
        }

        private PageOption GetFirstPage()
        {
            return PageOption.HomePage;
        }

        private void GoToPage(PageOption nextPage)
        {
            previousPage = currentPage;
            currentPage = nextPage;

            switch (currentPage)
            {
                case PageOption.HomePage:
                    StartCoroutine(HomePage());
                    break;
                default:
                    Debug.LogError("<color=red>----- Page Option: " + nextPage + ", Not Found -----</color>");
                    break;
            }
        }

        #endregion

        #region Main - Exit Scene Mode

        private IEnumerator ExitSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Exit Scene Mode -----");

            yield return null;

            finishCallback?.Invoke();
        }

        private void ExitSceneModeFinishCallback()
        {
            gameManagerOnExitSceneModeFinishedCallback?.Invoke(nextScene);
        }

        #endregion

        #region Page Function - Home Page

        private IEnumerator HomePage()
        {
            Debug.Log("----- Home Page -----");

            // Enter process
            yield return StartCoroutine(HomePageEnterProcess());

            // Move in process
            yield return StartCoroutine(HomePageMoveInProcess());

            // User input process
            Debug.Log("----- Home Page: User Response Process -----");
            yield return new WaitUntil(() => homePageValue.isUserInputProcessFinished == true);

            // Move out process
            yield return StartCoroutine(HomePageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(HomePageExitProcess());
        }

        /* ----- Home Page: Enter Process ----- */

        private IEnumerator HomePageEnterProcess()
        {
            Debug.Log("----- Home Page: Enter Process -----");

            // Init Page Value
            HomePageEnterProcessInitPageValue();

            // Init Elements
            HomePageEnterProcessInitElements();

            // Setup Elements
            HomePageEnterProcessSetupElements();

            yield return null;
        }

        private void HomePageEnterProcessInitPageValue()
        {
            homePageValue = new HomePageValue();
        }

        private void HomePageEnterProcessInitElements()
        {
            view.homePageManager.InitElements();
        }

        private void HomePageEnterProcessSetupElements()
        {
            view.homePageManager.SetupODEStartGameButton(fontAsset, textContent.homePage.oDEStartGameButton, HomePageODEStartGameButtonPointerClickCallback);
            view.homePageManager.SetupODEContinueGameButton(fontAsset, textContent.homePage.oDEContinueGameButton, HomePageODEContinueGameButtonPointerClickCallback);
            view.homePageManager.SetupODEGameSettingButton(fontAsset, textContent.homePage.oDEGameSettingButton, HomePageODEGameSettingButtonPointerClickCallback);
            view.homePageManager.SetupODEQuitGameButton(fontAsset, textContent.homePage.oDEQuitGameButton, HomePageODEQuitGameButtonPointerClickCallback);
            view.homePageManager.SetupODESoloGameButton(fontAsset, textContent.homePage.oDESoloGameButton, HomePageODESoloGameButtonPointerClickCallback);
            view.homePageManager.SetupODEMultiplayerGameButton(fontAsset, textContent.homePage.oDEMultiplayerGameButton, HomePageODEMultiplayerGameButtonPointerClickCallback);
            view.homePageManager.SetupODEGameModeBackButton(fontAsset, textContent.homePage.oDEGameModeBackButton, HomePageODEGameModeBackButtonPointerClickCallback);
            view.homePageManager.SetupUSEBackground();

            view.homePageManager.SetActiveButtons(homePageValue.activeButtons);
        }

        /* ----- Home Page: Move In Process ----- */

        private IEnumerator HomePageMoveInProcess()
        {
            Debug.Log("----- Home Page: Move In Process -----");

            bool isHomePageMoveInFinished = false;

            view.homePageManager.PlayHomePageMoveInTimeline(() => isHomePageMoveInFinished = true);

            yield return new WaitUntil(() => isHomePageMoveInFinished);
        }

        /* ----- Home Page: Move Out Process ----- */

        private IEnumerator HomePageMoveOutProcess()
        {
            Debug.Log("----- Home Page: Move Out Process -----");

            bool isHomePageMoveOutFinished = false;

            view.homePageManager.PlayHomePageMoveOutTimeline(() => isHomePageMoveOutFinished = true);

            yield return new WaitUntil(() => isHomePageMoveOutFinished);
        }

        /* ----- Home Page: Exit Process ----- */

        private IEnumerator HomePageExitProcess()
        {
            Debug.Log("----- Home Page: Exit Process -----");

            yield return null;
        }

        /* ----- Home Page: User Input Process (Page Callback Function)----- */

        private void HomePageODEStartGameButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                homePageValue.activeButtons = HomePageButtonsOption.GameModeButtons;
                view.homePageManager.SetActiveButtons(homePageValue.activeButtons);
            }
        }

        private void HomePageODEContinueGameButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                Debug.Log("Load Game Popup");
            }
        }

        private void HomePageODEGameSettingButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                Debug.Log("Game Setting Popup");
            }
        }

        private void HomePageODEQuitGameButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                gameManager.OpenSmallPopup("QuitGamePopup", fontAsset, textContent.quitGamePopup, HomePageQuitGamePopupPrimaryButtonPointerClickCallback, HomePageQuitGamePopupSecondaryButtonPointerClickCallback, null);
            }
        }

        private void HomePageODESoloGameButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                Debug.Log("Open Character Create Page Later");
            }
        }

        private void HomePageODEMultiplayerGameButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                gameManager.OpenSmallPopup("ComingSoonPopup", fontAsset, textContent.comingSoonPopup, HomePageComingSoonPopupPrimaryButtonPointerClickCallback, null, null);
            }
        }

        private void HomePageODEGameModeBackButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                homePageValue.activeButtons = HomePageButtonsOption.MainMenuButtons;
                view.homePageManager.SetActiveButtons(homePageValue.activeButtons);
            }
        }

        /* ----- Home Page: User Input Process (Popup Callback Function)----- */

        private void HomePageQuitGamePopupPrimaryButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }

        private void HomePageQuitGamePopupSecondaryButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            gameManager.CloseSmallPopup("QuitGamePopup", null);
        }

        private void HomePageComingSoonPopupPrimaryButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            gameManager.CloseSmallPopup("ComingSoonPopup", null);
        }

        #endregion

        #endregion

        #region Game Manager Helper Function

        public void RunEnterSceneMode(HomeSceneOperationValue operationValue)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Get Operation Value
            this.operationValue = operationValue;

            currentMode = ControllerModeOption.EnterSceneMode;
            Main();
        }

        public void RunExitSceneMode()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            currentMode = ControllerModeOption.ExitSceneMode;
            Main();
        }

        public void RunRunSceneMode()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            currentMode = ControllerModeOption.RunSceneMode;
            Main();
        }

        #endregion

        #region DEV Function

        public void DEVWorldSceneButtonPointerClickCallback()
        {
            nextScene = SceneOption.GameScene03_World;
            isSceneFinished = true;
        }

        #endregion
    }
}