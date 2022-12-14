using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _playingVolume;
    [SerializeField] private AudioClip[] _songs;
    
    [Header("Events")] 
    [SerializeField] private UnityEvent _fadeInCompleteEvent;
    [SerializeField] private UnityEvent _fadeOutCompleteEvent;

    public bool TriggerEvent { get; set; } = true;

    private int _songIndex = 0;
    private float _fadeTime;
    private float _elapsedTime;
    private bool _fadingIn;
    private bool _fadingOut;
    
    #region MonoBehaviour Methods
    private void Update()
    {
        if (_fadingIn)
        {
            _audioSource.volume = Mathf.Lerp(0.0f, _playingVolume,
                _elapsedTime / _fadeTime);
            _elapsedTime += Time.deltaTime;
            if (_audioSource.volume >= _playingVolume)
            {
                _fadingIn = false;
                if (TriggerEvent)
                {
                    _fadeInCompleteEvent?.Invoke();
                }
            }
        }
        else if (_fadingOut)
        {
            _audioSource.volume = Mathf.Lerp(_playingVolume, 0.0f,
                _elapsedTime / _fadeTime);
            _elapsedTime += Time.deltaTime;
            if (_audioSource.volume <= 0.0f)
            {
                _fadingOut = false;
                _audioSource.volume = 0.0f;
                if (TriggerEvent)
                {
                    _fadeOutCompleteEvent?.Invoke();
                }
            }
        }
    }
    #endregion

    public void MoveToNextSong()
    {
        if (_songIndex + 1 < _songs.Length)
        {
            _songIndex++;
        }
        else
        {
            _songIndex = 0;
        }
        _audioSource.clip = _songs[_songIndex];
        _audioSource.Play();
    }

    public void FadeOutSkipEvent(float fadeTime)
    {
        TriggerEvent = false;
        FadeOut(fadeTime);
    }

    public void FadeOut(float fadeTime)
    {
        _fadingOut = true;
        _fadingIn = false;
        
        _audioSource.volume = _playingVolume;
        _fadeTime = fadeTime;
        _elapsedTime = 0.0f;
    }
    
    public void FadeIn(float fadeTime)
    {
        TriggerEvent = true;
        _fadingOut = false;
        _fadingIn = true;
        
        _audioSource.volume = 0.0f;
        _fadeTime = fadeTime;
        _elapsedTime = 0.0f;
    }
}
