using System;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System.Collections;
using UnityEditor;

//Create the asset menu to create the attack scriptable objects on the menu inspector
[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public class Attack : ScriptableObject
{
    //Create all the variables of the atack scriptable object and serialize it all to change it from the object inspector
    [SerializeField] private String attackName;
    [SerializeField] private String description;
    [SerializeField] private Image icon;
    [SerializeField] private Animation attackAnimation;
    //Can be normal or special
    [SerializeField] private String attackType;
    //Can be normal or arcane
    [SerializeField] private String damageType;
    //Si tengo problemas al trabajar con esta variable puedo cambiarla a un String
    //Para operar con ella, por ejemplo checkear si un attack es de un tipo, puedo hacer "if(Attack.AttackElement == MonsterType.Flesh)"
    [SerializeField] private MonsterType attackElement;
    [SerializeField] private int damage;
    //Can be HP, Mana, Velocity, etc
    [SerializeField] private String costType;
    [SerializeField] private int cost;
    //GUILayout.Label("Remember that one thing about this variable!");
    [SerializeField] private int chargesCost;
}
