using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager.UIPopup.GameSettingPopup
{
    public class ODEWindowSize : MonoBehaviour
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text headerText001;

        [Header("Dropdown")]
        [SerializeField] private TMP_Dropdown windowSizeDropdown;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Dropdown
            windowSizeDropdown.ClearOptions();
            windowSizeDropdown.onValueChanged = new TMP_Dropdown.DropdownEvent { };

            // Init Text
            headerText001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.GameSettingPopup.ODEWindowSize textContent, Dictionary<int, string> intToWindowSizeDictionary, int selectedWindowSizeIndex, Action<int> onWindowSizeDropdownValueChangeCallback)
        {
            // Setup fontAsset
            headerText001.font = fontAsset;
            windowSizeDropdown.captionText.font = fontAsset;
            windowSizeDropdown.itemText.font = fontAsset;

            // Setup textContent
            headerText001.text = textContent.headerText001;

            // Setup dropdown
            foreach (KeyValuePair<int, string> option in intToWindowSizeDictionary)
            {
                TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
                optionData.text = option.Value;
                windowSizeDropdown.options.Add(optionData);
            }
            windowSizeDropdown.value = selectedWindowSizeIndex;
            windowSizeDropdown.RefreshShownValue();
            windowSizeDropdown.onValueChanged.AddListener(delegate { onWindowSizeDropdownValueChangeCallback?.Invoke(windowSizeDropdown.value); });
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}