using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Common_Button : ObjectBase
{
    #region Function - Init

    public void InitObject(Action onPointerClickCallback )
    {
        base.InitObject();

        this.onPointerClickCallback = onPointerClickCallback;
    }

    #endregion
}
