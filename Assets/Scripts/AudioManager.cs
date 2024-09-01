using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource;

    public AudioClip jumpSound;
    public AudioClip starCollectSound;
    public AudioClip colorSwitchSound;
    public AudioClip gameOverSound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void PlayJumpSound()
    {
        PlaySound(jumpSound);
    }

    public void PlayStarCollectSound()
    {
        PlaySound(starCollectSound);
    }

    public void PlayColorSwitchSound()
    {
        PlaySound(colorSwitchSound);
    }

    public void PlayGameOverSound()
    {
        PlaySound(gameOverSound);
    }
    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
