using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy3 : MonoBehaviour
{
    public PlayerMove player;
    private bool on = false;

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.GetCurrentPosition();

            if (playerPosition.x > 70)
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
            transform.Translate(0, -0.04f, 0);
        }
    }
}
