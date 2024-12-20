using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy2 : MonoBehaviour
{
    public PlayerMove player;
    private bool on = false;

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();

            if (playerPosition.x > 6 && playerPosition.y >9)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                if (!on)
                {
                    on = true;
                }

            }
            move();
        }
    }
    private void move()
    {
        if (on)
        {
            transform.Translate(0, -0.8f, 0);
        }
    }
}
