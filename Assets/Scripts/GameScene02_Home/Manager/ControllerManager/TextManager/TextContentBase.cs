using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene
{
	public class TextContentBase
	{
		#region Declaration		

		#region Home Page

		public struct HomePage
		{
			public struct ODEStartGameButton
			{
				public string text001;
			}
			public struct ODEContinueGameButton
			{
				public string text001;
			}
			public struct ODEQuitGameButton
			{
				public string text001;
			}

			public ODEStartGameButton oDEStartGameButton;
			public ODEContinueGameButton oDEContinueGameButton;
			public ODEQuitGameButton oDEQuitGameButton;
		}

		#endregion

		public HomePage homePage;

		public GameManager.TextContentBase.SmallPopup quitGamePopup;

		#endregion
	}
}