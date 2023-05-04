using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HomeScene.UIPopup.LoadGamePopup
{
    public class ODESaveFileScrollView : MonoBehaviour
    {
        #region Declaration

        [Header("Parent")]
        [SerializeField] private Transform saveButtonParent;

        [Header("Prefab")]
        [SerializeField] private ODESaveFileScrollViewSaveButton saveButtonPrefab;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Scrollview
            foreach(Transform child in saveButtonParent)
            {
                Destroy(child.gameObject);
            }
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.LoadGamePopup.ODESaveFileScrollViewSaveButton textContent, List<SaveButtonData> saveButtonDataList, Action<int> onSaveButtonPointerClickCallback, Action<int> onSaveButtonCrossButtonPointerClickCallback)
        {
            foreach(SaveButtonData data in saveButtonDataList)
            {
                ODESaveFileScrollViewSaveButton saveButton = Instantiate(saveButtonPrefab, saveButtonParent);
                saveButton.InitElement();
                saveButton.SetupElement(fontAsset, textContent, data, () => { onSaveButtonPointerClickCallback(data.iD); }, () => { onSaveButtonCrossButtonPointerClickCallback(data.iD); });
            }
        }

        #endregion

        #region Main Fuinction

        // Comment: No Main Function

        #endregion
    }
}