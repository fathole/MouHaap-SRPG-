using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using TMPro;

namespace MainGame
{
    public class TextMeshProManager : MonoBehaviour
    {
        #region Declaration

        public static TextDatas TextDatas;
        public static TMP_FontAsset fontAsset;

        [SerializeField] private TextDatas _TextDatas;
        [SerializeField] private SerializableDictionaryBase<FontOption, Font> fontOptionToFontDict;                

        #endregion

        #region Function - Init

        public void InitManager()
        {
            Debug.Log("--- TextMeshProManager: InitManager ---");

            TextDatas = _TextDatas;
        }

        #endregion

        #region Functioon - Public

        public string GetTextDatas(DisplayLanguageOption displayLanguageOption)
        {
            string textDatasContent = "";

            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
                    foreach (KeyValuePair<string, TextData> keyToValue in TextDatas.keyToTextContentDict)
                    {
                        textDatasContent += keyToValue.Value.ZH_HK;
                    }
                    break;
                default:
                    Debug.LogError("Case Not Found");
                    break;
            }

            return textDatasContent;
        }

        public IEnumerator GenerateFontAssetCoroutine(FontOption fontOption, string textContent)
        {
            if (fontOptionToFontDict.TryGetValue(fontOption, out Font font))
            {
                // Generate Font ASset
                fontAsset = TMP_FontAsset.CreateFontAsset(font, 50, 5, UnityEngine.TextCore.LowLevel.GlyphRenderMode.SDFAA, 512, 512, AtlasPopulationMode.Dynamic);
                fontAsset.TryAddCharacters(textContent);
                yield return null;
            }
            else
            {
                Debug.LogError("Font Not Found");
            }
        }

        public TMP_FontAsset GetFontAsset()
        {
            return fontAsset;
        }

        public static void UpdateTMPText(TMP_Text tmpText, string key)
        {            
            // If Key Is Empty, Return Null 
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            TextData textData;

            if (TextDatas.keyToTextContentDict.TryGetValue(key, out textData))
            {
                switch (MainGameManager.instance.GetCurrentDispplayOption())
                {
                    case DisplayLanguageOption.ZH_HK:
                        if (!string.IsNullOrEmpty(textData.ZH_HK))
                        {
                            tmpText.text = textData.ZH_HK;
                            tmpText.font = fontAsset;
                        }
                        else
                        {
                            Debug.LogError("Key: " + key + ", Langugae: " + MainGameManager.instance.GetCurrentDispplayOption().ToString() + ", Text Content Not Found");
                            return;
                        }                                        
                        break;
                    default:
                        Debug.LogError("Case Not Found");
                        break;
                }                                
            }
            else
            {

            }
        }

        #endregion
    }
}