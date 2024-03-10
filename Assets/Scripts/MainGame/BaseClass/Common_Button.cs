using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Common_Button : ObjectBase
{
    #region Function - Init Object

    public void InitObject(Action onPointerClickCallback )
    {
        this.onPointerClickCallback = onPointerClickCallback;
    }

    #endregion
}
