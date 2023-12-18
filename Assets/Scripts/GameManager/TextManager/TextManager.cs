using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameManager
{
    public class TextManager : MonoBehaviour
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion

        #region Function - Init

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing Init
        }

        #endregion

        #region Function

        public TextContentBase GetTextContent(DisplayLanguageOption displayLanguageOption)
        {
            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
                    return new TextContentZHHK();
                case DisplayLanguageOption.ZH_TW:
                    // ToDo: Update Later
                    return new TextContentZHHK();
                default:
                    Debug.LogError("<color=red>----- Text Content: " + displayLanguageOption + ", Not Found -----</color>");
                    return new TextContentZHHK();
            }
        }

        public string GetAllSceneTextContent(DisplayLanguageOption displayLanguageOption)
        {
            string textContent = "";

            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
                    textContent += Newtonsoft.Json.JsonConvert.SerializeObject(new TextContentZHHK());
                    break;
                case DisplayLanguageOption.ZH_TW:
                    // ToDo: Update Later
                    textContent += Newtonsoft.Json.JsonConvert.SerializeObject(new TextContentZHHK());
                    break;
                default:
                    Debug.LogError("<color=red>----- Text Content: " + displayLanguageOption + ", Not Found -----</color>");
                    break;
            }

            return textContent;
        }

        #endregion
    }
}