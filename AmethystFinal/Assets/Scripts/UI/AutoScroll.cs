using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum AutoScrollDirection {BottomToTop, TopToBottom};
public class AutoScroll : MonoBehaviour
{
    [SerializeField] private ScrollRect _rectToScroll;
    [SerializeField] private AutoScrollDirection _scrollDirection =
        AutoScrollDirection.BottomToTop;
    [SerializeField] private float _autoScrollSpeed = 0.025f;
    [SerializeField] private UnityEvent _onScrollEndEvent;

    public bool IsScrolling { get; set; } = false;

    public float AutoScrollSpeed
    {
        get
        {
            return _autoScrollSpeed;
        }
        set
        {
            _autoScrollSpeed = value;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeScrollPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsScrolling)
        {
            if (_scrollDirection == AutoScrollDirection.BottomToTop)
            {
                ScrollBottomToTop();
            }
            else
            {
                ScrollTopToBottom();
            }
        }
    }

    private void ScrollBottomToTop()
    {
        _rectToScroll.verticalNormalizedPosition -=
            _autoScrollSpeed * Time.deltaTime;
        if (_rectToScroll.verticalNormalizedPosition <= 0.0f)
        {
            IsScrolling = false;
            _rectToScroll.verticalNormalizedPosition = 0.0f;
            _onScrollEndEvent?.Invoke();
        }
    }
    
    private void ScrollTopToBottom()
    {
        _rectToScroll.verticalNormalizedPosition +=
            _autoScrollSpeed * Time.deltaTime;
        if (_rectToScroll.verticalNormalizedPosition >= 1.0f)
        {
            IsScrolling = false;
            _rectToScroll.verticalNormalizedPosition = 1.0f;
            _onScrollEndEvent?.Invoke();
        }
    }

    private void InitializeScrollPosition()
    {
        if (_scrollDirection == AutoScrollDirection.BottomToTop)
        {
            _rectToScroll.verticalNormalizedPosition = 1.0f;
        }
        else
        {
            _rectToScroll.verticalNormalizedPosition = 0.0f;
        }
    }
}
