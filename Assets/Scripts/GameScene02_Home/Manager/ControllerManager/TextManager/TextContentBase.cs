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
			public struct ODEGameSettingButton
			{
				public string text001;
			}
			public struct ODEQuitGameButton
			{
				public string text001;
			}
			public struct ODESoloGameButton
            {
				public string text001;
            }
			public struct ODEMultiplayerGameButton
            {
				public string text001;
			}
			public struct ODEGameModeBackButton
            {
				public string text001;
            }
			public struct ODENormalModeButton
            {
				public string text001;
            }
			public struct ODEHardModeButton
			{
				public string text001;
			}
			public struct ODELegendModeButton
			{
				public string text001;
			}
			public struct ODEDifficultyModeBackButton
            {
				public string text001;
            }

			public ODEStartGameButton oDEStartGameButton;
			public ODEContinueGameButton oDEContinueGameButton;
			public ODEGameSettingButton oDEGameSettingButton;
			public ODEQuitGameButton oDEQuitGameButton;
			public ODESoloGameButton oDESoloGameButton;
			public ODEMultiplayerGameButton oDEMultiplayerGameButton;
			public ODEGameModeBackButton oDEGameModeBackButton;
			public ODENormalModeButton oDENormalModeButton;
			public ODEHardModeButton oDEHardModeButton;
			public ODELegendModeButton oDELegendModeButton;
			public ODEDifficultyModeBackButton oDEDifficultyModeBackButton;
		}

		#endregion

		/* ----- Scene Popup ----- */

		#region Load Game Popup

		public struct LoadGamePopup
		{
			public struct UDETitle
			{
				public string text001;
			}

			public struct ODESaveFileScrollViewSaveButton
			{
				public string saveNameText001;
				public string gameTimeHeaderText001;
				public string gameTimeContentText001;
				public string saveDateHeaderText001;
				public string saveDateContentText001;
				public string gameVersionHeaderText001;
				public string gameVersionContentText001;
			}

			public UDETitle uDETitle;
			public ODESaveFileScrollViewSaveButton oDESaveFileScrollViewSaveButton;
		}

		#endregion

		public HomePage homePage;

		public LoadGamePopup loadGamePopup;

		public GameManager.TextContentBase.LargePopup normalModePopup;
		public GameManager.TextContentBase.LargePopup hardModePopup;
		public GameManager.TextContentBase.LargePopup legendModePopup;

		public GameManager.TextContentBase.MiddlePopup deleteSavePopup;

		public GameManager.TextContentBase.SmallPopup quitGamePopup;
		public GameManager.TextContentBase.SmallPopup comingSoonPopup;

		#endregion
	}
}