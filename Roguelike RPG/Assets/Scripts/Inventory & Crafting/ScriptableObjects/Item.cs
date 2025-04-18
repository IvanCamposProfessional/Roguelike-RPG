using UnityEngine;

//Create an enum to set the monster types
public enum ItemType{
    Material,
    EquipableObject
}

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private ItemType type;
    [SerializeField] private int maxStackSize;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public ItemType Type
    {
        get { return type; }
        set { type = value; }
    }
}
