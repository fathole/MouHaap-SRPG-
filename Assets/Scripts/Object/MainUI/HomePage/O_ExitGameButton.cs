using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainUI_HomePage
{
    public class O_ExitGameButton : ObjectBase
    {
        #region Function - Init

        public void InitObject(Action onPointerClickCallback)
        {
            // Init Base
            base.InitObject();

            // Init Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion
    }
}