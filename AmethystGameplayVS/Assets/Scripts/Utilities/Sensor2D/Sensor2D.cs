using UnityEngine;

/// <summary>
/// Uses Physics.Overlap[Shape] to detect an object on whichever layers are to 
/// be sensed by this sensor. An active sensor means something in the target
/// layer is currently colliding with the sensor.
/// </summary>
public class Sensor2D : MonoBehaviour
{
    /// <summary>
    /// Signals the sensor's active state has changed.
    /// </summary>
    public SensorStateChanged SensorStateChanged;

    /// <summary>
    /// The sensor is considered active when it overlaps an object on 
    /// layerToSense and with the tagToSense (if SenseTag is true).
    /// </summary>
    [Tooltip("The sensor is considered active when it overlaps an object on" +
        "layerToSense and with the tagToSense (if SenseTag is true).")]
    [SerializeField] private bool _active = true;

    /// <summary>
    /// Color of the gizmo depicting this sensor when active.
    /// </summary>
    [Tooltip("Color of the gizmo depicting this sensor when active.")]
    [SerializeField] private Color _activeColor = Color.white;

    /// <summary>
    /// Color of the gizmo depicting this sensor when inactive.
    /// </summary>
    [Tooltip("Color of the gizmo depicting this sensor when inactive.")]
    [SerializeField] private Color _inactiveColor = Color.white;

    /// <summary>
    /// Which layer(s) should this sensor detect?
    /// </summary>
    [Tooltip("Which layer(s) should this sensor detect?")]
    [SerializeField] private LayerMask _layerToSense;

    /// <summary>
    /// Radius of the sensor if it is a circle.
    /// </summary>
    [Tooltip("Radius of the sensor if it is a circle.")]
    [SerializeField] private float _radius;

    /// <summary>
    /// Should this sensor only sense a specific tag?
    /// </summary>
    [Tooltip("Should this sensor only sense a specific tag?")]
    [SerializeField] private bool _senseTag;

    /// <summary>
    /// Primitive shape of the sensor.
    /// </summary>
    [Tooltip("Primitive shape of the sensor.")]
    [SerializeField] private SensorShape _sensorShape;

    /// <summary>
    /// Size of the sensor if it is a square.
    /// </summary>
    [Tooltip("Size of the sensor if it is a square.")]
    [SerializeField] private Vector2 _squareSize;

    /// <summary>
    /// If SenseTag is true, this sensor will only sense objects on 
    /// layerToSense with this tag.
    /// </summary>
    [Tooltip("If SenseTag is true, this sensor will only sense objects on " +
        "layerToSense with this tag.")]
    [SerializeField] private string _tagToSense;

    /// <summary>
    /// The sensor is considered active when it overlaps an object on 
    /// layerToSense and with the tagToSense (if SenseTag is true).
    /// </summary>
    public bool Active
    {
        get
        {
            return _active && !IsDisabled;
        }
        set
        {
            if (value != _active)
            {
                _active = value;
                SensorStateChanged?.Invoke();
            }
        }
    }

    /// <summary>
    /// Timer for how long the sensor should be disabled. Disabled sensors
    /// are always considered not active.
    /// </summary>
    public float DisabledTimer { get; set; }

    /// <summary>
    /// Flag for whether this sensor is disabled. Disabled sensors are always
    /// considered not active.
    /// </summary>
    public bool IsDisabled
    {
        get
        {
            return DisabledTimer >= 0.0f;
        }
    }

    /// <summary>
    /// Array of all Collider2Ds detected.
    /// </summary>
    private Collider2D[] _detectedColliders;

    #region MonoBehaviour Methods
    private void FixedUpdate()
    {
        // Detect all colliders
        switch (_sensorShape)
        {
            case SensorShape.Square:
                _detectedColliders = Physics2D.OverlapBoxAll(transform.position,
                    _squareSize * 0.5f, 0.0f, _layerToSense);
                break;
            case SensorShape.Circle:
                _detectedColliders = Physics2D.OverlapCircleAll(transform.position,
                    _radius, _layerToSense);
                break;
            default:
                break;
        }

        // If sensing for a tag, check if at least one detected collider has
        // tagToSense. Otherwise, activate if at least one collider is detected.
        if (_detectedColliders.Length > 0)
        {
            if (_senseTag && _tagToSense != "")
            {
                bool atLeastOneTagSensed = false;
                foreach (Collider2D collider in _detectedColliders)
                {
                    if (collider.CompareTag(_tagToSense))
                    {
                        atLeastOneTagSensed = true;
                        break;
                    }
                }
                Active = atLeastOneTagSensed;
            }
            else
            {
                Active = true;
            }
        }
        else
        {
            Active = false;
        }
    }

    private void Update()
    {
        if (DisabledTimer >= 0.0f)
        {
            DisabledTimer -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Active ? _activeColor : _inactiveColor;

        switch (_sensorShape)
        {
            case SensorShape.Square:
                Gizmos.DrawCube(transform.position, _squareSize);
                break;
            case SensorShape.Circle:
                Gizmos.DrawSphere(transform.position, _radius);
                break;
            default:
                break;
        }
    }
    #endregion    
}
