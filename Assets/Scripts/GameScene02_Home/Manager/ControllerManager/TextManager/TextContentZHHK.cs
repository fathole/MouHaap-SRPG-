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
                oDEQuitGameButton = new HomePage.ODEQuitGameButton
                {
                    text001 = "退出遊戲",
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

        }
    }
}