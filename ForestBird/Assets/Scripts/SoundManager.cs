using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioClip backgroundMusic;
    [SerializeField] public AudioClip hitSound;
    [SerializeField] public AudioClip scoreSound;

    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource soundEffectsSource;

    private void Start()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void IncreaseScore()
    {
        soundEffectsSource.PlayOneShot(scoreSound);
    }

    public void HitObject()
    {
        soundEffectsSource.PlayOneShot(hitSound);
    }
}