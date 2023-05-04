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

        public ODEStartGameButton oDEStartGameButton;
        public ODEContinueGameButton oDEContinueGame;
        public ODEGameSettingButton oDEGameSettingButton;
        public ODEQuitGameButton oDEQuitGameButton;
        public ODESoloGameButton oDESoloGameButton;
        public ODEMultiplayerGameButton oDEMultiplayerGameButton;
        public ODEGameModeBackButton oDEGameModeBackButton;
        public USEBackground uSEBackground;

        #endregion
    }
}