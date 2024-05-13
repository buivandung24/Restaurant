using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip backGround;
    void Start()
    {
        musicSource.clip = backGround;
        musicSource.Play();
    }
}
