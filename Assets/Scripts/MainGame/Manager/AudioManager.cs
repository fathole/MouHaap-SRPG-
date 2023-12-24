using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace MainGame
{
    public class AudioManager : MonoBehaviour
    {
        #region Declaration

        [Header("Audio Mixer")]
        private AudioMixer audioMixer;

        #endregion

        #region Function - Init

        public void InitManager(AudioMixer audioMixer)
        {
            Debug.Log("--- AudioManager: InitManager ---");

            this.audioMixer = audioMixer;
        }

        #endregion

        #region Function - Public

        public void SetBGMVolume(float volume, bool isMute = false)
        {
            // If Is Mute, Set The Volume To 0
            if(isMute == true)
            {
                audioMixer.SetFloat("BGMVolume", Mathf.Log10(0.001f) * 20);
            }
            // Else, Update The Volume To Target Volume
            else
            {
                audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
            }
        }

        public void SetSFXVolume(float volume, bool isMute = false)
        {
            // If Is Mute, Set The Volume To 0
            if (isMute == true)
            {
                audioMixer.SetFloat("SFXVolume", Mathf.Log10(0.001f) * 20);
            }
            // Else, Update The Volume To Target Volume
            else
            {
                audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
            }
        }

        public void SetVOVolume(float volume, bool isMute = false)
        {
            // If Is Mute, Set The Volume To 0
            if (isMute == true)
            {
                audioMixer.SetFloat("VOVolume", Mathf.Log10(0.001f) * 20);
            }
            // Else, Update The Volume To Target Volume
            else
            {
                audioMixer.SetFloat("VOVolume", Mathf.Log10(volume) * 20);
            }
        }

        #endregion
    }
}