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

        [Header("Unit")]
        public U_Background u_Background;
        public U_GameTitle u_gameTitle;

        [Header("Object")]
        public O_CreditsButton o_CreditsButton;
        public O_LoadGameButton o_LoadGameButton;
        public O_NewGameButton o_newGameButton;
        public O_QuitGameButton o_QuitGameButton;
        public O_SettingButton o_SettingButton;

        [Header("Popup")]
        public Popup_QuitGame popup_QuitGame;

        [Header("Font And Text Content")]
        [HideInInspector] public static TMP_FontAsset fontAsset;
        [HideInInspector] public static TextContent textContent;

        #endregion

        #region Function - Unity Event

        private void Awake()
        {
            instance = this;
        }

        #endregion

        #region Function - Init

        public override void InitModule(TMP_FontAsset fontAsset, TextContentBase textContent)
        {
            Debug.Log("--- MainUIManager: InitModule ---");

            // Init The Font Asset And Text Content
            MainUIManager.fontAsset = fontAsset;
            MainUIManager.textContent = (TextContent)textContent;

            // Init Element
            InitElement();
        }

        private void InitElement()
        {
            u_Background.InitObject();
            u_gameTitle.InitObject();

            o_CreditsButton.InitObject(O_CreditsButtonOnPointerClickCallback);
            o_LoadGameButton.InitObject(O_LoadGameButtonOnPointerClickCallback);
            o_newGameButton.InitObject(O_NewGameButtonOnPointerClickCallback);
            o_QuitGameButton.InitObject(O_QuitGameButtonOnPointerClickCallback);
            o_SettingButton.InitObject(O_SettingButtonOnPointerClickCallback);

            #region Init - Popup_QuitGame

            popup_QuitGame.InitView();
            popup_QuitGame.o_CrossButton.InitObject(QuitGamePopup_CloseButtonOnPointerClickCallback);

            #endregion
        }

        #endregion

        #region Function - Object

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