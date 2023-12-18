using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGameManager
{
    public class MainGameManager : MonoBehaviour
    {
        #region Declaration

        public static MainGameManager instance;

        private SceneManagerBase currentSceneManager;
        private SceneOptions currentScene;
        
        [SerializeField] private FontManager fontManager;
        [SerializeField] private TextManager textManager;
        private TextContentBase textContent;

        #endregion

        #region Function - Init

        private IEnumerator InitManager()
        {
            // Init Manager
            fontManager.InitManager();
            textManager.InitManager();            

            // Get TextContent
            textContent = textManager.GetTextContent(DisplayLanguageOption.ZH_HK);

            // Get All Scene Text And Generate A Font Asset
            string allSceneTextContent = textManager.GetAllSceneTextContent(DisplayLanguageOption.ZH_HK);
            fontManager.GenerateFontAsset(FontOption.NotoSansCJK);            
            yield return StartCoroutine(fontManager.UpdateFontAssetTextContentCoroutine(Newtonsoft.Json.JsonConvert.SerializeObject(allSceneTextContent)));

            // Load First Scene
            yield return LoadSceneCoroutine(SceneOptions.MainUI);            
        }
        
        #endregion

        #region Function - Unity Event

        private void Awake()
        {
            Debug.Log("--- MainGameManager: Awake ---");

            instance = this;
        }

        private void Start()
        {
            Debug.Log("--- Main Game Manager: Start ---");
            StartCoroutine(InitManager());
        }

        private void Update()
        {
            // ToDo: 
        }

        #endregion

        #region Function - Load Scene Handle

        private IEnumerator LoadSceneCoroutine(SceneOptions sceneOption)
        {
            Debug.Log("--- MainGameManager: LoadSceneCoroutine: " + sceneOption.ToString() + " ---");

            // Update Current Scene
            currentScene = sceneOption;

            // Wait Fade In Animation Finished
            yield return FadeInCoroutine();

            // Load Scene By Scene Name
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneOption.ToString(), LoadSceneMode.Additive);
            
            // Wait Load Scene Finished
            while (asyncOperation.isDone != true)
            {
                yield return null;
            }

            // Get Current Scene Manager And Init
            currentSceneManager = GetSceneManager(currentScene);
            currentSceneManager.InitScene();            

            // Wait Fade Out Animation Finished
            yield return FadeOutCoroutine();

            // Init Current Scene
            currentSceneManager.InitScene();
        }

        private IEnumerator UnloadSceneCoroutine(SceneOptions sceneOption)
        {
            Debug.Log("--- MainGameManager: UnloadSceneCoroutine: " + sceneOption.ToString() + " ---");

            // Reset currentSceneManager
            currentSceneManager = null;

            // Unload Scene By Scene Name
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneOption.ToString());

            // Wait Unload Scene Finished
            while (asyncOperation.isDone != true)
            {
                yield return null;
            }
        }

        private SceneManagerBase GetSceneManager(SceneOptions sceneOption)
        {
            switch (sceneOption)
            {                
                case SceneOptions.MainUI:
                    return MainUIManager.instance;
                default:
                    Debug.LogError("Unexpected Case");
                    return null;
            }
        }

        #endregion

        #region Function - Fade Animation Handle

        private IEnumerator FadeInCoroutine()
        {
            Debug.Log("ToDo: Fade In Animation");
            yield return null;
        }

        private IEnumerator FadeOutCoroutine()
        {
            Debug.Log("ToDo: Fade Out Animation");
            yield return null;
        }

        #endregion
    }

    #region ToDO: Later

    public enum SceneOptions
    {
        Init,
        Splash,
        MainUI,
    }

    #endregion
}