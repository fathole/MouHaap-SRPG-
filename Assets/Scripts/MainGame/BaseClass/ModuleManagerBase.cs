using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModuleManagerBase : MonoBehaviour
{
    #region Declaration

    #endregion

    #region Function - Init

    public virtual void InitModule(TMP_FontAsset fontAsset, TextContentBase textContent)
    {
        Debug.Log("--- ModuleMangaerBase: InitModule");
    }

    #endregion
}
