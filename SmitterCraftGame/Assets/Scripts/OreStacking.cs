using UnityEngine;

public class OreStacking : MonoBehaviour
{
    public ItemSO IronOre;

    // Use this to filter what triggers the count if needed
    // public string targetName = "IronOre"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        // For now, accept any collision as an ore, or we can filter by name/tag.
        // Given the context, we likely only drag Ores into this zone.
        // We can check if the object name contains "IronOre" or similar.
        if (other.name.Contains("IronOre") || other.GetComponent<SpriteRenderer>()?.sprite == IronOre.sprite)
        {
            IronOre.itemQuantity++;
            Debug.Log("Stacked: " + IronOre.itemQuantity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.Contains("IronOre") || other.GetComponent<SpriteRenderer>()?.sprite == IronOre.sprite)
        {
            IronOre.itemQuantity--;
            Debug.Log("Unstacked: " + IronOre.itemQuantity);
        }
    }
}
