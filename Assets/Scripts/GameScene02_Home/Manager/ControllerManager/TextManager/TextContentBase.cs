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
			public struct UDEHeader
			{
				public string text001;
			}
			public struct ODEGalleryButton
			{
				public string text001;
			}
			public struct ODEMusicButton
			{
				public string text001;
			}
			public struct ODESentenceButton
			{
				public string text001;
			}
			public struct ODEIntroButton
			{
				public string text001;
			}

			public UDEHeader uDEHeader;
			public ODEGalleryButton oDEGalleryButton;
			public ODEMusicButton oDEMusicButton;
			public ODESentenceButton oDESentenceButton;
			public ODEIntroButton oDEIntroButton;
		}

		#endregion

		#region Gallery Page

		public struct GalleryPage
		{
			public struct ODEScopeButtonList
			{
				public string steinsGateButtonContentText001;
				public string steinsGate0ButtonContentText001;
				public string steinsGatePhenogramContentText001;
				public string steinsGateDaringButtonnContentText001;
				public string pixivButtonContentText001;
				public string otherButtonContentText001;
			}

			public ODEScopeButtonList oDEScopeButtonList;
		}

		#endregion

		#region Music Page

		public struct MusicPage
		{
			public struct ODEMusicScrollViewMusicSlot
			{
				public string contentMusicNameText001;
				public string contentMusicLengthText001;
			}
			public struct ODESearchDataEntry
			{
				public string searchInputFieldPlaceHolderText001;
			}
			public struct ODEMusicControlBar
			{
				public string musicNameText001;
				public string progressBarCurrentTimeText001;
				public string progressBarTotalTimeText001;

				public string selectSongNotice;
			}
			public struct ODESortingButton
			{
				public string contentText001;
			}
			public struct ODESortingPanal
			{
				public string panelContentNameButtonContentText001;
				public string panelContentLengthButtonContentText001;
			}

			public ODEMusicScrollViewMusicSlot oDEMusicScrollViewMusicSlot;
			public ODESearchDataEntry oDESearchDataEntry;
			public ODEMusicControlBar oDEMusicControlBar;
			public ODESortingButton oDESortingButton;
			public ODESortingPanal oDESortingPanal;
		}

		#endregion

		#region Sentence Page

		public struct SentencePage
        {
			public struct UDESentenceScrollViewSentenceSlot
            {
				public string contentSentenceText001;
				public string contentSpeakerText001;
			}
			public struct UDETitle
            {
				public string text001;
            }

			public List<UDESentenceScrollViewSentenceSlot> sentenceList;
			public UDETitle uDETitle;
		}

		#endregion

		public HomePage homePage;
		public GalleryPage galleryPage;
		public MusicPage musicPage;
		public SentencePage sentencePage;

		public GameManager.TextContentBase.LargePopup sentencePopup;
		public GameManager.TextContentBase.SmallPopup comingSoonPopup;

		#endregion
	}
}