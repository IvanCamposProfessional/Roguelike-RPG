using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monsters/Monster")]
public class Monster : ScriptableObject
{
    [Header("General Info")]
    public string Name;
    public string Description;
    public Sprite MiniSprite;

    [Header("Level")]
    public int Level;
    public int Experience;

    [Header("Stats")]
    public int MaxHP;
    public int AmountHP;
    public int MaxMana;
    public int AmountMana;
    public int Attack;
    public int ArcaneAttack;
    public int Defense;
    public int ArcaneDefense;
    public int Speed;

    [Header("Type")]
    public MonsterType Type;

    [Header("Visuals")]
    public Sprite FrontSprite;
    //public Sprite BackSprite;

    [Header("Abilities and Moves")]
    public string[] Moves;
    public string Ability;

    public void GetDamaged (int damage){
        AmountHP -= damage;
    }
}

public enum MonsterType
{
    Natura,
    Chaos,
    Flesh,
    Techno
}
