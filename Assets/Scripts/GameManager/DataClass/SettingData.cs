using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettingData
{    
    public float bGMVolume;
    public float sFXVolume;
    public float voiceOverVolume;

    public DisplayLanguageOption displayLanguageOption;
    public VoiceOverLanguageOption VoiceOverLanguageOption;

    public static GameSettingData DefaultSettingData()
    {
        // Generate Default Setting Data
        GameSettingData settingData = new GameSettingData
        {
            bGMVolume = 0.5f,
            sFXVolume = 0.5f,
            voiceOverVolume = 0.5f,

            displayLanguageOption = DisplayLanguageOption.ZH_HK,
            VoiceOverLanguageOption = VoiceOverLanguageOption.ZH_HK,
        };

        // Return Default Setting Data
        return settingData;
    }
}
