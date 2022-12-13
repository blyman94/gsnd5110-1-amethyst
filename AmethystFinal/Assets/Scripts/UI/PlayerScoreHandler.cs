using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreHandler : MonoBehaviour
{
    [SerializeField] private StoryDataVariable _activeStoryData;
    [SerializeField] private PostDecisionVariable _postDecisionVariable;
    [SerializeField] private IntVariable _playerComments;
    [SerializeField] private IntVariable _playerFollowers;

    public void UpdatePlayerScore()
    {
        if (_postDecisionVariable.Value == PostDecision.Anonymous)
        {
            _playerComments.Value = _playerComments.Value +
                                    _activeStoryData.Value.CommentDelta.x;
            _playerFollowers.Value = _playerFollowers.Value +
                                     _activeStoryData.Value.FollowerDelta.x;
        }
        if (_postDecisionVariable.Value == PostDecision.Government)
        {
            _playerComments.Value = _playerComments.Value +
                                    _activeStoryData.Value.CommentDelta.y;
            _playerFollowers.Value = _playerFollowers.Value +
                                     _activeStoryData.Value.FollowerDelta.y;
        }
        
    }

}
