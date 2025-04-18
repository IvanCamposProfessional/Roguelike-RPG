using UnityEngine;

[CreateAssetMenu(fileName = "PassiveAbility", menuName = "Scriptable Objects/PassiveAbility")]
public class PassiveAbility : ScriptableObject
{
    [SerializeField] private string passiveAbilityName;
    [SerializeField] private string description;
    [SerializeField] private string effect;
}
