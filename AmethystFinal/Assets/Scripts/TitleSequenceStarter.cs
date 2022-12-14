using System;
using UnityEngine;

[Serializable]
public enum AnimationType {Fade, Slide, Stamp}

public class TitleSequenceStarter : MonoBehaviour
{
    [SerializeField] private TitleTextAnimationHandler _titleAnimationHandler;
    [SerializeField] private TitleTextAnimationHandler _subTitleAnimationHandler;
    [SerializeField] private AnimationType _titleAnimationType;
    [SerializeField] private AnimationType _subTitleAnimationType;

    private void Start()
    {
        PlayTitleAnimation();
    }

    public void PlayTitleAnimation()
    {
        switch (_titleAnimationType)
        {
            case AnimationType.Fade:
                _titleAnimationHandler.PlayFadeInAnimation();
                break;
            case AnimationType.Slide:
                _titleAnimationHandler.PlaySlideAnimation();
                break;
            case AnimationType.Stamp:
                _titleAnimationHandler.PlayStampAnimation();
                break;
        }
    }
    public void PlaySubTitleAnimation()
    {
        switch (_subTitleAnimationType)
        {
            case AnimationType.Fade:
                _subTitleAnimationHandler.PlayFadeInAnimation();
                break;
            case AnimationType.Slide:
                _subTitleAnimationHandler.PlaySlideAnimation();
                break;
            case AnimationType.Stamp:
                _subTitleAnimationHandler.PlayStampAnimation();
                break;
        }
    }
}
