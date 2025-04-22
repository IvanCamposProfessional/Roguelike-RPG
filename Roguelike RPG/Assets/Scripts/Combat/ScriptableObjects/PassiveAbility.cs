using UnityEngine;

[CreateAssetMenu(fileName = "PassiveAbility", menuName = "Scriptable Objects/PassiveAbility")]
public class PassiveAbility : ScriptableObject
{
    [SerializeField] private string passiveAbilityName;
    [SerializeField] private string passiveAbilityDescription;
    [SerializeField] private string effect;

    public string PassiveAbilityName{
        get { return passiveAbilityName; }
        set { passiveAbilityName = value; }
    }

    public string PassiveAbilityDescription{
        get { return passiveAbilityDescription; }
        set { passiveAbilityDescription = value; }
    }

    public string Effect{
        get { return effect; }
        set { effect = value; }
    }
}
