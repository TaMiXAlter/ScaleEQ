using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigi;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpHeight;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigi.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rigi.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, JumpHeight);
        }
    }
}
