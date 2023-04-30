using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene
{
    public class TextContentZHHK : TextContentBase
    {
        public TextContentZHHK()
        {
            #region Home Page

            homePage = new HomePage
            {
                uDEHeader = new HomePage.UDEHeader
                {
                    text001 = "你能來到這裡,都是命運石之門的選擇!",
                },
                oDEGalleryButton = new HomePage.ODEGalleryButton
                {
                    text001 = "相薄",
                },
                oDEMusicButton = new HomePage.ODEMusicButton
                {
                    text001 = "音樂",
                },
                oDESentenceButton = new HomePage.ODESentenceButton
                {
                    text001 = "語錄",
                },
                oDEIntroButton = new HomePage.ODEIntroButton
                {
                    text001 = "簡介",
                },
            };

            #endregion

            #region Gallery Page

            galleryPage = new GalleryPage
            {
                oDEScopeButtonList = new GalleryPage.ODEScopeButtonList
                {
                    steinsGateButtonContentText001 = "SG",
                    steinsGate0ButtonContentText001 = "SG0",
                    steinsGatePhenogramContentText001 = "SGP",
                    steinsGateDaringButtonnContentText001 = "SGD",
                    pixivButtonContentText001 = "Pixiv",
                    otherButtonContentText001 = "其他",
                }
            };

            #endregion

            #region Music Page

            musicPage = new MusicPage
            {
                oDEMusicScrollViewMusicSlot = new MusicPage.ODEMusicScrollViewMusicSlot
                {
                    contentMusicNameText001 = "{0}",
                    contentMusicLengthText001 = "{0}:{1}",
                },
                oDESearchDataEntry = new MusicPage.ODESearchDataEntry
                {
                    searchInputFieldPlaceHolderText001 = "輸入名稱以搜尋",
                },
                oDEMusicControlBar = new MusicPage.ODEMusicControlBar
                {
                    musicNameText001 = "{0}",
                    progressBarCurrentTimeText001 = "{0}:{1}",
                    progressBarTotalTimeText001 = "{0}:{1}",

                    selectSongNotice = "未選擇",
                },
                oDESortingButton = new MusicPage.ODESortingButton
                {
                    contentText001 = "排序",
                },
                oDESortingPanal = new MusicPage.ODESortingPanal
                {
                    panelContentLengthButtonContentText001 = "長度",
                    panelContentNameButtonContentText001 = "名稱",
                },
            };

            #endregion

            #region Sentence Page

            sentencePage = new SentencePage
            {
                sentenceList = new List<SentencePage.UDESentenceScrollViewSentenceSlot>
                {
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "就算知道方法，也絕對不能去改變過去，絕不能將存在的可能性轉變為既定的現實，未來是沒有人能預測的，是無法重來的，正因如此人們才能接受各種痛苦，不幸與飛來橫禍，邁步前進。",
                        contentSpeakerText001 = "岡部倫太郎",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "未來的事情，誰也不知道。正因為如此，就如同再次相見本身，未來才有無限的可能。",
                        contentSpeakerText001 = "命運石之門",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "不要想一味的改變現在，這只會讓過去變得麵目全非罷了。",
                        contentSpeakerText001 = "命運石之門",
                    },
                  new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "時間飛快的流逝，唯獨現在，我有一種想對愛因斯坦發牢騷的心情，岡部，時間根據每個人的主觀感受，既會變長，也會變短，相對論真是既浪漫又傷感的東西呢。",
                        contentSpeakerText001 = "牧瀨紅莉棲",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "宇宙雖有其起源，卻沒有終結——無限。星球雖也有起源，卻因其自身之力走向毀滅——有限。擁有睿智之才是最為愚蠢者，歷史上不勝枚舉...這也可以說是給那些抵抗者們的，神的最後通牒。。",
                        contentSpeakerText001 = "命運石之門",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "El Psy Congroo",
                        contentSpeakerText001 = "岡部倫太郎",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "過去在遠離，未來是否意味?正在靠近。",
                        contentSpeakerText001 = "命運石之門",
                    },
                      new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "人們總是會註視?自己所珍視的東西，唯獨沒有自己",
                        contentSpeakerText001 = "牧瀨紅莉棲",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "你以為只有自己一個人在支撐?這個世界嗎？自以為是也要有個限度，不要忘記，不管你身處哪一條世界線，你都不會孤獨。無論你身處何方，我都會找到你，我會一直觀測?你，就像你一直以來觀測?我一樣。",
                        contentSpeakerText001 = "牧瀨紅莉棲",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "正因為我和你一起度過了那些日子，所以才明白，無論身處於哪條世界線上的哪個時間，哪個地點，我都喜歡?你。我再說一次，牧瀨紅莉棲，我喜歡你，那你呢？此時此刻，你是如何看待我的。",
                        contentSpeakerText001 = "岡部倫太郎",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "我曾經問過她為什麼要對非親非故的我這麼好，然後那個人笑?這麼說了，時光流轉，人總是在他人的幫助下生活?，所以總有一天你也要幫助別人啊。",
                        contentSpeakerText001 = "天王寺裕吾",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "我是狂氣的科學家，鳳凰院兇真。欺騙世界這種小事，不值一提！",
                        contentSpeakerText001 = "鳳凰院兇真",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "世界就在我掌中。",
                        contentSpeakerText001 = "鳳凰院兇真",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "所有的世界至理都不過是區區公式，必然存在?解法。",
                        contentSpeakerText001 = "真帆",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "做不到的啊......和真由理的時候是一樣的，不論做出怎樣的掙紮，紅莉棲一定會死去。為什麼？才失敗了一次而已！一次！別開玩笑了。你以為我失敗了幾次，幾十次啊！我是知道的啊，這個世界的因果律的不合理性。在前方等待?的，將會是多麼悲慘的結局。我知道的啊，我，已經累了，已經累了啊。",
                        contentSpeakerText001 = "岡部倫太郎",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "在無數條世界線中，說不定會存在其他的「我」，無數的「我」心意相通，其中說不定就包含?我。",
                        contentSpeakerText001 = "牧瀨紅莉棲",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "在任何時候，任何場所都存在?我，深愛某人的深切的感情，相信某事的堅強的感情，想要傳遞什麼的強烈的思念，穿越時間，相互聯系，才形成了現在的我的話，那還真是非常美妙的事情啊！",
                        contentSpeakerText001 = "牧瀨紅莉棲",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "一切都是命運石之門的選擇。",
                        contentSpeakerText001 = "岡部倫太郎",
                    },
                },
                uDETitle = new SentencePage.UDETitle
                {
                    text001 = "語錄",
                }
            };

            #endregion

            /* ----- Large Popup ----- */

            #region Sentence Popup

            sentencePopup = new GameManager.TextContentBase.LargePopup
            {
                uDETitle = new GameManager.TextContentBase.LargePopup.UDETitle
                {
                    text001 = "語錄"
                },
                uDEContent = new GameManager.TextContentBase.LargePopup.UDEContent
                {
                    text001 = "句子:\n{0}\n\n 來源:\n{1}"
                },
                oDEPrimaryButton = new GameManager.TextContentBase.LargePopup.ODEPrimaryButton
                {
                    contentText001 = "關閉"
                },
            };

            #endregion

            /* ----- Small Popup ----- */

            #region Coming Soon Popup

            comingSoonPopup = new GameManager.TextContentBase.SmallPopup
            {
                uDETitle = new GameManager.TextContentBase.SmallPopup.UDETitle
                {
                    text001 = "尚未開放",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "確定",
                },
            };

            #endregion
        }
    }
}