using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundTrack;
    public AudioSource buttonSFXSource;
    public AudioSource otherSFXSource;
    public static SoundManager Instance {get; private set;}

    [SerializeField] private float fadeDuration = 5f;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void playBackGroundTrack(AudioClip clip)
    {
        backgroundTrack.clip = clip;
        backgroundTrack.loop = true;
        backgroundTrack.Play();
    }

    public void switchBackGroundTrack(AudioClip clip)
    {
        backgroundTrack.Stop();
        playBackGroundTrack(clip);
    }
    public void playButtonSFX(AudioClip clip)
    {
        buttonSFXSource.PlayOneShot(clip);
    }
    public void playOtherSFX(AudioClip clip)
    {
        otherSFXSource.PlayOneShot(clip);
    }

    public void switchBackGroundTrackWithFade(AudioClip clip) //for fun
    {
        StartCoroutine(FadeTrack(clip));
    }

    private IEnumerator FadeTrack(AudioClip clip)
    {
        float startingVolume = backgroundTrack.volume;

        while (backgroundTrack.volume > 0) // fade out loop
        {
            backgroundTrack.volume -= startingVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
        
        switchBackGroundTrack(clip);

        while (backgroundTrack.volume < startingVolume) //fade in loop
        {
            backgroundTrack.volume += startingVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
        backgroundTrack.volume = startingVolume; //just in case it doesn't reach original volume
    }
}