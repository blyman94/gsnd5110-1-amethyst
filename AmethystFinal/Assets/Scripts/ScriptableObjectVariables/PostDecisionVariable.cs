using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object Variable/Post Decision",
    fileName = "New Post Decision Variable")]
public class PostDecisionVariable : ScriptableObjectVariable<PostDecision>
{
    public int IntValue
    {
        get
        {
            return (int)Value;
        }
        set
        {
            Value = (PostDecision)value;
        }
    }
}
