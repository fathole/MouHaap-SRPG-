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
                oDENormalModeButton = new HomePage.ODENormalModeButton
                {
                    text001 = "正常模式",
                },
                oDEHardModeButton = new HomePage.ODEHardModeButton
                {
                    text001 = "困難模式",
                },
                oDELegendModeButton = new HomePage.ODELegendModeButton
                {
                    text001 = "傳奇模式",
                },
                oDEDifficultyModeBackButton = new HomePage.ODEDifficultyModeBackButton
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

            /* ----- Large Popup ----- */

            #region Normal Mode Popup

            normalModePopup = new GameManager.TextContentBase.LargePopup
            {
                uDETitle = new GameManager.TextContentBase.LargePopup.UDETitle
                {
                    text001 = "普通模式",
                },
                uDEContent = new GameManager.TextContentBase.LargePopup.UDEContent
                {
                    text001 = "你確定選擇普通模式嗎？此模式較簡單，適合第一次遊玩或體驗劇情的玩家。\n遊戲一旦開始，便不能更改。",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.LargePopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
                oDESecondaryButton = new GameManager.TextContentBase.LargePopup.ODESecondaryButton
                {
                    contentText001 = "取消",
                },
            };

            #endregion

            #region Hard Mode Popup

            hardModePopup = new GameManager.TextContentBase.LargePopup
            {
                uDETitle = new GameManager.TextContentBase.LargePopup.UDETitle
                {
                    text001 = "困難模式",
                },
                uDEContent = new GameManager.TextContentBase.LargePopup.UDEContent
                {
                    text001 = "你確定選擇困難模式嗎？此模式較困難，適合喜歡挑戰的玩家。\n遊戲一旦開始，便不能更改。",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.LargePopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
                oDESecondaryButton = new GameManager.TextContentBase.LargePopup.ODESecondaryButton
                {
                    contentText001 = "取消",
                },
            };       

            #endregion

            #region Legend Mode Popup

            legendModePopup = new GameManager.TextContentBase.LargePopup
            {
                uDETitle = new GameManager.TextContentBase.LargePopup.UDETitle
                {
                    text001 = "傳奇模式",
                },
                uDEContent = new GameManager.TextContentBase.LargePopup.UDEContent
                {
                    text001 = "你確定選擇傳奇模式嗎？此模式極度困難，只能擁有一個存檔。\n當所有角色死亡時，存檔亦會消失。\n遊戲一旦開始，便不能更改。",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.LargePopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
                oDESecondaryButton = new GameManager.TextContentBase.LargePopup.ODESecondaryButton
                {
                    contentText001 = "取消",
                },
            };

            #endregion

            /* ----- Middle Popup ----- */

            #region Delete Save Popup

            deleteSavePopup = new GameManager.TextContentBase.MiddlePopup
            {
                uDETitle = new GameManager.TextContentBase.MiddlePopup.UDETitle
                {
                    text001 = "刪除存檔",
                },
                uDEContent = new GameManager.TextContentBase.MiddlePopup.UDEContent
                {
                    text001 = "是否確認刪除存檔？\n一旦刪除，將無法復原！",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.MiddlePopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
                oDESecondaryButton = new GameManager.TextContentBase.MiddlePopup.ODESecondaryButton
                {
                    contentText001 = "取消",
                },
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