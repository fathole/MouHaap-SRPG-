using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModuleManagerBase : MonoBehaviour
{
    #region Declaration

    [Header("Text")]
    public TMP_FontAsset fontAsset;
    public TextContentBase textContent;

    #endregion

    #region Function - Init

    public virtual void InitModule(TMP_FontAsset fontAsset, TextContentBase textContent)
    {
        Debug.Log("--- ModuleMangaerBase: InitModule");

        this.fontAsset = fontAsset;
        this.textContent = textContent;        
    }

    #endregion
}
