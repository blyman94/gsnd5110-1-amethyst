using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float moveSpeed;

    public void Move(Vector2 moveInput)
    {
        rb2D.velocity = moveInput.normalized * moveSpeed;
    }
}
