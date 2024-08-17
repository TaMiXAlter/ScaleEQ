using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigi;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpHeight;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigi.velocity = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, rigi.velocity.y, rigi.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.velocity = new Vector3(rigi.velocity.x, JumpHeight, rigi.velocity.z);
        }
    }
}
