using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite sprite;
    public int itemValue;
    public int itemQuantity;
    //public bool isCraftable;

}
