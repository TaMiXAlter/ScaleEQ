using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    public float MoveSpeed { get; set; }
    public float amplitude { get; set; }
    public float frequency { get; set; }

    private Rigidbody2D rigi;
    private Vector2 playerPosition;
    public Vector2 lastDirection { get; private set; }
    private bool targetReached = false;

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
        SetMovementType(movementType);
        SinWaves();
    }
    private void MoveTowardsPlayer()
    {
        //============ Direction setting
        if (!targetReached)
        {
            Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

            if (Vector2.Distance(transform.position, playerPosition) < 0.1f)
            {
                targetReached = true;
            }
            else
            {
                lastDirection = direction;

            }
        }
        //============ Raycast

        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, Mathf.Infinity, LayerMask.GetMask("aware"));
        if (hit.collider != null)
        {
            SpriteRenderer spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Calculate the distance between the object and the hit point
                float distance = Vector2.Distance(transform.position, hit.point);

                // If the distance is less than 1, set alpha to 1; otherwise, set it to 0
                if (distance < 1.5f)
                {
                    Color color = spriteRenderer.color;
                    color.a = 0f;
                    spriteRenderer.color = color;
                }
                else
                {
                    Color color = spriteRenderer.color;
                    color.a = 1f;
                    spriteRenderer.color = color;
                }
            }
        }

        //============ Angle setting
        float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //============ Velocity setting
        rigi.velocity = lastDirection * MoveSpeed;
    }
    private void SetMovementType(MovementType movementType)
    {
        switch (movementType)
        {
            case MovementType.HorizontalMoving:
                rigi.velocity = new Vector2(MoveSpeed, rigi.velocity.y);
                break;
            case MovementType.WavesMoving:
                rigi.velocity = new Vector2(MoveSpeed, SinWaves());
                break;
            case MovementType.FacingPlayer:
                MoveTowardsPlayer();
                break;
        }
    }
    public void SetPlayerPosition(Vector2 playerPosition) //Count the player position when spawning
    {
        this.playerPosition = playerPosition;
    }
    private float SinWaves() // Count the sin waves
    {
        return Mathf.Sin(Time.time * frequency) * amplitude;
    }






}
