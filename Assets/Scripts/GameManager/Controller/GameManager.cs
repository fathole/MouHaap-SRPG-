using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        #region Declaration        

        #region Declaration - Enum

        private enum GameManagerModeOption
        {
            None = 0,
            ConstructMode = 1,
            EnterSceneMode = 2,
            RunSceneMode = 3,
            ExitSceneMode = 4,
            QuitMode = 5,
        }

        #endregion

        #region Declaration - Class

        private class StartSceneValue
        {
            public StartScene.StartController controller = null;

            public bool isEnterSceneModeFinished = false;
            public bool isSceneModeFinished = false;
            public bool isExitSceneModeFinished = false;
        }

        private class HomeSceneValue
        {
            public HomeScene.HomeController controller = null;

            public bool isEnterSceneModeFinished = false;
            public bool isSceneModeFinished = false;
            public bool isExitSceneModeFinished = false;
        }

        private class WorldSceneValue
        {
            public WorldScene.WorldController controller = null;

            public bool isEnterSceneModeFinished = false;
            public bool isSceneModeFinished = false;
            public bool isExitSceneModeFinished = false;
        }

        #endregion

        #region Declaration - Variable

        [Header("MVC")]
        [SerializeField] private GameManagerView view;

        [Header("Camera And Canvas")]
        [SerializeField] private Camera mainCamera;
        private ScreenPropertiesData screenPropertiesData;

        [Header("Audio Mixer")]
        [SerializeField] private AudioMixer audioMixer;

        [Header("Controller Manager")]
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private TextManager textManager;
        [SerializeField] private FontManager fontManager;
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private LocalDataManager localDataManager;

        [Header("Font And Text")]
        private TMP_FontAsset fontAsset;
        private TextContentBase textContent;

        [Header("Scene Value")]
        private StartSceneValue startSceneValue;
        private HomeSceneValue homeSceneValue;
        private WorldSceneValue worldSceneValue;

        private GameManagerModeOption gameManagerModeOption = GameManagerModeOption.None;
        private SceneOption currentScene = SceneOption.None;
        private SceneOption previousScene = SceneOption.None;
        private SceneOption nextScene = SceneOption.None;

        private GameSettingData gameSettingData;

        private bool isLoadingOpened;
        private bool isLoadingClosed;

        #endregion

        #endregion

        #region Init Stage        

        private void InitGameManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitControllerManager();

            view.InitView();
        }

        private void InitControllerManager()
        {
            cameraManager.InitManager();
            textManager.InitManager();
            fontManager.InitManager();
            audioManager.InitManager();
            localDataManager.InitManager();
        }

        #endregion

        #region Setup Stage

        private void SetupGameManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupControllerManager();

            SetupApplicationQuitCallback();

            view.SetupView(mainCamera);
        }

        private void SetupControllerManager()
        {
            cameraManager.SetupManager();
            textManager.SetupManager();
            fontManager.SetupManager();
            audioManager.SetupManager(audioMixer);
            localDataManager.SetupManager();
        }

        private void SetupApplicationQuitCallback()
        {
            Application.quitting += ApplicationQuitCallback;
        }

        #endregion

        #region Main Function        

        #region Main

        private void Start()
        {
            gameManagerModeOption = GameManagerModeOption.ConstructMode;
            Main();
        }

        private void Main()
        {
            if (gameManagerModeOption == GameManagerModeOption.ConstructMode)
            {
                StartCoroutine(ConstructMode(ConstructModeFinishCallback));
            }
            else if (gameManagerModeOption == GameManagerModeOption.EnterSceneMode)
            {
                currentScene = GetNextScene();
                StartCoroutine(EnterSceneMode(EnterSceneModeFinishCallback));
            }
            else if (gameManagerModeOption == GameManagerModeOption.RunSceneMode)
            {
                StartCoroutine(RunSceneMode(RunSceneModeFinishCallback));
            }
            else if (gameManagerModeOption == GameManagerModeOption.ExitSceneMode)
            {
                StartCoroutine(ExitSceneMode(ExitSceneModeFinishCallback));
            }
            else if (gameManagerModeOption == GameManagerModeOption.QuitMode)
            {
                StartCoroutine(QuitMode());
            }
        }

        #region Main - Construct Mode

        private IEnumerator ConstructMode(Action finishCallback)
        {
            Debug.Log("----- Game Manager: Construct Mode -----");

            InitGameManager();

            SetupGameManager();

            yield return ReadyGameManager();

            finishCallback?.Invoke();
        }

        private IEnumerator ReadyGameManager()
        {
            // Load Game Setting
            gameSettingData = localDataManager.LoadLocalData<GameSettingData>();

            // If Game Setting File Not Exist, Load Default
            if (gameSettingData == null)
            {
                gameSettingData = GameSettingData.DefaultSettingData();
                localDataManager.SaveLocalData(gameSettingData);
            }

            // ToDo: Adjust Camera
            mainCamera = cameraManager.AdjustCameraSetting(view.cameraScreen, view.targetScreen, view.deviceScreen);

            // Setup Volume
            SetupGameVolume(gameSettingData.bGMVolume, gameSettingData.sFXVolume, gameSettingData.voiceOverVolume);

            // Setup TextContent
            textContent = textManager.GetTextContent(gameSettingData.displayLanguageOption);
            string allSceneTextContent = textManager.GetAllSceneTextContent(gameSettingData.displayLanguageOption);

            // Generate Font Asset
            fontManager.GenerateFontAsset(gameSettingData.displayLanguageOption);

            // Update Font Asset Text Content
            yield return StartCoroutine(fontManager.UpdateFontAssetTextContent(Newtonsoft.Json.JsonConvert.SerializeObject(allSceneTextContent)));

            // Get Font Asset           
            fontAsset = fontManager.GetFontAsset();

            // Get CanvasSetupData
            screenPropertiesData = GetScreenPropertiesData();

            yield return null;
        }

        private void ConstructModeFinishCallback()
        {
            gameManagerModeOption = GameManagerModeOption.EnterSceneMode;
            Main();
        }

        private void SetupGameVolume(float bGMVolume, float sFXVolume, float voiceOverVolume)
        {
            audioManager.SetBGMVolume(bGMVolume);
            audioManager.SetSFXVolume(sFXVolume);
            audioManager.SetVoiceOverVolume(voiceOverVolume);
        }

        private ScreenPropertiesData GetScreenPropertiesData()
        {
            ScreenPropertiesData canvasSetupData = new ScreenPropertiesData();
            canvasSetupData.cameraScreen = view.cameraScreen;
            canvasSetupData.deviceScreen = view.deviceScreen;
            canvasSetupData.targetScreen = view.targetScreen;

            return canvasSetupData;
        }

        #endregion

        #region Main - Enter Scene Mode

        private IEnumerator EnterSceneMode(Action finishCallback)
        {
            Debug.Log("----- Game Manager: Enter Scene Mode -----");

            switch (currentScene)
            {
                case SceneOption.GameScene01_Start:
                    yield return EnterStartSceneProcess();
                    break;
                case SceneOption.GameScene02_Home:
                    yield return EnterHomeSceneProcess();
                    break;
                case SceneOption.GameScene03_World:
                    yield return EnterWorldSceneProcess();
                    break;
                default:
                    Debug.LogError("<color=red>----- Scene: " + currentScene + ", Not Found -----</color>");
                    yield return null;
                    break;
            }

            finishCallback?.Invoke();
        }

        private IEnumerator LoadScene(SceneOption sceneOption)
        {
            // Get Scene Name
            string sceneName = sceneOption.ToString();

            // Load Scene By Scene Name
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // Wait Until Scene Loaded
            while (asyncOperation.isDone != true)
            {
                yield return null;
            }

            // Set Active Scene
            Scene scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(scene);
        }

        private void EnterSceneModeFinishCallback()
        {
            gameManagerModeOption = GameManagerModeOption.RunSceneMode;
            Main();
        }

        private SceneOption GetNextScene()
        {
            // Update Previous Scene
            previousScene = currentScene;

            // Return Next Scene
            if (nextScene == SceneOption.None)
            {
                return SceneOption.GameScene01_Start;
            }
            else
            {
                return nextScene;
            }
        }

        /* ----- Loading ----- */

        private IEnumerator EnterSceneProcessCloseLoading()
        {
            if (isLoadingClosed != true)
            {
                CloseLoadingPopup(() => { isLoadingClosed = true; });
                yield return new WaitUntil(() => isLoadingClosed == true);
            }
            else
            {
                yield return null;
            }
        }

        /* ----- Start Scene ----- */

        private IEnumerator EnterStartSceneProcess()
        {
            Debug.Log("----- Game Manager: Enter Scene Mode: Enter Start Scene -----");

            // Init Scene Value
            startSceneValue = new StartSceneValue();

            // Load Scene
            yield return LoadScene(currentScene);

            // Get Scene Controller
            startSceneValue.controller = StartScene.StartController.instance;

            // Generate Scene Operation Value
            StartSceneOperationValue startSceneOperationValue = EnterStartSceneProcessGenerateStartSceneOperationValue();

            // Setup Scene
            startSceneValue.controller.RunEnterSceneMode(startSceneOperationValue);
            yield return new WaitUntil(() => startSceneValue.isEnterSceneModeFinished == true);

            // Release Ram
            GC.Collect();
        }

        private StartSceneOperationValue EnterStartSceneProcessGenerateStartSceneOperationValue()
        {
            // Init operation value
            StartSceneOperationValue operationValue = new StartSceneOperationValue();

            // Setup Operation Calue
            operationValue.gameManager = this;
            operationValue.mainCamera = mainCamera;
            operationValue.screenPropertiesData = screenPropertiesData;
            operationValue.fontAsset = fontAsset;
            operationValue.onEnterSceneModeFinishedCallback = () => { startSceneValue.isEnterSceneModeFinished = true; };
            operationValue.onRunSceneModeFinishedCallback = () => { startSceneValue.isSceneModeFinished = true; };
            operationValue.onExitSceneModeFinishedCallback = (nextSceneOption) => { nextScene = nextSceneOption; startSceneValue.isExitSceneModeFinished = true; };

            // Return Operation Value
            return operationValue;
        }

        /* ----- Home Scene ----- */

        private IEnumerator EnterHomeSceneProcess()
        {
            Debug.Log("----- Game Manager: Enter Scene Mode: Enter Home Scene -----");

            // Init Scene Value
            homeSceneValue = new HomeSceneValue();

            // Load Scene
            yield return LoadScene(currentScene);

            // Get Scene Controller
            homeSceneValue.controller = HomeScene.HomeController.instance;

            // Generate Scene Operation Value
            HomeSceneOperationValue homeSceneOperationValue = EnterHomeSceneProcessGenerateHomeSceneOperationValue();

            // Setup Scene
            homeSceneValue.controller.RunEnterSceneMode(homeSceneOperationValue);
            yield return new WaitUntil(() => homeSceneValue.isEnterSceneModeFinished == true);

            // Release Ram
            GC.Collect();

            // Close Loading
            yield return EnterSceneProcessCloseLoading();
        }

        private HomeSceneOperationValue EnterHomeSceneProcessGenerateHomeSceneOperationValue()
        {
            // Init operation value
            HomeSceneOperationValue operationValue = new HomeSceneOperationValue();

            // Setup Operation Calue
            operationValue.gameManager = this;
            operationValue.mainCamera = mainCamera;
            operationValue.screenPropertiesData = screenPropertiesData;
            operationValue.fontAsset = fontAsset;
            operationValue.onEnterSceneModeFinishedCallback = () => { homeSceneValue.isEnterSceneModeFinished = true; };
            operationValue.onRunSceneModeFinishedCallback = () => { homeSceneValue.isSceneModeFinished = true; };
            operationValue.onExitSceneModeFinishedCallback = (nextSceneOption) => { nextScene = nextSceneOption; homeSceneValue.isExitSceneModeFinished = true; };

            // Return Operation Value
            return operationValue;
        }

        /* ----- World Scene ----- */

        private IEnumerator EnterWorldSceneProcess()
        {
            Debug.Log("----- Game Manager: Enter Scene Mode: Enter World Scene -----");

            // Init Scene Value
            worldSceneValue = new WorldSceneValue();

            // Load Scene
            yield return LoadScene(currentScene);

            // Get Scene Controller
            worldSceneValue.controller = WorldScene.WorldController.instance;

            // Generate Scene Operation Value
            WorldSceneOperationValue worldSceneOperationValue = EnterWorldSceneProcessGenerateWorldSceneOperationValue();

            // Setup Scene
            worldSceneValue.controller.RunEnterSceneMode(worldSceneOperationValue);
            yield return new WaitUntil(() => worldSceneValue.isEnterSceneModeFinished == true);

            // Release Ram
            GC.Collect();

            // Close Loading
            yield return EnterSceneProcessCloseLoading();
        }

        private WorldSceneOperationValue EnterWorldSceneProcessGenerateWorldSceneOperationValue()
        {
            // Init operation value
            WorldSceneOperationValue operationValue = new WorldSceneOperationValue();

            // Setup Operation Calue
            operationValue.gameManager = this;
            operationValue.mainCamera = mainCamera;
            operationValue.screenPropertiesData = screenPropertiesData;
            operationValue.fontAsset = fontAsset;
            operationValue.onEnterSceneModeFinishedCallback = () => { worldSceneValue.isEnterSceneModeFinished = true; };
            operationValue.onRunSceneModeFinishedCallback = () => { worldSceneValue.isSceneModeFinished = true; };
            operationValue.onExitSceneModeFinishedCallback = (nextSceneOption) => { nextScene = nextSceneOption; worldSceneValue.isExitSceneModeFinished = true; };

            // Return Operation Value
            return operationValue;
        }

        #endregion

        #region Main - Scene Mode

        private IEnumerator RunSceneMode(Action finishCallback)
        {
            Debug.Log("----- Game Manager: Scene Mode -----");

            switch (currentScene)
            {
                case SceneOption.GameScene01_Start:
                    yield return RunStartSceneProcess();
                    break;
                case SceneOption.GameScene02_Home:
                    yield return RunHomeSceneProcess();
                    break;
                case SceneOption.GameScene03_World:
                    yield return RunWorldSceneProcess();
                    break;
                default:
                    Debug.LogError("<color=red>----- Scene: " + currentScene + ", Not Found -----</color>");
                    yield return null;
                    break;
            }

            finishCallback?.Invoke();
        }

        private void RunSceneModeFinishCallback()
        {
            gameManagerModeOption = GameManagerModeOption.ExitSceneMode;
            Main();
        }

        /* ----- Start Scene ----- */

        private IEnumerator RunStartSceneProcess()
        {
            Debug.Log("----- Game Manager: Scene Mode: Run Start Scene -----");

            // Wait Scene Finished
            startSceneValue.controller.RunRunSceneMode();
            yield return new WaitUntil(() => startSceneValue.isSceneModeFinished == true);
        }

        /* ----- Home Scene ----- */

        private IEnumerator RunHomeSceneProcess()
        {
            Debug.Log("----- Game Manager: Scene Mode: Run Home Scene -----");

            // Wait Scene Finished
            homeSceneValue.controller.RunRunSceneMode();
            yield return new WaitUntil(() => homeSceneValue.isSceneModeFinished == true);
        }

        /* ----- World Scene ----- */

        private IEnumerator RunWorldSceneProcess()
        {
            Debug.Log("----- Game Manager: Scene Mode: Run World Scene -----");

            // Wait Scene Finished
            worldSceneValue.controller.RunRunSceneMode();
            yield return new WaitUntil(() => worldSceneValue.isSceneModeFinished == true);
        }

        #endregion

        #region Main - ExitSceneMode

        private IEnumerator ExitSceneMode(Action finishCallback)
        {
            Debug.Log("----- Game Manager: Exit Scene Mode -----");

            switch (currentScene)
            {
                case SceneOption.GameScene01_Start:
                    yield return ExitStartSceneProcess();
                    break;
                case SceneOption.GameScene02_Home:
                    yield return ExitHomeSceneProcess();
                    break;
                default:
                    Debug.LogError("<color=red>----- Scene: " + currentScene + ", Not Found -----</color>");
                    yield return null;
                    break;
            }

            finishCallback?.Invoke();
        }

        private IEnumerator UnloadScene(SceneOption sceneOption)
        {
            // Get Scene Name
            string sceneName = sceneOption.ToString();

            // Unload Scene By Scene Name
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            // Wait Until Scene Unload
            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            // Unload Unused Assets In Scene (Release Ram)
            Resources.UnloadUnusedAssets();
        }

        private void ExitSceneModeFinishCallback()
        {
            gameManagerModeOption = GameManagerModeOption.EnterSceneMode;
            Main();
        }

        /* ----- Loading ----- */

        private IEnumerator ExitSceneProcessOpenLoading()
        {
            if (isLoadingOpened != true)
            {                
                OpenLoadingPopup(() => { isLoadingOpened = true; });                
                yield return new WaitUntil(() => isLoadingOpened == true);
            }
            else
            {
                yield return null;
            }
        }

        /* ----- Start Scene ----- */

        private IEnumerator ExitStartSceneProcess()
        {
            Debug.Log("----- Game Manager: Exit Scene Mode: Exit Start Scene -----");

            // Open Loading
            yield return ExitSceneProcessOpenLoading();

            // Wait Scene Exit Finished
            startSceneValue.controller.RunExitSceneMode();
            yield return new WaitUntil(() => startSceneValue.isExitSceneModeFinished == true);

            // Unload Scene
            yield return UnloadScene(currentScene);
        }

        /* ----- Home Scene ----- */

        private IEnumerator ExitHomeSceneProcess()
        {
            Debug.Log("----- Game Manager: Exit Scene Mode: Exit Home Scene -----");

            // Open Loading
            yield return ExitSceneProcessOpenLoading();

            // Wait Scene Exit Finished
            homeSceneValue.controller.RunExitSceneMode();
            yield return new WaitUntil(() => homeSceneValue.isExitSceneModeFinished == true);

            // Unload Scene
            yield return UnloadScene(currentScene);
        }

        /* ----- World Scene ----- */

        private IEnumerator ExitWorldSceneProcess()
        {
            Debug.Log("----- Game Manager: Exit Scene Mode: Exit World Scene -----");

            // Open Loading
            yield return ExitSceneProcessOpenLoading();

            // Wait Scene Exit Finished
            worldSceneValue.controller.RunExitSceneMode();
            yield return new WaitUntil(() => worldSceneValue.isExitSceneModeFinished == true);

            // Unload Scene
            yield return UnloadScene(currentScene);
        }

        #endregion

        #region Main - Quit Mode

        private IEnumerator QuitMode()
        {
            Debug.Log("----- Game Manager: Quit Mode -----");

            yield return null;
        }

        private void ApplicationQuitCallback()
        {

            // ToDo: Application Quit Function
        }

        #endregion

        #endregion

        #endregion

        #region Scene Support Function

        public DisplayLanguageOption GetDisplayLanguageOption()
        {
            return gameSettingData.displayLanguageOption;
        }

        /* ----- Popup Function ----- */

        public void OpenLoadingPopup(Action onAnimationFinishCallback)
        {
            // Init Element
            view.loadingPopupManager.InitElements();

            // Setup Element
            view.loadingPopupManager.SetupUDETitle(fontAsset, textContent.loadingPopup.uDETitle);
            view.loadingPopupManager.SetupUSEBackground();

            // Move In Popup
            view.loadingPopupManager.PlayLoadingPopupMoveInTimeline(onAnimationFinishCallback);
        }

        public void CloseLoadingPopup(Action onAnimationFinishCallback)
        {
            view.loadingPopupManager.PlayLoadingPopupMoveOutTimeline(onAnimationFinishCallback);
        }

        public void OpenLargePopup(string popupName, TMP_FontAsset fontAsset, TextContentBase.LargePopup textContent, Action onPrimaryButtonPointerClickCallback, Action onSecondaryButtonPointerClickCallback, Action onAnimationFinishCallback)
        {
            view.largePopupManager.OpenPopup(popupName, fontAsset, textContent, onPrimaryButtonPointerClickCallback, onSecondaryButtonPointerClickCallback, onAnimationFinishCallback);
        }

        public void OpenMiddlePopup(string popupName, TMP_FontAsset fontAsset, TextContentBase.MiddlePopup textContent, Action onPrimaryButtonPointerClickCallback, Action onSecondaryButtonPointerClickCallback, Action onAnimationFinishCallback)
        {
            view.middlePopupManager.OpenPopup(popupName, fontAsset, textContent, onPrimaryButtonPointerClickCallback, onSecondaryButtonPointerClickCallback, onAnimationFinishCallback);
        }

        public void OpenSmallPopup(string popupName, TMP_FontAsset fontAsset, TextContentBase.SmallPopup textContent, Action onPrimaryButtonPointerClickCallback, Action onSecondaryButtonPointerClickCallback, Action onAnimationFinishCallback)
        {
            view.smallPopupManager.OpenPopup(popupName, fontAsset, textContent, onPrimaryButtonPointerClickCallback, onSecondaryButtonPointerClickCallback, onAnimationFinishCallback);
        }

        public void CloseLargePopup(string popupName, Action onAnimationFinishCallback)
        {
            view.largePopupManager.ClosePopup(popupName, onAnimationFinishCallback);
        }

        public void CloseMiddlePopup(string popupName, Action onAnimationFinishCallback)
        {
            view.middlePopupManager.ClosePopup(popupName, onAnimationFinishCallback);
        }

        public void CloseSmallPopup(string popupName, Action onAnimationFinishCallback)
        {
            view.smallPopupManager.ClosePopup(popupName, onAnimationFinishCallback);
        }

        #endregion
    }
}