using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettingData
{
    public bool isEnableMusic;
    public bool isEnableSFX;
    public bool isEnableVoiceOver;
    public float musicVolume;
    public float sFXVolume;
    public float voiceOverVolume;

    public bool isFullScreen;
    public int windowSizeIndex;

    public DisplayLanguageOption displayLanguageOption;
    public VoiceOverLanguageOption VoiceOverLanguageOption;

    public static GameSettingData DefaultSettingData()
    {
        // Generate Default Setting Data
        GameSettingData settingData = new GameSettingData
        {
            isEnableMusic = true,
            isEnableSFX = true,
            isEnableVoiceOver = true,
            musicVolume = 0.5f,
            sFXVolume = 0.5f,
            voiceOverVolume = 0.5f,

            isFullScreen = true,
            windowSizeIndex = 0,

            displayLanguageOption = DisplayLanguageOption.ZH_HK,
            VoiceOverLanguageOption = VoiceOverLanguageOption.ZH_HK,
        };

        // Return Default Setting Data
        return settingData;
    }
}

public enum DisplayLanguageOption
{
    None = 0,
    ZH_HK = 1,
    ZH_TW = 2,
}

public enum VoiceOverLanguageOption
{
    None = 0,
    ZH_HK = 1,
}

public enum FontOption
{
    None = 0,
    NotoSansCJK = 1,
}