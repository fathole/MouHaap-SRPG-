using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameManager
{
    public class AudioManager : MonoBehaviour
    {
        #region Declaration

        private AudioMixer audioMixer = null;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            audioMixer = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(AudioMixer audioMixer)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.audioMixer = audioMixer;
        }

        #endregion

        #region Main Function

        public void SetMusicVolume(bool isEnable, float volume)
        {
            if(isEnable == true)
            {
                audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
            }
            else
            {
                audioMixer.SetFloat("MusicVolume", Mathf.Log10(0.001f) * 20);
            }
        }

        public void SetSFXVolume(bool isEnable, float volume)
        {
            if (isEnable == true)
            {
                audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
            }
            else
            {
                audioMixer.SetFloat("SFXVolume", Mathf.Log10(0.001f) * 20);
            }
        }

        public void SetVoiceOverVolume(bool isEnable, float volume)
        {
            if (isEnable == true)
            {
                audioMixer.SetFloat("VoiceOverVolume", Mathf.Log10(volume) * 20);
            }
            else
            {
                audioMixer.SetFloat("VoiceOverVolume", Mathf.Log10(0.001f) * 20);
            }
        }

        #endregion
    }
}