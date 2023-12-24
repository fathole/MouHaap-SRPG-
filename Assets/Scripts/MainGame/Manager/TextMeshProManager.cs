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
        
        [SerializeField] private SerializableDictionaryBase<FontOption, Font> fontOptionToFontDict;
         private TMP_FontAsset fontAsset;

        #endregion

        #region Function - Init

        public void InitManager()
        {
            Debug.Log("--- TextMeshProManager: InitManager ---");
        }

        #endregion

        #region Functioon - Public

        public IEnumerator GenerateFontAssetCoroutine(FontOption fontOption, string textContent)
        {
            if( fontOptionToFontDict.TryGetValue(fontOption, out Font font))
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

        #endregion
    }
}