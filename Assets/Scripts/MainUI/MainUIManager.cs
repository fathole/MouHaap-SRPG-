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
        }

        #endregion

        #region Function - Object

        public void O_CreditsButtonOnPointerClickCallback() 
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
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
        }

        public void O_SettingButtonOnPointerClickCallback() 
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        #endregion
    }
}