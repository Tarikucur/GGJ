using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<AudioClip> sounds;
    private AudioSource audioSource;
    private GameManager gm;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sounds[13];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }
}