using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set;}

    [SerializeField] private AudioClip backgroundMusic;

    [Header("Reference to AudioSource")]
    [SerializeField] private AudioSource musicSource;

    private void Awake() {
        Instance = this;

        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBackgroundMusic(backgroundMusic);
    }

    private void PlayBackgroundMusic(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }


}
