using System;
using System.Collections.Generic;
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
    [Header("Basic Data")]
    //Create all the variables of the monster scriptable object and serialize it all to change it from the object inspector
    [SerializeField] private string monsterName;
    [SerializeField] private string description;
    //Si tengo problemas al trabajar con esta variable puedo cambiarla a un String
    //Para operar con ella, por ejemplo checkear si un monster es de un tipo, puedo hacer "if(Monster.Type == MonsterType.Flesh)"
    [SerializeField] MonsterType type;
    [SerializeField] private Sprite monsterIcon;
    [SerializeField] private Sprite monsterSprite;
    [SerializeField] private PassiveAbility passiveAbility;

    [Space]
    [Header("Stats")]
    [SerializeField] private int healthPoints;
    [SerializeField] private int manaPoints;
    [SerializeField] private int specialAttackCharges;
    [SerializeField] private int damage;
    [SerializeField] private int arcaneDamage;
    [SerializeField] private int defense;
    [SerializeField] private int arcaneDefense;
    [SerializeField] private int velocity;
    [SerializeField] private int healthPointsIVs;
    [SerializeField] private int manaPointsIVs;
    [SerializeField] private int damageIVs;
    [SerializeField] private int arcaneDamageIVs;
    [SerializeField] private int defenseIVs;
    [SerializeField] private int arcaneDefenseIVs;
    [SerializeField] private int velocityIVs;

    [Space]
    [Header("Object & Debuffs")]
    [SerializeField] private Item equipableObject;
    [SerializeField] private string debuff;
    [SerializeField] private string debuffCounter;

    [Serializable]
    public struct MaterialToCraftQuantityPair{
        public Item materialToCraft;
        public int quanity;
    }
    [Space]
    [Header("Crafting System")]
    [SerializeField] private List<MaterialToCraftQuantityPair> MaterialAndQuantityToCraftList = new List<MaterialToCraftQuantityPair>();

    [Space]
    [Header("Level System")]
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentExp;
    //Create a serializable structure with two ints, the first one to check the level and the second one to know how much experience does the monster need to level up
    [Serializable]
    public struct LevelExperiencePair{
        public int level;
        public int experienceToLevelUp;
    }
    //Create a list with the structure of level/experienceToLevelUp called level system and define it
    [SerializeField]
    private List<LevelExperiencePair> levelSystem = new List<LevelExperiencePair>(){
        new LevelExperiencePair { level = 2, experienceToLevelUp = 1000 },
        new LevelExperiencePair { level = 3, experienceToLevelUp = 1200 }
    };

    [Space]
    [Header("Evolution System")]
    [SerializeField] private int minimumLevelToEvolve;
    //Create a serializable structure with one string and one int, the first one to check wich material you need to evolve and the second one to knowthe quantity
    [Serializable]
    public struct MaterialToEvolveQuantityPair{
        public Item materialToEvolve;
        public int quanity;
    }
    //Create a list with the structure of material and quantity
    [SerializeField] private List<MaterialToEvolveQuantityPair> MaterialAndQuantityToEvolveList = new List<MaterialToEvolveQuantityPair>();
    [SerializeField] private string monsterEvolution;

    [Space]
    [Header("Normal Attacks & Special Attacks")]
    //The attacks list needs to be defined with the size of 10 to know by design how much attacs we want to set on a monster
    [SerializeField] private Attack[] attackList = new Attack[10];
    [SerializeField] private Attack[] specialAttackList = new Attack[6];

    public Item EquipableObject{
        get { return equipableObject; }
        //The type of the equipable object you want to add to the monster has to be equipable object type
        set{
           if(value.Type.Equals(EquipableObject)){
                equipableObject = value;
           } 
        }
    }

    //Create a Getter to know the experience that the monster needs to Level Up passing it the level you need to know
    public int GetExperienceToLevelUp(int level){
        foreach(var pair in levelSystem){
            if(pair.level == level){
                return pair.experienceToLevelUp;
            }
        }

        Debug.LogWarning($"Level {level} not found.");
        return -1;
    }

    //Create a Getter to know the materials i need to evolve, later you can access the material name or anything you need from the list
    public List<Item> GetMaterialsToEvolve(){
        List<Item> materials = new List<Item>();
        foreach(var pair in MaterialAndQuantityToEvolveList){
            materials.Add(pair.materialToEvolve);
        }

        return materials;
    }

    //Create a Getter to know the quantity of a material you need to evolve
    public int GetQuantityOfAMaterialNeededToEvolve(string materialName){
        foreach(var pair in MaterialAndQuantityToEvolveList){
            if(pair.materialToEvolve.ItemName == materialName){
                return pair.quanity;
            }
        }

        Debug.LogWarning($"Material {materialName} not needed to evolve.");
        return -1;
    }

    //Create a Getter to know the materials i need to craft the monster, later you can access the material name or anything you need from the list
    public List<Item> GetMaterialsToCraft(){
        List<Item> materials = new List<Item>();
        foreach(var pair in MaterialAndQuantityToCraftList){
            materials.Add(pair.materialToCraft);
        }

        return materials;
    }

    //Create a Getter to know the quantity of a material you need to evolve
    public int GetQuantityOfAMaterialNeededToCraft(string materialName){
        foreach(var pair in MaterialAndQuantityToCraftList){
            if(pair.materialToCraft.ItemName == materialName){
                return pair.quanity;
            }
        }

        Debug.LogWarning($"Material {materialName} not needed to evolve.");
        return -1;
    }
}
