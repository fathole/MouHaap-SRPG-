using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainUI_HomePage;

namespace MainUI
{
    public class HomePage : PageBase
    {
        #region Declaration

        [Header("Object")]
        public O_NewGameButton o_NewGameButton;
        public O_LoadGameButton o_LoadGameButton;
        public O_ExitGameButton o_ExitGameButton;

        public O_StoryModeButton o_StoryModeButton;
        public O_ChallengeModeButton o_ChallengeModeButton;
        public O_RealisticModeButton o_RealisticModeButton;
        public O_GameModeBackButton o_GameModeBackButton;

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