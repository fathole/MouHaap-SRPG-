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

        public void SetBGMVolume(float volume)
        {
            audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        }

        public void SetSFXVolume(float volume)
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        }

        public void SetVoiceOverVolume(float volume)
        {
            audioMixer.SetFloat("VoiceOverVolume", Mathf.Log10(volume) * 20);
        }

        #endregion
    }
}