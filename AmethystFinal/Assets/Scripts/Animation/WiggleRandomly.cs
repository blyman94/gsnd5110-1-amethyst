using UnityEngine;

public class WiggleRandomly : MonoBehaviour
{
    [SerializeField] private float _maxRotationOffset = 0.5f;
    [SerializeField] private float _baseWiggleSpeed = 1.0f;
    [SerializeField] private float _wiggleSpeedVariance = 0.5f;

    private float _wiggleSpeed;
    private bool _isWiggling = false;
    
    private Vector3 _maxRotation; 
    private Vector3 _minRotation; 
    private Vector3 _to;
    private Vector3 _from;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _maxRotation = new Vector3(0.0f, 0.0f, _maxRotationOffset);
        _minRotation = new Vector3(0.0f, 0.0f, -_maxRotationOffset);
    }
    
    private void Start()
    {
        StartWiggle();
    }

    private void Update()
    {
        if (_isWiggling)
        {
            float t = (Mathf.Sin (Time.time * _wiggleSpeed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
            transform.eulerAngles = Vector3.Lerp (_from, _to, t);
        }
    }
    #endregion

    public void StartWiggle()
    {
        _isWiggling = true;
        
        // Choose direction
        bool rotateClockwise = (Random.value > 0.5f);
        if (rotateClockwise)
        {
            _from = _maxRotation;
            _to = _minRotation;
        }
        else
        {
            _from = _minRotation;
            _to = _maxRotation;
        }
        
        // Choose speed
        _wiggleSpeed = Random.Range(_baseWiggleSpeed - _wiggleSpeedVariance,
            _baseWiggleSpeed + _wiggleSpeedVariance);
    }

    public void StopWiggle()
    {
        _isWiggling = false;
        transform.eulerAngles = Vector3.zero;
    }
}
