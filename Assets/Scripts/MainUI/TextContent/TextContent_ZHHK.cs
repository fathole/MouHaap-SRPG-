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

            o_NewGameButton = new O_NewGameButton
            {
                text001 = "新的開始",
            };
        }
    }
}