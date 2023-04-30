using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene
{
    public class TextManager : MonoBehaviour
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing Init
        }

        #endregion

        #region Setup Stage

        public void SetupManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing Setup
        }

        #endregion

        #region Main Function

        public TextContentBase GetTextContent(DisplayLanguageOption displayLanguageOption)
        {
            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
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
                    // textContent += Newtonsoft.Json.JsonConvert.SerializeObject(new TextContentZHTW());
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