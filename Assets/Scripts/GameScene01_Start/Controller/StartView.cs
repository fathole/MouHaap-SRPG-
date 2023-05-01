using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StartScene.UIMain;
using StartScene.UIPopup;

namespace StartScene
{
    public class StartView : MonoBehaviour
    {
        #region Declaration

        [Header("Sorting Layer Manager")]
        public UIMainManager uIMainManager;
        public UIPopupManager uIPopupManager;

        [Header("Page Manager")]
        public LogoPageManager logoPageManager;

        #endregion

        #region Init Stage

        public void InitView()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitSortingLayerManager();

            InitPageManager();

            InitPopupManager();
        }

        private void InitSortingLayerManager()
        {
            uIMainManager.InitManager();
            uIPopupManager.InitManager();
        }

        private void InitPageManager()
        {
            logoPageManager.InitManager();
        }

        private void InitPopupManager()
        {

        }

        #endregion

        #region Setup Stage

        public void SetupView(Camera mainCamera, ScreenPropertiesData screenPropertiesData)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupSortingLayerManager(mainCamera, screenPropertiesData);

            SetupPageManager();

            SetupPopupManager();
        }

        private void SetupSortingLayerManager(Camera mainCamera, ScreenPropertiesData screenPropertiesData)
        {
            uIMainManager.SetupManager(mainCamera, screenPropertiesData, SortingLayerOption.UI_Main);
            uIPopupManager.SetupManager(mainCamera, screenPropertiesData, SortingLayerOption.UI_Popup);
        }

        private void SetupPageManager()
        {
            logoPageManager.SetupManager(uIMainManager.logoPage);
        }

        private void SetupPopupManager()
        {

        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}