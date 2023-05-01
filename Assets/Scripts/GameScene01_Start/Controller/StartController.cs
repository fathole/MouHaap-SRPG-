using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StartScene
{
    public class StartController : MonoBehaviour
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
            LogoPage = 1,
        }

        #endregion

        #region Declaration - Class

        private class LogoPageValue
        {
            public bool isUserInputProcessFinished = false;
        }

        #endregion

        #region Declaration - Variable

        [Header("MVC")]       
        public static StartController instance;
        private GameManager.GameManager gameManager = null;
        [SerializeField] private StartView view;

        [Header("Controller Manager")]
        [SerializeField] private TextManager textManager;

        [Header("Font and Text")]
        private TMP_FontAsset fontAsset = null;
        private TextContentBase textContent = null;

        [Header("Camera And Canvas")]
        private Camera mainCamera = null;
        private ScreenPropertiesData screenPropertiesData = null;

        [Header("Page Value")]
        private LogoPageValue logoPageValue = null;

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
        private StartSceneOperationValue operationValue = null;


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
                StartCoroutine( RunSceneMode(RunSceneModeFinishCallback));
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
            return PageOption.LogoPage;
        }

        private void GoToPage(PageOption nextPage)
        {
            previousPage = currentPage;
            currentPage = nextPage;

            switch (currentPage)
            {
                case PageOption.LogoPage:
                    StartCoroutine(LogoPage());
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

        #region Page Function - Logo Page

        private IEnumerator LogoPage()
        {
            Debug.Log("----- Home Page -----");

            // Enter process
            yield return StartCoroutine(LogoPageEnterProcess());

            // Move in process
            yield return StartCoroutine(LogoPageMoveInProcess());

            // Logo Animation Process
            yield return StartCoroutine(LogoPageLogoAnimationProcess());

            // Move out process
            yield return StartCoroutine(LogoPageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(LogoPageExitProcess());
        }

        /* ----- Home Page: Enter Process ----- */

        private IEnumerator LogoPageEnterProcess()
        {
            Debug.Log("----- Home Page: Enter Process -----");

            // Init Page Value
            LogoPageEnterProcessInitPageValue();

            // Init Elements
            LogoPageEnterProcessInitElements();

            // Setup Elements
            LogoPageEnterProcessSetupElements();

            yield return null;
        }

        private void LogoPageEnterProcessInitPageValue()
        {
            logoPageValue = new LogoPageValue();
        }

        private void LogoPageEnterProcessInitElements()
        {
            view.logoPageManager.InitElements();
        }

        private void LogoPageEnterProcessSetupElements()
        {

        }

        /* ----- Home Page: Move In Process ----- */

        private IEnumerator LogoPageMoveInProcess()
        {
            Debug.Log("----- Home Page: Move In Process -----");

            bool isLogoPageMoveInFinished = false;

            view.logoPageManager.PlayLogoPageMoveInTimeline(() => isLogoPageMoveInFinished = true);

            yield return new WaitUntil(() => isLogoPageMoveInFinished);
        }

        /* ----- Home Page: Move Out Process ----- */

        private IEnumerator LogoPageMoveOutProcess()
        {
            Debug.Log("----- Home Page: Move Out Process -----");

            bool isLogoPageMoveOutFinished = false;

            view.logoPageManager.PlayLogoPageMoveOutTimeline(() => isLogoPageMoveOutFinished = true);

            yield return new WaitUntil(() => isLogoPageMoveOutFinished);
        }

        /* ----- Home Page: Exit Process ----- */

        private IEnumerator LogoPageExitProcess()
        {
            Debug.Log("----- Home Page: Exit Process -----");

            isSceneFinished = true;
            nextScene = SceneOption.GameScene02_Home;

            yield return null;
        }

        private IEnumerator LogoPageLogoAnimationProcess()
        {
            Debug.Log("----- Home Page: Logo Animation Process -----");

            bool isLogoPageLogoAnimationFinished = false;

            view.logoPageManager.PlayLogoPageLogoAnimationTimeline(() => isLogoPageLogoAnimationFinished = true);

            yield return new WaitUntil(() => isLogoPageLogoAnimationFinished);
        }

        #endregion

        #endregion

        #region Game Manager Helper Function

        public void RunEnterSceneMode(StartSceneOperationValue operationValue)
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
    }
}