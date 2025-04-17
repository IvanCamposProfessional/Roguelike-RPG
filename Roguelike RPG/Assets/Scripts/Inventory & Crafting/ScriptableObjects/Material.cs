using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "Scriptable Objects/Material")]
public class Material : ScriptableObject
{
    [SerializeField] private string materialName;
    [SerializeField] private string description;
    [SerializeField] private int maxStackSize;

    public string MaterialName
    {
        get { return materialName; }
        set { materialName = value; }
    }
}
