using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene.UIMain.HomePage
{
    public class HomePage : MonoBehaviour
    {
        #region Declaration

        public GameObject mainMenuButtons;
        public GameObject gameModeButtons;
        public GameObject difficultyModeButtons;

        public ODEStartGameButton oDEStartGameButton;
        public ODEContinueGameButton oDEContinueGame;
        public ODEGameSettingButton oDEGameSettingButton;
        public ODEQuitGameButton oDEQuitGameButton;
        public ODESoloGameButton oDESoloGameButton;
        public ODEMultiplayerGameButton oDEMultiplayerGameButton;
        public ODEGameModeBackButton oDEGameModeBackButton;
        public ODENormalModeButton oDENormalModeButton;
        public ODEHardModeButton oDEHardModeButton;
        public ODELegendModeButton oDELegendModeButton;
        public ODEDifficultyModeBackButton oDEDifficultyModeBackButton;
        public USEBackground uSEBackground;

        #endregion
    }
}