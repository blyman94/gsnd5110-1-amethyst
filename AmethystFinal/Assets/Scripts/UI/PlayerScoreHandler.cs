using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreHandler : MonoBehaviour
{
    [SerializeField] private StoryDataVariable _activeStoryData;
    [SerializeField] private IntVariable _playerComments;
    [SerializeField] private IntVariable _playerFollowers;

    public void UpdatePlayerScore()
    {
        _playerComments.Value = _playerComments.Value +
                                _activeStoryData.Value.CommentDelta;
        _playerFollowers.Value = _playerFollowers.Value +
                                 _activeStoryData.Value.FollowerDelta;
    }

}
