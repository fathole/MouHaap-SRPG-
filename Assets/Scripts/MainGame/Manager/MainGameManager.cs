using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MainGame
{
    public class MainGameManager : MonoBehaviour
    {
        #region Declaration

        public static MainGameManager instance;

        [Header("Module")]
        [SerializeField] private ModuleDatas moduleDatas;
        private ModuleData currentModule;
        private ModuleManagerBase currentModuleManager;

        [Header("Setting")]
        [SerializeField] private LocalDataManager localDataManager;
        private GameSettingData gameSettingData;

        [Header("Text")]
        [SerializeField] private TextManager textManager;
        [SerializeField] private TextMeshProManager textMeshProManager;
        private TextContentBase textContent;
        private TMP_FontAsset fontAsset;

        [Header("Audio")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private UnityEngine.Audio.AudioMixer audioMixer;

        #endregion

        #region Function - Unity Event

        private void Awake()
        {
            Debug.Log("--- MainGameManager: Awake ---");

            instance = this;
        }

        private void Start()
        {
            Debug.Log("--- MainGameManager: Start ---");

            StartCoroutine(InitManagerCoroutine());
        }

        private void Update()
        {
            // Nothing Yet
        }

        #endregion

        #region Function - Init

        private IEnumerator InitManagerCoroutine()
        {
            #region Init Manager
            
            textManager.InitManager();
            textMeshProManager.InitManager();
            audioManager.InitManager(audioMixer);
            localDataManager.InitManager();

            #endregion

            #region Init Setting

            // Load Game Setting
            gameSettingData = localDataManager.LoadLocalData<GameSettingData>("GameSettingData", ".json");

            // If Game Setting File Not Exist, Load Default And Save One
            if (gameSettingData == null)
            {
                gameSettingData = GameSettingData.DefaultGameSettingData();
                localDataManager.SaveLocalData(gameSettingData, "GameSettingData", ".json");
            }

            #endregion

            #region Init Object

            #endregion

            #region Init Text And Font

            // Get Text Content
            textContent = textManager.GetTextContent(DisplayLanguageOption.ZH_HK);
            string allModuleTextContent = textManager.GetAllModuleContent(DisplayLanguageOption.ZH_HK);

            // Generate Font Asset
            yield return textMeshProManager.GenerateFontAssetCoroutine(FontOption.SourceHanSansHK, allModuleTextContent);

            // Get Font Asset           
            fontAsset = textMeshProManager.GetFontAsset();

            // Load First Module
            yield return LoadModuleCoroutine("MainUI");

            #endregion
        }

        #endregion

        #region Function - Private

        private IEnumerator LoadModuleCoroutine(string moduleName)
        {
            Debug.Log("--- MainGameManager: LoadModuleCoroutine: " + moduleName + " ---");

            // Update Curren Module
            currentModule = moduleDatas.moduleDataList.Find(x => x.moduleName == moduleName);

            // Get Loaded Scene List
            int loadedSceneCount = SceneManager.sceneCount;
            List<Scene> loadSceneList = new List<Scene>();
            for (int i = 0; i < loadedSceneCount; i++)
            {
                loadSceneList.Add(SceneManager.GetSceneAt(i));
            }

            // Unload All Scene Except Init
            foreach (Scene scene in loadSceneList)
            {
                if (scene.name != "Init")
                    yield return UnloadSceneCoroutine(scene.name);
            }

            // Release Ram After Unload
            Resources.UnloadUnusedAssets();

            // Get Curren Module Scene List
            List<string> currentModuleSceneNameList = currentModule.sceneNameList;

            // Load Module Scenes
            foreach (string sceneName in currentModuleSceneNameList)
            {
                yield return LoadSceneCoroutine(sceneName);
            }

            // Get Module Manager
            currentModuleManager = GetModuleManager(currentModule.managerName);

            // Init Module
            currentModuleManager.InitModule(fontAsset, GetModuleTextContent(currentModule));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            Debug.Log("--- MainGameManager: LoadSceneCoroutine: " + sceneName + " ---");

            // Create A Load Scene Async
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // Wait Async Finish
            while (asyncOperation.isDone != true)
            {
                yield return null;
            }
        }

        private IEnumerator UnloadSceneCoroutine(string sceneName)
        {
            Debug.Log("--- MainGameManager: UnloadSceneCoroutine: " + sceneName + " ---");

            // Create A Unload Scene Async
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            // Wait Async Finish
            while (asyncOperation.isDone != true)
            {
                yield return null;
            }
        }

        private ModuleManagerBase GetModuleManager(string managerName)
        {
            switch (managerName)
            {
                case "MainUIManager":
                    return MainUI.MainUIManager.instance;
                default:                   
                    Debug.LogError("Case Not Found");
                    return null;
            }
        }
        
        private TextContentBase GetModuleTextContent(ModuleData moduleData)
        {
            switch (moduleData.moduleName)
            {
                case "MainUI":
                    switch (gameSettingData.displayLanguage)
                    {
                        case DisplayLanguageOption.ZH_HK:
                            return new MainUI.TextContent_ZHHK();
                        default:
                            Debug.LogError("Case Not Found");
                            return null;
                    }
                default:
                    Debug.LogError("Case Not Found");
                    return null;
            }
        }

        #endregion

        #region Function - Public

        // ToDo:

        #endregion
    }
}