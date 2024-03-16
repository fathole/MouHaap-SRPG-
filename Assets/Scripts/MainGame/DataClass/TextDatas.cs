using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "Text Datas", menuName = "TW/Text Data")]
public class TextDatas : ScriptableObject
{
    public SerializableDictionaryBase<string, TextData> keyToTextContentDict;
}

[Serializable]
public class TextData
{
    public string ZH_HK;
    public string ZH_TW;
}
