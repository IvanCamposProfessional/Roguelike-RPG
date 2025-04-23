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
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private ItemType type;
    [SerializeField] private int maxStackSize;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string ItemDescription{
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    public Sprite ItemIcon{
        get { return itemIcon; }
        set { itemIcon = value; }
    }

    public ItemType Type
    {
        get { return type; }
        set { type = value; }
    }

    public int MaxStackSize
    {
        get { return maxStackSize; }
        set { maxStackSize = value; }
    }
}
