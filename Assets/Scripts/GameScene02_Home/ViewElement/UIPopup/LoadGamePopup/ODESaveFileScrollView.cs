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

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.LoadGamePopup.ODESaveFileScrollViewSaveButton textContent, List<SaveButtonData> saveButtonDataList, Action<string> onSaveButtonPointerClickCallback, Action<string> onSaveButtonCrossButtonPointerClickCallback)
        {
            if (saveButtonDataList!=null && saveButtonDataList.Count > 0)
            {
                foreach (SaveButtonData data in saveButtonDataList)
                {
                    ODESaveFileScrollViewSaveButton saveButton = Instantiate(saveButtonPrefab, saveButtonParent);
                    saveButton.InitElement();
                    saveButton.SetupElement(fontAsset, textContent, data, () => { onSaveButtonPointerClickCallback(data.fileName); }, () => { onSaveButtonCrossButtonPointerClickCallback(data.fileName); });
                }

                GetComponent<ScrollRect>().normalizedPosition = new Vector2(0,1);
            }
        }

        #endregion

        #region Main Fuinction

        public void DeleteSaveButton(string fileName)
        {
            foreach(Transform child in saveButtonParent)
            {
                if(child.GetComponent<ODESaveFileScrollViewSaveButton>().saveButtonData.fileName == fileName)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        // Comment: No Main Function

        #endregion
    }
}