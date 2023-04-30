using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager
{
    public class FontManager : MonoBehaviour
    {
        #region Declaration

        private FontOption fontOption;

        [Header("Font")]
        [SerializeField] private Font notoSansCJKFont;
        [SerializeField] private TMP_FontAsset fontAsset;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            fontOption = new FontOption();
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

        public void GenerateFontAsset(DisplayLanguageOption displayLanguageOption)
        {
            // Get Font
            switch (displayLanguageOption)
            {
                case DisplayLanguageOption.ZH_HK:
                    fontOption = FontOption.NotoSansCJK;
                    break;
                default:
                    Debug.LogError("<color=red>----- Display Language Option: " + displayLanguageOption + ", Not Found -----</color>");
                    break;                        
            }
            Font font = GetFont(fontOption);

            // Generate Font ASset
            fontAsset = TMP_FontAsset.CreateFontAsset(font, 50, 5, UnityEngine.TextCore.LowLevel.GlyphRenderMode.SDFAA, 512, 512, AtlasPopulationMode.Dynamic);
        }

        public IEnumerator UpdateFontAssetTextContent(string text)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            fontAsset.TryAddCharacters(text);
            yield return null;
        }

        public TMP_FontAsset GetFontAsset()
        {
            return fontAsset;
        }

        #region Unit Function

        private Font GetFont(FontOption fontOption)
        {
            switch (fontOption)
            {
                case FontOption.NotoSansCJK:
                    return notoSansCJKFont;
                default:
                    Debug.LogError("<color=red>----- Font Option: " + fontOption + ", Not Found -----</color>");
                    return null;
            }
        }

        #endregion

        #endregion
    }
}