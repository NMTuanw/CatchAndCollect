using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Reference to Slider")]
    public Slider musicSlider;
    public Slider soundSlider;

    [Header("Reference to AudioSource")]
    public AudioSource musicSource;
    public AudioSource soundSource;

    [Header("Reference to Audio Clip")]
    public AudioClipSO audioClipSO;

    public AudioClip fartSound;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        musicSource.clip = audioClipSO.backgroundMusic;
        musicSource.Play();

    }

    public void PlaySound(AudioClip audioClip)
    {
        soundSource.PlayOneShot(audioClip);
    }
}
