using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class TextContentZHHK : TextContentBase
    {
        public TextContentZHHK()
        {
            #region Loading Popup

            loadingPopup = new LoadingPopup
            {
                uDETitle = new LoadingPopup.UDETitle
                {
                    text001 = "¥[¸ü¤¤"
                },
            };

            #endregion
        }
    }
}