using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxSource;
    
    public void PlayEffectRandomPitch(AudioClip clip)
    {
        _sfxSource.pitch = Random.Range(0.6f, 1.4f);
        _sfxSource.PlayOneShot(clip);
    }
}
