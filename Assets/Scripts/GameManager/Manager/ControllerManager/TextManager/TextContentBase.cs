using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
	public class TextContentBase
	{
		#region Declaration		

		#region LargePopup

		public struct LargePopup
		{
			public struct UDETitle
			{
				public string text001;
			}

			public struct UDEContent
			{
				public string text001;
			}

			public struct ODEPrimaryButton
			{
				public string contentText001;
			}

			public struct ODESecondaryButton
			{
				public string contentText001;
			}

			public UDETitle uDETitle;
			public UDEContent uDEContent;
			public ODEPrimaryButton oDEPrimaryButton;
			public ODESecondaryButton oDESecondaryButton;
		}

		#endregion

		#region MiddlePopup

		public struct MiddlePopup
		{
			public struct UDETitle
			{
				public string text001;
			}

			public struct UDEContent
			{
				public string text001;
			}

			public struct ODEPrimaryButton
			{
				public string contentText001;
			}

			public struct ODESecondaryButton
			{
				public string contentText001;
			}

			public UDETitle uDETitle;
			public UDEContent uDEContent;
			public ODEPrimaryButton oDEPrimaryButton;
			public ODESecondaryButton oDESecondaryButton;
		}

		#endregion

		#region SmallPopup

		public struct SmallPopup
		{
			public struct UDETitle
			{
				public string text001;
			}

			public struct ODEPrimaryButton
			{
				public string contentText001;
			}

			public struct ODESecondaryButton
			{
				public string contentText001;
			}

			public UDETitle uDETitle;
			public ODEPrimaryButton oDEPrimaryButton;
			public ODESecondaryButton oDESecondaryButton;
		}

        #endregion

        #region Loading Popup

		public struct LoadingPopup
        {
			public struct UDETitle
            {
				public string text001;
            }

			public UDETitle uDETitle;
		}

        #endregion

        #region Game Setting Popup

		public struct GameSettingPopup
        {
			public struct UDETitle
            {
				public string text001;
            }
			public struct ODEBasicSettingHeader
            {
				public string text001;
            }
			public struct ODEWindowSize
            {
				public string headerText001;
            }
			public struct ODEIsFullScreen
            {
				public string headerText001;
            }
			public struct ODEMusicVolume
            {
				public string headerText001;
				public string sliderFillAreaFillText001;
            }
			public struct ODESFXVolume
			{
				public string headerText001;
				public string sliderFillAreaFillText001;
			}

			public UDETitle uDETitle;
			public ODEBasicSettingHeader oDEBasicSettingHeader;
			public ODEWindowSize oDEWindowSize;
			public ODEIsFullScreen oDEIsFullScreen;
			public ODEMusicVolume oDEMusicVolume;
			public ODESFXVolume oDESFXVolume;
		}

        #endregion

        public LoadingPopup loadingPopup;
		public GameSettingPopup gameSettingPopup;

		public TextContentBase.MiddlePopup restoreSettingPopup;

		public Dictionary<int, string> indexToWindowSizeDictionary;

		#endregion
	}
}