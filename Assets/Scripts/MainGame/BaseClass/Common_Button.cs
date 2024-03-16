using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Button : ObjectBase
{
    #region Declaration

    [Header("Text")]
    [SerializeField] private List<LocalizationText> localizationTextList;

    #endregion

    #region Function - Init Object

    public void InitObject(Action onPointerClickCallback )
    {
        // Init Text
        localizationTextList = GetComponentsInChildren<LocalizationText>().ToList();
        foreach (LocalizationText localiztionText in localizationTextList)
        {
            localiztionText.Localization();
        }

        // Init Action
        this.onPointerClickCallback = onPointerClickCallback;
    }

    #endregion
}
