using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MainUI
{
    public class MainUIManager : ModuleManagerBase
    {
        #region Declaration

        public static MainUIManager instance;        

        [Header("Object")]
        // MainMenu
        public Common_Button o_CreditsButton;
        public Common_Button o_LoadGameButton;
        public Common_Button o_NewGameButton;
        public Common_Button o_QuitGameButton;
        public Common_Button o_SettingButton;
        // Difficulty
        public Common_Button o_DifficultyBackButton;
        public Common_Button o_ExploreButton;        
        public Common_Button O_NormalButton;        
        public Common_Button O_HardButton;        
        public Common_Button O_HellButton;

        [Header("Group")]
        public GameObject g_MainMenu;
        public GameObject g_Difficulty;

        [Header("Popup")]
        public Popup_QuitGame popup_QuitGame;

        //[Header("Font And Text Content")]
        //[HideInInspector] public static TextContent textContent;

        #endregion

        #region Function - Unity Event

        private void Awake()
        {
            instance = this;
        }

        #endregion

        #region Function - Init

        public override void InitModule()
        {
            Debug.Log("--- MainUIManager: InitModule ---");            

            // Init Element
            InitElement();
        }

        private void InitElement()
        {
            #region Init - Object

            o_CreditsButton.InitObject(O_CreditsButtonOnPointerClickCallback);
            o_LoadGameButton.InitObject(O_LoadGameButtonOnPointerClickCallback);
            o_NewGameButton.InitObject(O_NewGameButtonOnPointerClickCallback);
            o_QuitGameButton.InitObject(O_QuitGameButtonOnPointerClickCallback);
            o_SettingButton.InitObject(O_SettingButtonOnPointerClickCallback);

            o_DifficultyBackButton.InitObject(O_DifficultyBackButtonOnPointerClickCallback);
            o_ExploreButton.InitObject(o_ExploreButtonOnPointerClickCallback);
            O_NormalButton.InitObject(O_NormalButtonOnPointerClickCallback);
            O_HardButton.InitObject(O_HardButtonOnPointerClickCallback);
            O_HellButton.InitObject(O_HellButtonOnPointerClickCallback);

            #endregion

            #region Init - Popup_QuitGame

            popup_QuitGame.InitView();
            popup_QuitGame.o_CrossButton.InitObject(QuitGamePopup_CloseButtonOnPointerClickCallback);
            popup_QuitGame.o_CancelButton.InitObject(QuitGamePopup_CancelButtonOnPointerClickCallback);
            popup_QuitGame.o_ConfirmButton.InitObject(QuitGamePopup_ConfirmButtonOnPointerClickCallback);

            #endregion
        }

        #endregion

        #region Function - Object

        // Main Menu
        public void O_CreditsButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

            // ToDo: Show Credit
        }

        public void O_LoadGameButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        public void O_NewGameButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

            g_MainMenu.gameObject.SetActive(false);
            g_Difficulty.gameObject.SetActive(true);            
        }

        public void O_QuitGameButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

            StartCoroutine(popup_QuitGame.ShowPopupCoroutine());
        }

        public void O_SettingButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        // Difficulty
        public void O_DifficultyBackButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

            g_MainMenu.gameObject.SetActive(true);
            g_Difficulty.gameObject.SetActive(false);            
        }

        public void o_ExploreButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        public void O_NormalButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        public void O_HardButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        public void O_HellButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        #region Function - Popup_QuitGame

        public void QuitGamePopup_CloseButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

            StartCoroutine(popup_QuitGame.ClosePopupCoroutine());
        }

        public void QuitGamePopup_ConfirmButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void QuitGamePopup_CancelButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);

            StartCoroutine(popup_QuitGame.ClosePopupCoroutine());
        }


        #endregion

        #endregion
    }
}