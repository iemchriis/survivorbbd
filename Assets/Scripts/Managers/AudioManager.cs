using System;
using Helpers;
using UnityEngine;


    public class AudioManager : MonoBehaviour
    {
        public Action OnSoundPlayed;
        public static AudioManager Instance;

        public Sound[] MusicSounds, SfXSounds;
        public AudioSource musicSource, SFXSource;
        
        public delegate void OnAudioManagerInitialized();
        public event OnAudioManagerInitialized onInitialized;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                
                // Trigger the initialized event
                onInitialized?.Invoke();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        
    public void Music(float i)
    {
        musicSource.volume = i;
    }


    public void SFX(float i)
    {
        SFXSource.volume = i;
    }


        public void PlayMusic(string name)
        {

            Sound s = Array.Find(MusicSounds, x => x.name == name);

            if(s == null)
            {
                UnityEngine.Debug.Log("No Sound");
            }
            else
            {
                musicSource.clip = s.clip;
                musicSource.Play();

            }
        }


        public void PlaySFX(string name)
        {

            Sound s = Array.Find(SfXSounds, x => x.name == name);

            if (s == null)
            {
                UnityEngine.Debug.Log("No Sound");
            }
            else
            {
                SFXSource.clip = s.clip;
                SFXSource.Play();
                OnSoundPlayed?.Invoke();
            }
        }


       
    }

