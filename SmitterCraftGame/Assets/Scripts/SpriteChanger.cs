using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteChanger : MonoBehaviour
{
    [Tooltip("The sprite to switch to after the required number of triggers.")]
    public Sprite Pass1Sprite;
    public Sprite Pass2Sprite;
    public Sprite Pass3Sprite;

    [Tooltip("The number of trigger interactions required to change the sprite.")]
    public int Pass1triggers = 2;
    public int Pass2triggers = 5;
    public int Pass3triggers = 7;


    [Tooltip("Optional: specific tag to check for colliding objects. Leave empty to accept any trigger.")]
    public string filterTag;

    private int currentTriggerCount = 0;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If a filter tag is specified, check if the colliding object matches it
        if (!string.IsNullOrEmpty(filterTag) && !other.CompareTag(filterTag))
        {
            return;
        }

        currentTriggerCount++;

        // Check if we've reached the required number of triggers
        if (currentTriggerCount >= Pass1triggers)
        {
            if (Pass1Sprite != null)
            {
                spriteRenderer.sprite = Pass1Sprite;
                
                // Optional: Disable this script if you don't want it to keep checking/changing
                // this.enabled = false; 
            }
        }
        else if (currentTriggerCount >= Pass2triggers)
        {
            if (Pass2Sprite != null)
            {
                spriteRenderer.sprite = Pass2Sprite;
                
                // Optional: Disable this script if you don't want it to keep checking/changing
                // this.enabled = false; 
            }
        }
        else if (currentTriggerCount >= Pass3triggers)
        {
            if (Pass3Sprite != null)
            {
                spriteRenderer.sprite = Pass3Sprite;
                
                // Optional: Disable this script if you don't want it to keep checking/changing
                // this.enabled = false; 
            }
        }
    }
}
