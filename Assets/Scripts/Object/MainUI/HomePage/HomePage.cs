using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainUI_HomePage;

namespace MainUI
{
    public class HomePage : PageBase
    {
        #region Declaration

        public O_NewGameButton o_NewGameButton;

        #endregion

        #region Function - Init

        public override void InitPage()
        {
            base.InitPage();

            // Init Element If Need
        }

        #endregion       

        #region Function - Fade Animation

        public override IEnumerator FadeInCoroutine()
        {            
            return base.FadeInCoroutine();
        }

        public override IEnumerator FadeOutCoroutine()
        {
            return base.FadeOutCoroutine();
        }

        #endregion
    }
}