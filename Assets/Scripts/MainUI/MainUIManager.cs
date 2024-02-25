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
        public O_NewGameButton o_newGameButton;

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

            o_newGameButton.InitObject(O_NewGameButtonOnPointerClickCallback);
        }

        #endregion

        #region Function - Object

        public void O_NewGameButtonOnPointerClickCallback()
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name);
        }

        #endregion
    }
}