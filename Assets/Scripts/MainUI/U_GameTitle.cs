using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MainUI
{
    public class U_GameTitle : MonoBehaviour
    {
        #region Declaration

        [SerializeField] private TMP_Text text001;

        #endregion

        #region Function - Init

        public void InitObject()
        {
            // Init Text Font
            text001.font = MainUIManager.fontAsset;

            // Init Text Content
            text001.text = MainUIManager.textContent.u_GameTitle.text001;                
        }

        #endregion
    }
}