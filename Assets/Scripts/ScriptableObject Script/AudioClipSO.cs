using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipSO : ScriptableObject
{
    public AudioClip backgroundMusic;

    public AudioClip[] collectSound;
    public AudioClip fartSound;
    public AudioClip footstep;
    public AudioClip warning;
}