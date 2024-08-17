using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private Rigidbody2D rigi;
    [SerializeField] private float amplitude = 1.0f;
    [SerializeField] private float frequency = 1.0f;


    public enum MovementType
    {
        HorizontalMoving,
        WavesMoving,
        FacingPlayer

    }
    public MovementType movementType;
    private GameObject Player;


    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float sineWave = Mathf.Sin(Time.time * frequency) * amplitude;

        switch (movementType)
        {
            case MovementType.HorizontalMoving:
                rigi.velocity = new Vector2(MoveSpeed, rigi.velocity.y);
                break;
            case MovementType.WavesMoving:
                rigi.velocity = new Vector2(MoveSpeed, sineWave);
                break;
            case MovementType.FacingPlayer:
                MoveTowardsPlayer(GameObject.FindWithTag("Player"));
                Destroy(gameObject, 5);
                break;
        }


    }
    void MoveTowardsPlayer(GameObject Player)
    {
        Vector2 direction = (Player.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        rigi.velocity = direction * MoveSpeed;
    }
}
