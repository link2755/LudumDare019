using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public bool mainMenu = true;

    private void Start()
    {
        Play("Game Song");
    }

    void Awake () {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
		
	}

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => name == sound.name);
        if (s.source.loop == false)
        {
            s.source.PlayOneShot(s.source.clip);
        } else
        {
            s.source.Play();
        }

        mainMenu = (name == "MainMenuTheme" || (name == "ShotKill" && mainMenu == true)) ? true : false;

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => name == sound.name);
        
         s.source.Stop();

    }

    public void StopAll()
    {

        AudioSource[] audioallAudioSources = FindObjectsOfType<AudioSource>() as AudioSource[];
        foreach (AudioSource audioS in audioallAudioSources)
        {
            audioS.Stop();
        }

    }
}
