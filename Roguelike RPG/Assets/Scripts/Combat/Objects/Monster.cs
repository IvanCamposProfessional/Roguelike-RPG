using System;
using Unity.VisualScripting;
using UnityEngine;

//Create an enum to set the monster types
public enum MonsterType{
    Void,
    Aurora,
    Nature,
    Flesh,
    Techno
}

//Create the asset menu to create the monster scriptable objects on the menu inspector
[CreateAssetMenu(fileName = "New Monster", menuName = "Scriptable Objects/Monster")]
public class Monster : ScriptableObject
{
    //Create all the variables of the monster scriptable object and serialize it all to change it from the object inspector
    [SerializeField] private String monsterName;
    [SerializeField] private String description;
    //Si tengo problemas al trabajar con esta variable puedo cambiarla a un String
    //Para operar con ella, por ejemplo checkear si un monster es de un tipo, puedo hacer "if(Monster.Type == MonsterType.Flesh)"
    [SerializeField] MonsterType type;
    [SerializeField] private Sprite monsterSprite;
    [SerializeField] private int healthPoints;
    [SerializeField] private int manaPoints;
    [SerializeField] private int specialAttackCharges;
    [SerializeField] private int damage;
    [SerializeField] private int arcaneDamage;
    [SerializeField] private int defense;
    [SerializeField] private int arcaneDefense;
    [SerializeField] private int velocity;
    [SerializeField] private String debuff;
    [SerializeField] private String debuffCounter;
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentExp;
}
