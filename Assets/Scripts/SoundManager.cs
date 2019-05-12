using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource laserSource;
    public AudioSource laserShotSource;

    public AudioClip laserOn;
    public AudioClip laserOff;
    public AudioClip laserShot;

    public AudioClip demonLaugh;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void PlayLaserOnSound() {
        laserSource.volume = 0.3f;
        laserSource.clip = laserOn;
        laserSource.Play();
    }

    public void PlayLaserOffSound() {
        laserSource.volume = 1.0f;
        laserSource.clip = laserOff;
        laserSource.Play();
    }

    public void PlayLaserShot() {
        laserShotSource.volume = 1.0f;
        laserShotSource.PlayOneShot(laserShot);
    }

    public void PlayDemonLaugh() {
        laserShotSource.volume = 1.0f;
        laserShotSource.PlayOneShot(demonLaugh);
    }
}
