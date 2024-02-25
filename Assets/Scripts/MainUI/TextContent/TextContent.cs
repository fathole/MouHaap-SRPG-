using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainUI
{
    public class TextContent : TextContentBase
    {
        public struct U_GameTitle
        {
            public string text001;  
        }

        public struct O_NewGameButton
        {
            public string text001;
        }

        public U_GameTitle u_GameTitle;
        public O_NewGameButton o_NewGameButton;
    }
}