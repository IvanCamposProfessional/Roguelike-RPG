using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System.Collections.Generic;

//Create the asset menu to create the attack scriptable objects on the menu inspector
[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public class Attack : ScriptableObject
{
    [Header("Basic Data")]
    //Create all the variables of the atack scriptable object and serialize it all to change it from the object inspector
    [SerializeField] private string attackName;
    [SerializeField] private string attackDescription;

    [Space]
    [Header("Icon & Animation")]
    [SerializeField] private Image attackIcon;
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
    //Can be HP, Mana, Turn Cost, etc
    [SerializeField] private string costType;
    [SerializeField] private int cost;
    //How much of a turn will cost the attack, to manage the turns order
    [SerializeField] private int turnCost;
    [SerializeField, Tooltip("This variable should be 0 if it is a normal attack")] private int voidShardsCost;

    //Create the structure to serialize a List with 2 keys to define the monster that can learn the attack and in wich level it can learn it
    [Serializable]
    public struct monsterAndLevelPair{
        public Monster monsterLearner;
        public int learningLevel;   
    }

    [Space]
    [Header("Wich monster can have the attack & in wich Level")]
    [SerializeField]
    //Create the List with the structure type to define wich monster and in wich level can Learn the Attack
    private List<monsterAndLevelPair> monsterCanLearnList = new List<monsterAndLevelPair>();

    //GETTERS & SETTERS BASIC DATA
    public string AttackName{
        get { return attackName; }
        set { attackName = value; }
    }

    public string AttackDescription{
        get { return attackDescription; }
        set { attackDescription = value; }
    }

    //GETTERS & SETTERS ICON & ANIMATION
    public Image AttackIcon{
        get { return attackIcon; }
        set { attackIcon = value; }
    }

    public Animation AttackAnimation{
        get { return attackAnimation; }
        set { attackAnimation = value; }
    }

    //GETTERS & SETTERS ATTACK STATS
    public string AttackType{
        get { return attackType; }
        set { attackType = value; }
    }

    public string DamageType{
        get { return damageType; }
        set { damageType = value; }
    }

    public MonsterType AttackElement{
        get { return attackElement; }
        set { attackElement = value; }
    }

    public int Damage{
        get { return damage; }
        set { damage = value; }
    }

    public string CostType{
        get { return costType; }
        set { costType = value; }
    }

    public int Cost{
        get { return cost; }
        set { cost = value; }
    }

    public int TurnCost{
        get { return turnCost; }
        set { turnCost = value; }
    }

    public int VoidShardsCost{
        get { return voidShardsCost; }
        set { voidShardsCost = value; }
    }

    //GETTERS & SETTERS MONSTER CAN LEARN LIST
    public List<monsterAndLevelPair> MonsterCanLearnList
    {
        get { return monsterCanLearnList; }
        set { monsterCanLearnList = value; }
    }

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
    public List<Monster> GetAllMonsterLearners(){
        List<Monster> monsters = new List<Monster>();
        foreach(var pair in monsterCanLearnList){
            monsters.Add(pair.monsterLearner);
        }

        return monsters;
    }
}
