using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set;}

    [Header("Reference to Slider")]
    [SerializeField] private AudioClipSO audioClipSO;

    [Header("Reference to AudioSource")]
    [SerializeField] private AudioSource soundSource;

    private float volume = 1f;

    private void Awake() {
        Instance = this;

        soundSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Register to event
        Item.OnItemCollect += Item_OnItemCollect;
    }
    private void Item_OnItemCollect(object sender, System.EventArgs e)
    {
        Item item = sender as Item;
        PlaySound(audioClipSO.fartSound);
    }

    private void OnDisable()
    {
        // Unregister from event
        Item.OnItemCollect -= Item_OnItemCollect;
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }
    private void PlayRandomSound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    public void PlayFootstepSound(Vector3 position, float volume)
    {
        PlaySound(audioClipSO.footstep, position, volume);
    }

    public void PlayCountdownNumber()
    {
        PlaySound(audioClipSO.warning, Vector3.zero);
    }

    public void playWarningSound(Vector3 position)
    {
        PlaySound(audioClipSO.warning, position);
    }

    public void PlaySound(AudioClip audioClip)
    {
        soundSource.PlayOneShot(audioClip);
    }
}
