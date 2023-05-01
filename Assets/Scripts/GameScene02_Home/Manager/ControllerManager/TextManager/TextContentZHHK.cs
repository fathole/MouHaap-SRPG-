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
                oDEQuitGameButton = new HomePage.ODEQuitGameButton
                {
                    text001 = "�h�X�C��",
                },
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

        }
    }
}