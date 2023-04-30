using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class TextContentZHHK : TextContentBase
    {
        public TextContentZHHK()
        {
            #region Testing Large Popup

            testingLargePopup = new LargePopup
            {
                uDETitle = new LargePopup.UDETitle
                {
                    text001 = "",
                },
                uDEContent = new LargePopup.UDEContent
                {
                    text001 = "",
                },
                oDEPrimaryButton = new LargePopup.ODEPrimaryButton 
                {
                    contentText001 = "",
                },
                oDESecondaryButton = new LargePopup.ODESecondaryButton
                {
                    contentText001 = "",
                },
            };

            #endregion

            #region Testing Middle Popup

            testingMiddlePopup = new MiddlePopup
            {
                uDETitle = new MiddlePopup.UDETitle
                {
                    text001 = "",
                },
                uDEContent = new MiddlePopup.UDEContent
                {
                    text001 = "",
                },
                oDEPrimaryButton = new MiddlePopup.ODEPrimaryButton
                {
                    contentText001 = "",
                },
                oDESecondaryButton = new MiddlePopup.ODESecondaryButton
                {
                    contentText001 = "",
                },
            };

            #endregion

            #region Testing Small Popup

            testingSmallPopup = new SmallPopup
            {
                uDETitle = new SmallPopup.UDETitle
                {
                    text001 = "",
                },
                oDEPrimaryButton = new SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "",
                },
                oDESecondaryButton = new SmallPopup.ODESecondaryButton
                {
                    contentText001 = "",
                },
            };

            #endregion
        }
    }
}