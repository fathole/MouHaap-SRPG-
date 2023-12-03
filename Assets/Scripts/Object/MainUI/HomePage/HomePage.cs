using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MainUI_HomePage;

namespace MainUI
{
    public class HomePage : PageBase
    {
        #region Declaration

        [Header("Object")]
        public Common_Button o_NewGameButton;
        public Common_Button o_LoadGameButton;
        public Common_Button o_ExitGameButton;

        public Common_Button o_StoryModeButton;
        public Common_Button o_ChallengeModeButton;
        public Common_Button o_RealisticModeButton;
        public Common_Button o_GameModeBackButton;

        [Header("Unit")]
        public GameObject mainButtonList;
        public GameObject gameModeButtonList;

        #endregion

        #region Function - Init

        public override void InitPage()
        {
            base.InitPage();

            // Init Element If Need
        }

        #endregion       

        #region Function - Fade Animation

        public override IEnumerator FadeInCoroutine()
        {            
            return base.FadeInCoroutine();
        }

        public override IEnumerator FadeOutCoroutine()
        {
            return base.FadeOutCoroutine();
        }

        #endregion

        #region Function 

        public void ShowMainButtonList()
        {
            mainButtonList.SetActive(true);
            gameModeButtonList.SetActive(false);
        }

        public void ShowGameModeButtonList()
        {
            mainButtonList.SetActive(false);
            gameModeButtonList.SetActive(true);
        }

        #endregion
    }
}