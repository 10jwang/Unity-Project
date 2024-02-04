using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightForward : MonoBehaviour
{
    public float speed = 4f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Add SpriteRenderer component if not already attached
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        
        // Set Sorting Layer
        spriteRenderer.sortingLayerName = "YourSortingLayer"; // Change to your desired sorting layer

        // Set Order in Layer
        spriteRenderer.sortingOrder = 0; // Change to your desired order
    }

    void Update()
    {
        // Move the character to the left
        Vector3 movement = new Vector3(-speed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);

        // Flip the sprite if moving to the left
        if (movement.x < 0)
        {
            FlipSprite(true);
        }
        else
        {
            FlipSprite(false);
        }
    }

    void FlipSprite(bool flip)
    {
        // Flip the sprite horizontally
        spriteRenderer.flipX = flip;
    }
}




