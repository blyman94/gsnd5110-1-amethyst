using UnityEngine;
using UnityEngine.Events;

public class AnimationSpacing : MonoBehaviour
{
    [SerializeField] private UnityEvent _onSpacingEndResponse;

    public float Timer { get; set; }

    private void Update()
    {
        if (Timer > 0.0f)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0.0f)
            {
                _onSpacingEndResponse?.Invoke();
            }
        }
    }
}
