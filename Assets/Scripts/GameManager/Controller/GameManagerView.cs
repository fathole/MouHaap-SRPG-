using System;
using System.Collections;
using UnityEngine;
using GameManager.UIPopup;
using GameManager.UIMain;

namespace GameManager
{
    public class GameManagerView : MonoBehaviour
    {
        #region Declaration

        public ScreenProperties deviceScreen { get; private set; }
        public ScreenProperties targetScreen { get; private set; }
        public ScreenProperties cameraScreen { get; private set; }

        [Header("Sorting Layer Manager")]
        public UIMainManager uIMainManager;
        public UIPopupManager uIPopupManager;

        [Header("Popup Manager")]
        public LargePopupManager largePopupManager;
        public MiddlePopupManager middlePopupManager;
        public SmallPopupManager smallPopupManager;

        #endregion

        #region Init Stage

        public void InitView()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitCameraScreen();

            InitSortingLayerManager();

            InitPopupManager();
        }

        private void InitCameraScreen()
        {
            deviceScreen = new ScreenProperties();
            targetScreen = new ScreenProperties();
            cameraScreen = new ScreenProperties();

        }

        private void InitSortingLayerManager()
        {
            uIMainManager.InitManager();
            uIPopupManager.InitManager();
        }

        private void InitPopupManager()
        {
            largePopupManager.InitManager();
            middlePopupManager.InitManager();
            smallPopupManager.InitManager();
        }

        #endregion

        #region Setup Stage

        public void SetupView(Camera mainCamera)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupCameraScreen();

            ScreenPropertiesData screenPropertiesData = new ScreenPropertiesData
            {
                cameraScreen = this.cameraScreen,
                deviceScreen = this.deviceScreen,
                targetScreen = this.targetScreen,
            };

            SetupSortingLayerManager(mainCamera, screenPropertiesData);

            SetupPopupManager();
        }

        private void SetupCameraScreen()
        {
            deviceScreen = GetDeviceScreen();
            targetScreen = GetTargeScreen(deviceScreen);
            cameraScreen = GetCameraScreen(targetScreen);

        }

        private void SetupSortingLayerManager(Camera mainCamera, ScreenPropertiesData screenPropertiesData)
        {
            uIMainManager.SetupManager(mainCamera, screenPropertiesData, SortingLayerOption.UI_AppMain);
            uIPopupManager.SetupManager(mainCamera, screenPropertiesData, SortingLayerOption.UI_AppPopup);
        }

        private void SetupPopupManager()
        {
            largePopupManager.SetupManager(uIPopupManager.largePopupPrefab);
            middlePopupManager.SetupManager(uIPopupManager.middlePopupPrefab);
            smallPopupManager.SetupManager(uIPopupManager.smallPopupPrefab);
        }

        #endregion

        #region Main Function

        private ScreenProperties GetDeviceScreen()
        {
            ScreenProperties deviceScreen = new ScreenProperties();
            deviceScreen.width = Screen.width;
            deviceScreen.height = Screen.height;
            deviceScreen.aspectRatio.ratioWidth = Screen.width;
            deviceScreen.aspectRatio.ratioHeight = Screen.height;

            return deviceScreen;
        }

        private ScreenProperties GetTargeScreen(ScreenProperties deviceScreen)
        {
            ScreenProperties targetScreen = new ScreenProperties();
            float deviceScreenWidth = deviceScreen.width;
            float deviceScreenHight = deviceScreen.height;
            float deviceScreenAspect = deviceScreen.aspectRatio.ratioWidth / deviceScreen.aspectRatio.ratioHeight;

            AspectRatioProperties targetScreenAspectRatio = GetTargetScreenAspectRatio(deviceScreen);

            if ((targetScreenAspectRatio.ratioWidth / targetScreenAspectRatio.ratioHeight) < (16.0 / 9.0))
            {
                targetScreen.width = deviceScreenWidth;
                // Cal Step: TargetDeviceScreen_W / TargetDeviceScreen_H = TargetDeviceScreen_Ratio	
                // Cal Step: TargetDeviceScreen_H = TargetDeviceScreen_W / TargetDeviceScreen_Ratio		// TargetDeviceScreen_W = DeviceScreen_W	
                // Cal Step: TargetDeviceScreen_H = DeviceScreen_W / TargetDeviceScreen_Ratio			 
                // Cal Step: TargetDeviceScreen_H = DeviceScreen_W / (TargetDeviceScreen_RatioWidth / TargetDeviceScreen_RatioHeitht)
                targetScreen.height = deviceScreenWidth / (targetScreenAspectRatio.ratioWidth / targetScreenAspectRatio.ratioHeight);
            }
            else
            {
                targetScreen.height = deviceScreenHight;
                targetScreen.width = (targetScreenAspectRatio.ratioWidth / targetScreenAspectRatio.ratioHeight) * deviceScreenHight;
            }
            targetScreen.aspectRatio = targetScreenAspectRatio;

            return targetScreen;
        }

        private ScreenProperties GetCameraScreen(ScreenProperties targetScreen)
        {
            ScreenProperties cameraScreen = new ScreenProperties();
            float targetScreenAspectRatioWidth = targetScreen.aspectRatio.ratioWidth;
            float targetScreenAspectRatioHeight = targetScreen.aspectRatio.ratioHeight;

            // 21:9 < deviceScreenAspectRatio
            // 2.333 333 333 < deviceScreenAspect
            if ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) > 21.0 / 9.0)
            {
                cameraScreen.width = 5040f;
                cameraScreen.height = 2160f;
                cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
                cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
            }

            // 16:9 <= deviceScreenAspectRatio <= 21:9
            // 1.777 777 778 <= deviceScreenAspect <= 2.333 333 333
            else if (((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) <= (21.0 / 9.0)) && ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) >= (16.0 / 9.0)))
            {
                //cameraScreen.width = 2160f * (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
                float width = 2160f * (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
                cameraScreen.width = (float)Math.Round((double)width, 1, MidpointRounding.AwayFromZero);
                cameraScreen.height = 2160f;
                cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
                cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
            }
            // 4:3 <= deviceScreenAspectRatio < 16:9
            // 1.333 333 333 <= deviceScreenAspect < 1.777 777 778 
            else if (((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) < (16.0 / 9.0)) && ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) >= (4.0 / 3.0)))
            {
                cameraScreen.width = 3840f;
                //cameraScreen.height = 3840f / (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
                float height = 3840f / (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
                cameraScreen.height = (float)Math.Round((double)height, 1, MidpointRounding.AwayFromZero);
                cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
                cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
            }

            // deviceScreenAspectRatio < 4:3
            // deviceScreenAspect < 1.333 333 333
            else if ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) < (4.0 / 3.0))
            {
                cameraScreen.width = 3840f;
                cameraScreen.height = 2880f;
                cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
                cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
            }

            return cameraScreen;
        }

        private AspectRatioProperties GetTargetScreenAspectRatio(ScreenProperties deviceScreen)
        {
            float interval = 0.01f;
            AspectRatioProperties nearestTargetDeviceScreenRatio = new AspectRatioProperties();

            float deviceScreenWidth = deviceScreen.width;
            float deviceScreenHeight = deviceScreen.height;

            // 21:9 < deviceScreenRatio
            // 2.333 333 333 < deviceScreenAspect
            if ((deviceScreenWidth / deviceScreenHeight) > (21.0 / 9.0))
            {
                nearestTargetDeviceScreenRatio.ratioWidth = 21f;
                nearestTargetDeviceScreenRatio.ratioHeight = 9f;
            }

            // 16:9 <= deviceScreenRatio <= 21:9
            // 1.777 777 778 <= deviceScreenAspect <= 2.333 333 333
            else if (((deviceScreenWidth / deviceScreenHeight) <= (21.0 / 9.0)) && ((deviceScreenWidth / deviceScreenHeight) >= (16.0 / 9.0)))
            {
                float minDifference = float.MaxValue;
                int loop = (int)((21f - 16f) / interval);

                //Loop from width = 16f to widht = 21f
                for (int i = 0; i <= loop; i++)
                {
                    float width = 16f + (float)(i * interval);
                    float difference = (deviceScreenWidth / deviceScreenHeight) - (width / 9f);
                    //difference = (float)Math.Round(difference, 6, MidpointRounding.AwayFromZero);
                    difference = (float)RoundApproximate(difference, 6, MidpointRounding.AwayFromZero);
                    if (difference >= 0 && difference < minDifference)
                    {
                        minDifference = difference;
                        //nearestTargetDeviceScreenRatio.ratioWidth = width;
                        //nearestTargetDeviceScreenRatio.ratioWidth = (float)Math.Round((double)width, 2);
                        //nearestTargetDeviceScreenRatio.ratioWidth = (float)Math.Round((double)width, 2, MidpointRounding.AwayFromZero);
                        nearestTargetDeviceScreenRatio.ratioWidth = (float)RoundApproximate(width, 2, MidpointRounding.AwayFromZero);
                        nearestTargetDeviceScreenRatio.ratioHeight = 9f;
                    }
                }

            }

            // 4:3 <= deviceScreenRatio < 16:9
            // 1.333 333 333 <= deviceScreenAspect < 1.777 777 778 
            else if (((deviceScreenWidth / deviceScreenHeight) < 16.0 / 9.0) && ((deviceScreenWidth / deviceScreenHeight) >= 4.0 / 3.0))
            {
                float minDifference = float.MaxValue;
                int loop = (int)((12f - 9f) / interval);

                //Loop from height = 12f to height = 9.01f if interval = 0.01
                for (int i = loop; i >= 0; i--)
                {
                    float height = 9f + (float)(i * interval);
                    float difference = (16f / height) - (deviceScreenWidth / deviceScreenHeight);
                    //difference = (float)Math.Round(difference, 6, MidpointRounding.AwayFromZero);
                    difference = (float)RoundApproximate(difference, 6, MidpointRounding.AwayFromZero);
                    if (difference >= 0 && difference < minDifference)
                    {
                        minDifference = difference;
                        nearestTargetDeviceScreenRatio.ratioWidth = 16f;
                        //nearestTargetDeviceScreenRatio.ratioHeight = height;
                        //nearestTargetDeviceScreenRatio.ratioHeight = (float)Math.Round((double)height, 2);
                        //nearestTargetDeviceScreenRatio.ratioHeight = (float)Math.Round((double)height, 2, MidpointRounding.AwayFromZero);
                        nearestTargetDeviceScreenRatio.ratioHeight = (float)RoundApproximate(height, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }

            // deviceScreenRatio < 4:3
            // deviceScreenAspect < 1.333 333 333
            else if ((deviceScreenWidth / deviceScreenHeight) < (4.0 / 3.0))
            {
                nearestTargetDeviceScreenRatio.ratioWidth = 16f;
                nearestTargetDeviceScreenRatio.ratioHeight = 12f;
            }

            return nearestTargetDeviceScreenRatio;
        }

        private double RoundApproximate(double inputValue, int digits, MidpointRounding mode)
        {
            const double margin = 8e-14;

            double fraction = inputValue * Math.Pow(10, digits);
            double value = Math.Truncate(fraction);
            fraction = fraction - value;
            if (fraction == 0)
                return inputValue;

            double tolerance = margin * inputValue;
            // Determine whether this is a midpoint value.
            if ((fraction >= .5 - tolerance) & (fraction <= .5 + tolerance))
            {
                if (mode == MidpointRounding.AwayFromZero)
                    return (value + 1) / Math.Pow(10, digits);
                else
                   if (value % 2 != 0)
                    return (value + 1) / Math.Pow(10, digits);
                else
                    return value / Math.Pow(10, digits);
            }
            // Any remaining fractional value greater than .5 is not a midpoint value.
            if (fraction > .5)
                return (value + 1) / Math.Pow(10, digits);
            else
                return value / Math.Pow(10, digits);
        }

        #endregion
    }
}