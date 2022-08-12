using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;
    

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        
    }

    public void Sound(int number) //Sound(0) Sound(1)�� ��밡��
    {
        audioSource.PlayOneShot(audioClip[number]);
    }
}
