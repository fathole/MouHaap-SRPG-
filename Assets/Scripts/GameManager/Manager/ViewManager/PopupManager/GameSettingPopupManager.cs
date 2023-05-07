using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameManager.UIPopup;
using TMPro;

namespace GameManager
{
    public class GameSettingPopupManager : MonoBehaviour
    {
        #region Declaration

        private UIPopup.GameSettingPopup.GameSettingPopup gameSettingPopup;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset gameSettingPopupMoveInTimeline;
        [SerializeField] private PlayableAsset gameSettingPopupMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            gameSettingPopup = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIPopup.GameSettingPopup.GameSettingPopup gameSettingPopup)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.gameSettingPopup = gameSettingPopup;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            gameSettingPopup.uDETitle.InitElement();
            gameSettingPopup.uSEBackground.InitElement();
            gameSettingPopup.oSECrossButton.InitElement();
            gameSettingPopup.oDEBasicSettingHeader.InitElement();
            gameSettingPopup.oDEIsFullScreen.InitElement();
            gameSettingPopup.oDEMusicVolume.InitElement();
            gameSettingPopup.oDESFXVolume.InitElement();
            gameSettingPopup.oDEWindowSize.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupUDETitle(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.UDETitle textContent)
        {
            gameSettingPopup.uDETitle.SetupElement(fontAsset, textContent);
        }

        public void SetupUSEBackground()
        {
            gameSettingPopup.uSEBackground.SetupElement();
        }

        public void SetupOSECrossButton(Action onPointerClickCallback)
        {
            gameSettingPopup.oSECrossButton.SetupElement(onPointerClickCallback);
        }

        public void SetupODEBasicSettingHeader(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEBasicSettingHeader textContent, Action onRestoreButtonPointerClickCallback)
        {
            gameSettingPopup.oDEBasicSettingHeader.SetupElement(fontAsset, textContent, onRestoreButtonPointerClickCallback);
        }

        public void SetupODEIsFullScreen(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEIsFullScreen textContent, bool isEnable, Action onToggleButtonPointerClickCallback)
        {
            gameSettingPopup.oDEIsFullScreen.SetupElement(fontAsset, textContent, isEnable, onToggleButtonPointerClickCallback);
        }

        public void SetupODEMusicVolume(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEMusicVolume textContent, bool isEnable, float volume, Action onToggleButtonPointerClickCallback, Action<float> onVolumeSliderValueChangeCallback)
        {
            gameSettingPopup.oDEMusicVolume.SetupElement(fontAsset, textContent, isEnable, volume, onToggleButtonPointerClickCallback, onVolumeSliderValueChangeCallback);
        }

        public void SetupODESFXVolume(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODESFXVolume textContent, bool isEnable, float volume, Action onToggleButtonPointerClickCallback, Action<float> onVolumeSliderValueChangeCallback)
        {
            gameSettingPopup.oDESFXVolume.SetupElement(fontAsset, textContent, isEnable, volume, onToggleButtonPointerClickCallback, onVolumeSliderValueChangeCallback);
        }

        public void SetupODEWindowSize(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEWindowSize textContent, Dictionary<int, string> intToWindowSizeDictionary, int selectedWindowSizeIndex, Action<int> onWindowSizeDropdownValueChangeCallback)
        {
            gameSettingPopup.oDEWindowSize.SetupElement(fontAsset, textContent, intToWindowSizeDictionary, selectedWindowSizeIndex, onWindowSizeDropdownValueChangeCallback);
        }

        /* ----- Function ----- */

        public void SetMusicVolumeSlider(TextContentBase.GameSettingPopup.ODEMusicVolume textContent, float volume)
        {
            gameSettingPopup.oDEMusicVolume.SetVolumeSlider(textContent, volume);
        }

        public void SetSFXVolumeSlider(TextContentBase.GameSettingPopup.ODESFXVolume textContent, float volume)
        {
            gameSettingPopup.oDESFXVolume.SetVolumeSlider(textContent, volume);
        }

        public void SetMusicVolumeToggle(bool isEnable)
        {
            gameSettingPopup.oDEMusicVolume.SetToggle(isEnable);
        }

        public void SetSFXVolumeToggle(bool isEnable)
        {
            gameSettingPopup.oDESFXVolume.SetToggle(isEnable);
        }

        public void SetFullScreenToggle(bool isEnable)
        {
            gameSettingPopup.oDEIsFullScreen.SetToggle(isEnable);
        }

        /* ----- Timeline ----- */

        public void PlayGameSettingPopupMoveInTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(gameSettingPopupMoveInTimeline, finishCallback);
        }

        public void PlayGameSettingPopupMoveOutTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(gameSettingPopupMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}