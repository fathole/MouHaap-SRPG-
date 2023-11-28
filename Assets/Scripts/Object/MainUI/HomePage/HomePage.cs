using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainUI
{
    public class HomePage : PageBase
    {
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