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
    private bool AlreadyHit = false;

    private Vector2 direction;

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
                direction = new Vector2(Mathf.Sign(MoveSpeed), 0);
                AwarePlayer(direction);
                break;
            case MovementType.WavesMoving:
                rigi.velocity = new Vector2(MoveSpeed, SinWaves());
                direction = new Vector2(Mathf.Sign(MoveSpeed), Mathf.Sign(SinWaves()));
                AwarePlayer(direction);
                break;
            case MovementType.FacingPlayer:
                MoveTowardsPlayer();
                AwarePlayer(lastDirection);
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

    private void AwarePlayer(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, LayerMask.GetMask("aware"));

        if (hit.collider != null)
        {
            SpriteRenderer spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                float distance = Vector2.Distance(transform.position, hit.point);
                if (distance < 1.5f)
                {
                    Color color = spriteRenderer.color;
                    color.a = 0f;
                    spriteRenderer.color = color;
                }
                else if (distance >= 1.5f && !AlreadyHit)
                {
                    Color color = spriteRenderer.color;
                    color.a = 1f;
                    spriteRenderer.color = color;
                    AlreadyHit = true;
                }
            }
        }
    }




}
