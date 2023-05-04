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
                    text001 = "新的旅程",
                },
                oDEContinueGameButton = new HomePage.ODEContinueGameButton
                {
                    text001 = "繼續遊戲",
                },
                oDEGameSettingButton = new HomePage.ODEGameSettingButton
                {
                    text001 = "遊戲選項",
                },
                oDEQuitGameButton = new HomePage.ODEQuitGameButton
                {
                    text001 = "退出遊戲",
                },
                oDESoloGameButton = new HomePage.ODESoloGameButton
                {
                    text001 = "單人遊戲",
                },
                oDEMultiplayerGameButton = new HomePage.ODEMultiplayerGameButton
                {
                    text001 = "多人遊戲",
                },
                oDEGameModeBackButton = new HomePage.ODEGameModeBackButton
                {
                    text001 = "返回",
                },
            };

            #endregion

            /* ----- Scene Popup ----- */

            #region Load Game Popup

            loadGamePopup = new LoadGamePopup
            {
                uDETitle = new LoadGamePopup.UDETitle
                {
                    text001 = "讀取存檔",
                },
                oDESaveFileScrollViewSaveButton = new LoadGamePopup.ODESaveFileScrollViewSaveButton
                {
                    saveNameText001 = "{0}",
                    gameTimeHeaderText001 = "時間",
                    gameTimeContentText001 = "{0}",
                    saveDateHeaderText001 = "日期",
                    saveDateContentText001 = "{0}",
                    gameVersionHeaderText001 = "版本",
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
                    text001 = "確定離開遊戲？",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
                oDESecondaryButton = new GameManager.TextContentBase.SmallPopup.ODESecondaryButton
                {
                    contentText001 = "取消",
                },
            };

            #endregion

            #region Coming Soon Popup

            comingSoonPopup = new GameManager.TextContentBase.SmallPopup
            {
                uDETitle = new GameManager.TextContentBase.SmallPopup.UDETitle
                {
                    text001 = "尚未開放！"
                },
                oDEPrimaryButton = new GameManager.TextContentBase.SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },                
            };

            #endregion

        }
    }
}