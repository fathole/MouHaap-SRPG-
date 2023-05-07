using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class TextContentZHHK : TextContentBase
    {
        public TextContentZHHK()
        {
            #region Loading Popup

            loadingPopup = new LoadingPopup
            {
                uDETitle = new LoadingPopup.UDETitle
                {
                    text001 = "加載中"
                },
            };

            #endregion

            #region Game Setting Popup

            gameSettingPopup = new GameSettingPopup
            {
                uDETitle = new GameSettingPopup.UDETitle
                {
                    text001 = "系統設置",
                },
                oDEBasicSettingHeader = new GameSettingPopup.ODEBasicSettingHeader
                {
                    text001 = "基礎設置",
                },
                oDEWindowSize = new GameSettingPopup.ODEWindowSize
                {
                    headerText001 = "視窗尺寸：",
                },
                oDEIsFullScreen = new GameSettingPopup.ODEIsFullScreen
                {
                    headerText001 = "全屏顯示：",
                },
                oDEMusicVolume = new GameSettingPopup.ODEMusicVolume
                {
                    headerText001 = "音樂音量：",
                    sliderFillAreaFillText001 = "{0}%",
                },
                oDESFXVolume = new GameSettingPopup.ODESFXVolume
                {
                    headerText001 = "音效音量：",
                    sliderFillAreaFillText001 = "{0}%",
                },
            };

            #endregion

            /* ----- Middle Popup ----- */

            #region Restore Setting Popup

            restoreSettingPopup = new MiddlePopup
            {
                uDETitle = new MiddlePopup.UDETitle
                {
                    text001 = "恢復默認",
                },
                uDEContent = new MiddlePopup.UDEContent
                {
                    text001 = "是否恢復默認基礎設置？",
                },
                oDEPrimaryButton = new MiddlePopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
                oDESecondaryButton = new MiddlePopup.ODESecondaryButton
                {
                    contentText001 = "取消",
                },
            };

            #endregion

            indexToWindowSizeDictionary = new Dictionary<int, string>
            {
                { 0, "2560 x 1440" },
                { 1, "1920 x 1080" },
                { 2, "1600 x 900" },
                { 3, "1360 x 768" },
                { 4, "1280 x 720" },
            };

        }
    }
}