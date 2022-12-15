using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreResetter : MonoBehaviour
{
    [SerializeField] private IntVariable _followerCount;
    [SerializeField] private IntVariable _commentCount;

    private void Start()
    {
        _followerCount.Value = 0;
        _commentCount.Value = 0;
    }
}
