using UnityEngine;
using UnityEngine.Events;

public class PlayParticleEffectOnTimer : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystemsToPlay;
    [SerializeField] private UnityEvent _onParticleStopEvent;
    [SerializeField] private UnityEvent _onParticleStartEvent;

    private float _effectTimer = 0.0f;
    
    #region MonoBehaviour Methods
    private void Update()
    {
        if (!(_effectTimer > 0.0f)) return;
        _effectTimer -= Time.deltaTime;
        
        if (!(_effectTimer <= 0.0f)) return;
        
        foreach (var particleSystem in _particleSystemsToPlay)
        {
            particleSystem.Stop();
            _onParticleStopEvent?.Invoke();
        }
    }
    #endregion

    public void Play(float playTime)
    {
        foreach (var particleSystem in _particleSystemsToPlay)
        {
            particleSystem.Play();
        }
        _onParticleStartEvent?.Invoke();
        _effectTimer = playTime;
    }
}
