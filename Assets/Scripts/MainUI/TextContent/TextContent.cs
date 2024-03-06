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

        public struct O_CreditsButton
        {
            public string text001;
        }

        public struct O_LoadGameButton
        {
            public string text001;
        }

        public struct O_NewGameButton
        {
            public string text001;
        }

        public struct O_QuitGameButton
        {
            public string text001;
        }

        public struct O_SettingButton
        {
            public string text001;
        }        

        public U_GameTitle u_GameTitle;
        public O_CreditsButton o_CreditsButton;
        public O_LoadGameButton o_LoadGameButton;
        public O_NewGameButton o_NewGameButton;
        public O_QuitGameButton o_QuitGameButton;
        public O_SettingButton o_SettingButton;
    }
}