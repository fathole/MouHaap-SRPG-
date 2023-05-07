using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class ODESFXVolume : MonoBehaviour
    {
        #region Declaration

        [Header("Child")]
        [SerializeField] private ODESFXVolumeToggleButton toggleButton;

        [Header("Slider")]
        [SerializeField] private Slider volumeSlider;

        [Header("Text")]
        [SerializeField] private TMP_Text headerText001;
        [SerializeField] private TMP_Text sliderFillAreaFillText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Slider
            volumeSlider.onValueChanged.RemoveAllListeners();

            // Init Child
            toggleButton.InitElement();

            // Init Text
            headerText001.text = "";
            sliderFillAreaFillText001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODESFXVolume textContent, bool isEnable, float volume, Action onToggleButtonPointerClickCallback, Action<float> onVolumeSliderValueChangeCallback)
        {
            // Setup Font Asset
            headerText001.font = fontAsset;
            sliderFillAreaFillText001.font = fontAsset;

            // Update Text Content
            textContent.sliderFillAreaFillText001 = textContent.sliderFillAreaFillText001.Replace("{0}", (volume * 100).ToString());

            // Setup Text Content
            headerText001.text = textContent.headerText001;
            sliderFillAreaFillText001.text = textContent.sliderFillAreaFillText001;

            //Setup Child
            toggleButton.SetupElement(onToggleButtonPointerClickCallback, isEnable);

            // Setup Slider
            volumeSlider.value = volume * 10;
            volumeSlider.onValueChanged.AddListener(delegate { onVolumeSliderValueChangeCallback(volumeSlider.value); });
        }

        #endregion

        #region Main Fuinction

        public void SetVolumeSlider(TextContentBase.GameSettingPopup.ODESFXVolume textContent, float volume)
        {
            // Update Text Content
            textContent.sliderFillAreaFillText001 = textContent.sliderFillAreaFillText001.Replace("{0}", (volume * 100).ToString());

            // Setup Text Content
            sliderFillAreaFillText001.text = textContent.sliderFillAreaFillText001;
        }

        public void SetToggle(bool isEnable)
        {
            toggleButton.SetIsEnable(isEnable);
        }

        #endregion
    }
}