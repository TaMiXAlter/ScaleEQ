using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    public float MoveSpeed { get; set; }
    private Rigidbody2D rigi;
    [SerializeField] private float amplitude = 1.0f;
    [SerializeField] private float frequency = 1.0f;

    private Vector2 targetPosition;

    public enum MovementType
    {
        HorizontalMoving,
        WavesMoving,
        FacingPlayer

    }
    public MovementType movementType;



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
                MoveTowardsPlayer();
                break;
        }
    }
    public void SetTargetPosition(Vector2 playerPosition)
    {
        targetPosition = playerPosition;
    }
    void MoveTowardsPlayer()
    {

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        rigi.velocity = direction * MoveSpeed;
    }
}
