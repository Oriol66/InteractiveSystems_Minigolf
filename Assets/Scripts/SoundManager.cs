using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip bubblePopClip;
    public AudioClip collisionSound;
    public AudioClip popOutCollider;
    public AudioClip youWin;
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayBubblePopSound()
    {
        if (bubblePopClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(bubblePopClip);
        }
    }

    public void PlayCollisionSound()
    {
        if (collisionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    public void PlayPopOutCollider()
    {
        if (popOutCollider != null && audioSource != null)
        {
            audioSource.PlayOneShot(popOutCollider);
        }
    }

    public void PlayYouWinMusic()
    {
        if (youWin != null && audioSource != null)
        {
            audioSource.PlayOneShot(youWin);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && audioSource != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; 
            audioSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }


}

