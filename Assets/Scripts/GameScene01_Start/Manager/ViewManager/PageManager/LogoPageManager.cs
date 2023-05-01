using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StartScene.UIMain;
using TMPro;

namespace StartScene
{
    public class LogoPageManager : MonoBehaviour
    {
        #region Declaration

        private UIMain.LogoPage.LogoPage logoPage;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset logoPageMoveInTimeline;
        [SerializeField] private PlayableAsset logoPageMoveOutTimeline;
        [SerializeField] private PlayableAsset logoPageLogoAnimationTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            logoPage = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIMain.LogoPage.LogoPage logoPage)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.logoPage = logoPage;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            logoPage.uSEBackground.InitElement();
            logoPage.uSEName.InitElement();
            logoPage.uSEOutline.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupUSEBackground()
        {
            logoPage.uSEBackground.SetupElement();
        }

        public void SetupUSEName()
        {
            logoPage.uSEName.SetupElement();
        }

        public void SetupUSEOutline()
        {
            logoPage.uSEOutline.SetupElement();
        }

        /* ----- Timeline ----- */

        public void PlayLogoPageMoveInTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(logoPageMoveInTimeline, finishCallback);
        }

        public void PlayLogoPageMoveOutTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(logoPageMoveOutTimeline, finishCallback);
        }

        public void PlayLogoPageLogoAnimationTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(logoPageLogoAnimationTimeline, finishCallback);
        }

        #endregion
    }
}