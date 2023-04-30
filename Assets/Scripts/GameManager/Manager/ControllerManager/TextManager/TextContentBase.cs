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

		public LargePopup testingLargePopup;		
		public MiddlePopup testingMiddlePopup;		
		public SmallPopup testingSmallPopup;

		#endregion
	}
}