using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HomeScene.UIPopup.LoadGamePopup
{
    public class ODESaveFileScrollViewSaveButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Child")]
        [SerializeField] private ODESaveFileScrollViewSaveButtonCrossButton crossButton;

        [Header("Text")]
        [SerializeField] private TMP_Text saveNameText001;
        [SerializeField] private TMP_Text gameTimeHeaderText001;
        [SerializeField] private TMP_Text gameTimeContentText001;
        [SerializeField] private TMP_Text saveDateHeaderText001;
        [SerializeField] private TMP_Text saveDateContentText001;
        [SerializeField] private TMP_Text gameVersionHeaderText001;
        [SerializeField] private TMP_Text gameVersionContentText001;

        [Header("Image")]
        [SerializeField] private Image previewImageImage001;

        public SaveButtonData saveButtonData;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Action
            onPointerClickCallback = null;

            // Init Child
            crossButton.InitElement();

            // Init Text
            saveNameText001.text =  "";
            gameTimeHeaderText001.text =  "";
            gameTimeContentText001.text =  "";
            saveDateHeaderText001.text =  "";
            saveDateContentText001.text =  "";
            gameVersionHeaderText001.text =  "";
            gameVersionContentText001.text =  "";

            // Init Image
            previewImageImage001 = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.LoadGamePopup.ODESaveFileScrollViewSaveButton textContent, SaveButtonData saveButtonData, Action onPointerClickCallback, Action onCrossButtonPointerClickCallback)
        {
            // Setup File Name
            this.saveButtonData = saveButtonData;

            // Setup Font Asset
            saveNameText001.font = fontAsset;
            gameTimeHeaderText001.font = fontAsset;
            gameTimeContentText001.font = fontAsset;
            saveDateHeaderText001.font = fontAsset;
            saveDateContentText001.font = fontAsset;
            gameVersionHeaderText001.font = fontAsset;
            gameVersionContentText001.font = fontAsset;

            // Update Text Content
            textContent.saveNameText001 = textContent.saveNameText001.Replace("{0}", saveButtonData.saveFileName);
            // ToDo: UIpdate To Time Later, Now Show Second
            textContent.gameTimeContentText001 = textContent.gameTimeContentText001.Replace("{0}", saveButtonData.playTime.ToString() + "s");
            textContent.saveDateContentText001 = textContent.saveDateContentText001.Replace("{0}", saveButtonData.saveDate.ToString("dd/MM/yyyy"));
            textContent.gameVersionContentText001 = textContent.gameVersionContentText001.Replace("{0}", saveButtonData.saveVersion);

            // Setup Text Content
            saveNameText001.text = textContent.saveNameText001;
            gameTimeHeaderText001.text = textContent.gameTimeHeaderText001;
            gameTimeContentText001.text = textContent.gameTimeContentText001;
            saveDateHeaderText001.text = textContent.saveDateHeaderText001;
            saveDateContentText001.text = textContent.saveDateContentText001;
            gameVersionHeaderText001.text = textContent.gameVersionHeaderText001;
            gameVersionContentText001.text = textContent.gameVersionContentText001;

            // ToDo: Setup Image            
            // previewImageImage001 = 

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;

            //Setup Child
            crossButton.SetupElement(onCrossButtonPointerClickCallback);
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}