using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene
{
    public class TextContentZHHK : TextContentBase
    {
        public TextContentZHHK()
        {
            #region Home Page

            homePage = new HomePage
            {
                oDEStartGameButton = new HomePage.ODEStartGameButton
                {
                    text001 = "�s���ȵ{",
                },
                oDEContinueGameButton = new HomePage.ODEContinueGameButton
                {
                    text001 = "�~��C��",
                },
                oDEGameSettingButton = new HomePage.ODEGameSettingButton
                {
                    text001 = "�C���ﶵ",
                },
                oDEQuitGameButton = new HomePage.ODEQuitGameButton
                {
                    text001 = "�h�X�C��",
                },
                oDESoloGameButton = new HomePage.ODESoloGameButton
                {
                    text001 = "��H�C��",
                },
                oDEMultiplayerGameButton = new HomePage.ODEMultiplayerGameButton
                {
                    text001 = "�h�H�C��",
                },
                oDEGameModeBackButton = new HomePage.ODEGameModeBackButton
                {
                    text001 = "��^",
                },
            };

            #endregion

            /* ----- Scene Popup ----- */

            #region Load Game Popup

            loadGamePopup = new LoadGamePopup
            {
                uDETitle = new LoadGamePopup.UDETitle
                {
                    text001 = "Ū���s��",
                },
                oDESaveFileScrollViewSaveButton = new LoadGamePopup.ODESaveFileScrollViewSaveButton
                {
                    saveNameText001 = "{0}",
                    gameTimeHeaderText001 = "�ɶ�",
                    gameTimeContentText001 = "{0}",
                    saveDateHeaderText001 = "���",
                    saveDateContentText001 = "{0}",
                    gameVersionHeaderText001 = "����",
                    gameVersionContentText001 = "{0}",
                }
            };

            #endregion

            /* ----- Small Popup ----- */

            #region Quit Game Popup

            quitGamePopup = new GameManager.TextContentBase.SmallPopup
            {
                uDETitle = new GameManager.TextContentBase.SmallPopup.UDETitle
                {
                    text001 = "�T�w���}�C���H",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "�T�w",
                },
                oDESecondaryButton = new GameManager.TextContentBase.SmallPopup.ODESecondaryButton
                {
                    contentText001 = "����",
                },
            };

            #endregion

            #region Coming Soon Popup

            comingSoonPopup = new GameManager.TextContentBase.SmallPopup
            {
                uDETitle = new GameManager.TextContentBase.SmallPopup.UDETitle
                {
                    text001 = "�|���}��I"
                },
                oDEPrimaryButton = new GameManager.TextContentBase.SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "�T�w",
                },                
            };

            #endregion

        }
    }
}