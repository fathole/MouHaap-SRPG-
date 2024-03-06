using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainUI
{
    public class TextContent_ZHHK : TextContent
    {
        public TextContent_ZHHK()
        {
            u_GameTitle = new U_GameTitle
            {
                text001 = "�C���W��",
            };

            o_CreditsButton = new O_CreditsButton
            {
                text001 = "�H���W��",
            };

            o_LoadGameButton = new O_LoadGameButton
            {
                text001 = "���J�C��",
            };

            o_NewGameButton = new O_NewGameButton
            {
                text001 = "�s�C��",
            };

            o_QuitGameButton = new O_QuitGameButton
            {
                text001 = "�h�X�C��",
            };

            o_SettingButton = new O_SettingButton
            {
                text001 = "�ﶵ",
            };
        }
    }
}