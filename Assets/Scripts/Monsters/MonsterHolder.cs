using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHolder : MonoBehaviour
{
    [SerializeField]
    public Monster[] Monsters;

    public Monster[] monsters
    {
        get => Monsters;
        set => Monsters = value;
    }
}
