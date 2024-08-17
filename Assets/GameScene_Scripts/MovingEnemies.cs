using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private Rigidbody rigi;

    public float amplitude = 1.0f;
    public float frequency = 1.0f;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();

    }

    void Update()
    {

        float sineWave = Mathf.Sin(Time.time * frequency) * amplitude;
        rigi.velocity = new Vector3(rigi.velocity.x + MoveSpeed * Time.deltaTime, sineWave, rigi.velocity.z);
    }
}
