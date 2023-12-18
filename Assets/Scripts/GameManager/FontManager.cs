using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MainGameManager
{
    public class FontManager : MonoBehaviour
    {
        #region Declaration
        
        [Header("Font")]
        [SerializeField] private Font notoSansCJKFont;
        [SerializeField] private TMP_FontAsset fontAsset;

        #endregion

        #region Function - Init

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing Init
        }

        #endregion

        #region Function

        public void GenerateFontAsset(FontOption fontOption)
        {
            Font font = GetFont(fontOption);

            // Generate Font ASset
            fontAsset = TMP_FontAsset.CreateFontAsset(font, 50, 5, UnityEngine.TextCore.LowLevel.GlyphRenderMode.SDFAA, 512, 512, AtlasPopulationMode.Dynamic);
        }

        public IEnumerator UpdateFontAssetTextContentCoroutine(string text)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            fontAsset.TryAddCharacters(text);
            yield return null;
        }

        public TMP_FontAsset GetFontAsset()
        {
            return fontAsset;
        }

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
    }
}

#region Data

public enum FontOption
{
    None = 0,
    NotoSansCJK = 1,
}

public enum DisplayLanguageOption
{
    None = 0,
    ZH_HK = 1,
    ZH_TW = 2,
}

#endregion