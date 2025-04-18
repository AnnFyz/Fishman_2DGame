using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }
    public SoundSO[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }


        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    private void Start()
    {
        PlaySound("BackgroundMusic");
    }
    public void PlaySound(string soundName)
    {
        SoundSO s = System.Array.Find(sounds, sound => sound.soundName == soundName);
        if (s == null)
        {
            Debug.Log("Sound is not found");
            return;
        }
        else
        {
            s.audioSource.Play();
        }

    }

    public void StopSound(string soundName)
    {
        SoundSO s = System.Array.Find(sounds, sound => sound.soundName == soundName);
        if (s == null)
        {
            Debug.Log("Sound is not found");
            return;
        }
        else
        {
            s.audioSource.Stop();
        }

    }

    public SoundSO GetSound(string soundName)
    {
        SoundSO s = System.Array.Find(sounds, sound => sound.soundName == soundName);
        if (s == null)
        {
            Debug.Log("Sound is not found");
            return null;
        }
        else
        {
            return s;
        }
    }
}
