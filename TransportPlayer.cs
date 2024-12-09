using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPlayer : MonoBehaviour
{
    public PlayerMove player;
    private bool on = false;

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();

            if (playerPosition.x > 41 && playerPosition.y > 5)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                if (!on)
                {
                    on = true;
                }

            }
            move();

            if (transform.position.x > 64)
            {
                Destroy(gameObject);
            }
        }
    }
    private void move()
    {
        if (on)
        {
            transform.Translate(0, 0.04f, 0);
        }
    }
}