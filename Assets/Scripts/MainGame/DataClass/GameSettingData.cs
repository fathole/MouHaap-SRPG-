using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameSettingData
{
    [Header("Audio")]
    public bool isEnableBGM;
    public bool isEnableSFX;
    public bool isEnableVO;
    public float bGMVolume;
    public float sFXVolume;
    public float vOVolume;
    public VOLanguageOption vOLanguage;

    [Header("Display")]
    public DisplayLanguageOption displayLanguage;
    public FontOption font;

    public static GameSettingData DefaultGameSettingData()
    {
        GameSettingData defaultGameSettingData = new GameSettingData()
        {
            // Audio
            isEnableBGM = true,
            isEnableSFX = true,
            isEnableVO = true,
            bGMVolume = 1f,
            sFXVolume = 1f,
            vOVolume = 1f,
            vOLanguage = VOLanguageOption.ZH_HK,

            // Display
            displayLanguage = DisplayLanguageOption.ZH_HK,
            font = FontOption.SourceHanSansHK,
        };

        return defaultGameSettingData;
    }
}

public enum DisplayLanguageOption
{
    ZH_HK,
}
public enum VOLanguageOption
{
    ZH_HK,
}
public enum FontOption
{
    NotoSansCJK,
    SourceHanSansHK,
}
