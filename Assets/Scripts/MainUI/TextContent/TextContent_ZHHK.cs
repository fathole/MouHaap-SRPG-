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
                text001 = "遊戲名稱",
            };

            o_CreditsButton = new O_CreditsButton
            {
                text001 = "人員名單",
            };

            o_LoadGameButton = new O_LoadGameButton
            {
                text001 = "載入遊戲",
            };

            o_NewGameButton = new O_NewGameButton
            {
                text001 = "新遊戲",
            };

            o_QuitGameButton = new O_QuitGameButton
            {
                text001 = "退出遊戲",
            };

            o_SettingButton = new O_SettingButton
            {
                text001 = "選項",
            };
        }
    }
}