using UnityEngine;
using TT.DesignPattern;
using System;
using TT.Data.Base;


namespace TT.Audio.Base
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : SingletonBehaviour<AudioManager>
    {
        [SerializeField] protected bool muteMusic;
        [Range(0f, 1f)][SerializeField] protected float musicVolume;

        [SerializeField] protected bool muteSfx;
        [Range(0f, 1f)][SerializeField] protected float sfxVolume;

        [SerializeField] protected bool loadAllAudio = false;
        [SerializeField] protected AudioClip[] musics;
        [SerializeField] protected AudioClip[] sfxs;

        protected AudioSource audio_source;

        protected override void Awake()
        {
            base.Awake();
            audio_source = GetComponent<AudioSource>();
            if (loadAllAudio)
            {
                musics = ResourceManager.Instance.GetAssets<AudioClip>("Audio/Music/");
                sfxs = ResourceManager.Instance.GetAssets<AudioClip>("Audio/SFX/");
            }
        }

        public virtual void PlayMusic(string name, bool loop)
        {
            AudioClip audio = GetAudioClip(name);
            if (audio == null)
            {
                Debug.Log(string.Format("Sound {0} Not Found", name));
            }
            else
            {
                audio_source.clip = audio;
                audio_source.loop = loop;
                audio_source.Play();
            }
        }

        public virtual void PlaySFX(string name)
        {
            AudioClip audio = GetAudioClip(name);
            if (audio == null)
            {
                Debug.Log(string.Format("SFX {0} Not Found", name));
            }
            else
            {
                audio_source.PlayOneShot(audio);
            }
        }

        protected AudioClip GetAudioClip(string name)
        {
            AudioClip audio = null;
            if (loadAllAudio)
            {
                audio = ResourceManager.Instance.GetAsset<AudioClip>("Data/Audio/" + name);
            }
            else
            {
                audio = Array.Find(sfxs, s => s.name == name);
            }

            return audio;
        }

        public virtual void ToggleMusic()
        {
            muteMusic = !muteMusic;
        }

        public virtual void ToggleSFX()
        {
            muteSfx = !muteSfx;
        }

        public virtual void ChangeMusicVolume(float volume)
        {
            musicVolume = volume;
        }

        public virtual void ChangeSFXVolume(float volume)
        {
            sfxVolume = volume;
        }

        public virtual void SaveAudioSetting()
        {

        }
    }
}
