using System;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

//Create the asset menu to create the attack scriptable objects on the menu inspector
[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public class Attack : ScriptableObject
{
    [Header("Basic Data")]
    //Create all the variables of the atack scriptable object and serialize it all to change it from the object inspector
    [SerializeField] private String attackName;
    [SerializeField] private String description;

    [Space]
    [Header("Icon & Animation")]
    [SerializeField] private Image icon;
    [SerializeField] private Animation attackAnimation;

    [Space]
    [Header("Attack Stats")]
    //Can be normal or special
    [SerializeField] private string attackType;
    //Can be normal or arcane
    [SerializeField] private string damageType;
    //Si tengo problemas al trabajar con esta variable puedo cambiarla a un String
    //Para operar con ella, por ejemplo checkear si un attack es de un tipo, puedo hacer "if(Attack.AttackElement == MonsterType.Flesh)"
    [SerializeField] private MonsterType attackElement;
    [SerializeField] private int damage;
    //Can be HP, Mana, Velocity, etc
    [SerializeField] private string costType;
    [SerializeField] private int cost;
    [SerializeField, Tooltip("This variable should be 0 if it is a normal attack")] private int chargesCost;

    //Create the structure to serialize a List with 2 keys to define the monster that can learn the attack and in wich level it can learn it
    [Serializable]
    public struct monsterAndLevelPair{
        public string monsterLearner;
        public int learningLevel;   
    }

    [Space]
    [Header("Wich monster can havve the attack & Level")]
    [SerializeField]
    //Create the List with the structure type to define wich monster and in wich level can Learn the Attack
    private List<monsterAndLevelPair> monsterCanLearnList = new List<monsterAndLevelPair>();

    //Get a list of all monsters and level pairs
    public List<monsterAndLevelPair> GetAllMonstersAndLevels(){
        return monsterCanLearnList;
    }

    //Define a Getter that return the level a monster can learn the attack
    public int GetLearningLevelForMonster(string monsterName){
        foreach(var pair in monsterCanLearnList){
            if(pair.monsterLearner.Equals(monsterName)){
                return pair.learningLevel;
            }
        }

        //Monster not found
        return -1;
    }

    //Get a list of all monsers that can learn the attack
    public List<string> GetAllMonsterLearners(){
        List<string> monsterNames = new List<string>();
        foreach(var pair in monsterCanLearnList){
            monsterNames.Add(pair.monsterLearner);
        }

        return monsterNames;
    }
}
