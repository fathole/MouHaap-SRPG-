using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
    public class TextManager : MonoBehaviour
    {
        #region Declaration

        #endregion

        #region Functioon - Init

        public void InitManager()
        {
            Debug.Log("--- TextManager: InitManager ---");
        }

        #endregion

        #region Function - Public

        public TextContent GetTextContent(DisplayLanguageOption displayLanguageOption)
        {
            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
                    return new TextContent_ZHHK();
                default:
                    Debug.LogError("Case Not Found");
                    return null;
            }
        }

        public string GetAllModuleContent(DisplayLanguageOption displayLanguageOption)
        {
            string textContent = "";

            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
                    textContent += Newtonsoft.Json.JsonConvert.SerializeObject(new TextContent_ZHHK());
                    break;
                default:
                    Debug.LogError("Case Not Found");
                    break;
            }

            return textContent;
        }

        #endregion
    }   
}