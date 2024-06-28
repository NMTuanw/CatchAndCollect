using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipSO : ScriptableObject
{
    public AudioClip backgroundMusic;

    public AudioClip[] collectSounds;
    public AudioClip collectSound;
    public AudioClip buttonSound;
    public AudioClip bonusSound;
    public AudioClip swordSound;
    public AudioClip playerDeadSound;


    public AudioClip fartSound;
    public AudioClip footstep;
    public AudioClip warning;
}