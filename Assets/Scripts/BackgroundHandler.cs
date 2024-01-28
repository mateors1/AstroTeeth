using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public Sprite[] backgroundSprites;

    private float[] spriteWidths;
    private int currentSpriteIndex = 0;
    private bool hasSwitched = false;

    private void Start()
    {
        // Calculate the width of each sprite
        CalculateSpriteWidths();

        // Set the initial sprite
        SetCurrentSprite();
    }

    private void CalculateSpriteWidths()
    {
        spriteWidths = new float[backgroundSprites.Length];

        for (int i = 0; i < backgroundSprites.Length; i++)
        {
            spriteWidths[i] = backgroundSprites[i].bounds.size.x;
        }
    }

    private void Update()
    {
        // Calculate the movement amount based on the scroll speed
        float moveAmount = scrollSpeed * Time.deltaTime;

        // Move the container to the left
        transform.Translate(Vector3.left * moveAmount);

        // Check if the container has scrolled half of the current sprite
        if (transform.position.x < -spriteWidths[currentSpriteIndex] / 2 && !hasSwitched)
        {
            // Reposition at half width
            float newPositionX = transform.position.x + spriteWidths[currentSpriteIndex] / 2;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

            // Change the sprite on the event basis
            ChangeSprite();

            // Set the flag to avoid switching multiple times before fully scrolling off
            hasSwitched = true;
        }

        // Check if the container is completely off the screen
        if (transform.position.x < -spriteWidths[currentSpriteIndex])
        {
            // If it's off the screen, reset the flag
            hasSwitched = false;
        }
    }

    // Call this method when the event occurs to switch to the next sprite
    public void ChangeSprite()
    {
        // Increment the sprite index
        currentSpriteIndex = (currentSpriteIndex + 1) % backgroundSprites.Length;

        // Set the current sprite
        SetCurrentSprite();
    }

    private void SetCurrentSprite()
    {
        // Change the sprite in the container
        GetComponent<SpriteRenderer>().sprite = backgroundSprites[currentSpriteIndex];
    }
}
