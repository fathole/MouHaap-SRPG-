using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        #region Declaration

        public static GameManager instance;       

        #endregion

        #region Function - Unity Event

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            // Init Object
            // Load First Scene
        }

        #endregion        
        
        // Scene Management
        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            Debug.Log("--- GameManager: LoadSceneCoroutine: " + sceneName + " ---");

            // Create Async Operation To Load Scene
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // Wait The Async Operation Finished
            while (asyncOperation.isDone != true)
            {
                yield return null;
            }
        }

        private IEnumerator UnloadSceneCoroutine(string sceneName)
        {
            Debug.Log("--- GameManager: UnloadSceneCoroutine: " + sceneName + " ---");

            // Create Async Operation To Unload Scene
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            // Wait The Async Operation Finished
            while(asyncOperation.isDone != true)
            {
                yield return null;
            }
        }        
    }    
}