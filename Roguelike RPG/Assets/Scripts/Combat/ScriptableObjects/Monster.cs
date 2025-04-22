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
    [SerializeField] private string monsterDescription;
    //Si tengo problemas al trabajar con esta variable puedo cambiarla a un String
    //Para operar con ella, por ejemplo checkear si un monster es de un tipo, puedo hacer "if(Monster.Type == MonsterType.Flesh)"
    [SerializeField] MonsterType monsterType;
    [SerializeField] private Sprite monsterIcon;
    [SerializeField] private Sprite monsterSprite;
    [SerializeField] private PassiveAbility monsterPassiveAbility;

    [Space]
    [Header("Stats")]
    [SerializeField] private int healthPoints;
    [SerializeField] private int manaPoints;
    [SerializeField] private int voidShards;
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
    [SerializeField] private int debuffCounter;

    [Serializable]
    public struct MaterialToCraftQuantityPair{
        public Item materialToCraft;
        public int quanity;
    }
    [Space]
    [Header("Crafting System")]
    [SerializeField] private List<MaterialToCraftQuantityPair> materialAndQuantityToCraftList = new List<MaterialToCraftQuantityPair>();

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
    private List<LevelExperiencePair> levelSystem = new List<LevelExperiencePair>();/*{
        new LevelExperiencePair { level = 2, experienceToLevelUp = 1000 },
        new LevelExperiencePair { level = 3, experienceToLevelUp = 1200 },
        new LevelExperiencePair { level = 2, experienceToLevelUp = 1400 },
        new LevelExperiencePair { level = 2, experienceToLevelUp = 1600 }
    };*/

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
    [SerializeField] private List<MaterialToEvolveQuantityPair> materialAndQuantityToEvolveList = new List<MaterialToEvolveQuantityPair>();
    [SerializeField] private Monster monsterEvolution;

    [Space]
    [Header("Attacks")]
    //The attacks list needs to be defined with the size of 10 to know by design how much attacs we want to set on a monster
    [SerializeField] private Attack[] attacksList = new Attack[10];
    [SerializeField] private Attack[] specialAttacksList = new Attack[6];

    //GETTERS & SETTERS BASIC DATA
    public string MonsterName{
        get { return monsterName; }
        set { monsterName = value; }
    }

    public string MonsterDescription{
        get { return monsterDescription; }
        set { monsterDescription = value; }
    }

    public MonsterType MonsterType{
        get { return monsterType; }
        set { monsterType = value; }
    }

    public Sprite MonsterIcon{
        get { return monsterIcon; }
        set { monsterIcon = value; }
    }

    public Sprite MonsterSprite{
        get { return monsterSprite; }
        set { monsterSprite = value; }
    }

    public PassiveAbility MonsterPassiveAbility{
        get { return monsterPassiveAbility; }
        set { monsterPassiveAbility = value; }
    }

    //GETTERS & SETTERS STATS
    public int HealthPoints{
        get { return healthPoints; }
        set { healthPoints = value; }
    }

    public int ManaPoints{
        get { return manaPoints; }
        set { manaPoints = value; }
    }

    public int VoidShards{
        get { return voidShards; }
        set { voidShards = value; }
    }

    public int Damage{
        get { return damage; }
        set { damage = value; }
    }

    public int ArcaneDamage{
        get { return arcaneDamage; }
        set { arcaneDamage = value; }
    }

    public int Defense{
        get { return defense; }
        set { defense = value; }
    }

    public int ArcaneDefense{
        get { return arcaneDefense; }
        set { arcaneDefense = value; }
    }

    public int Velocity{
        get { return velocity; }
        set { velocity = value; }
    }

    public int HealthPointsIVs{
        get { return healthPointsIVs; }
        set { healthPointsIVs = value; }
    }

    public int ManaPointsIVs{
        get { return manaPointsIVs; }
        set { manaPointsIVs = value; }
    }

    public int DamageIVs{
        get { return damageIVs; }
        set { damageIVs = value; }
    }

    public int ArcaneDamageIVs{
        get { return arcaneDamageIVs; }
        set { arcaneDamageIVs = value; }
    }

    public int DefenseIVs{
        get { return defenseIVs; }
        set { defenseIVs = value; }
    }

    public int ArcaneDefenseIVs{
        get { return arcaneDefenseIVs; }
        set { arcaneDefenseIVs = value; }
    }

    public int VelocityIVs{
        get { return velocityIVs; }
        set { velocityIVs = value; }
    }

    //GETTERS & SETTERS OBJECT & DEBUFFS
    public Item EquipableObject{
        get { return equipableObject; }
        //The type of the equipable object you want to add to the monster has to be equipable object type
        set{
           if(value.Type.Equals(EquipableObject)){
                equipableObject = value;
           } 
        }
    }

    public string Debuff{
        get { return debuff; }
        set { debuff = value; }
    }

    public int DebuffCounter{
        get { return debuffCounter; }
        set { debuffCounter = value; }
    }

    //GETTERS & SETTERS CRAFTING SYSTEM
    public List<MaterialToCraftQuantityPair> MaterialAndQuantityToCraftList
    {
        get { return materialAndQuantityToCraftList; }
        set { materialAndQuantityToCraftList = value; }
    }

    //Create a Getter to know the materials i need to craft the monster, later you can access the material name or anything you need from the list
    public List<Item> GetMaterialsToCraft(){
        List<Item> materials = new List<Item>();
        foreach(var pair in materialAndQuantityToCraftList){
            materials.Add(pair.materialToCraft);
        }

        return materials;
    }

    //Create a Getter to know the quantity of a material you need to evolve
    public int GetQuantityOfAMaterialNeededToCraft(string materialName){
        foreach(var pair in materialAndQuantityToCraftList){
            if(pair.materialToCraft.ItemName == materialName){
                return pair.quanity;
            }
        }

        Debug.LogWarning($"Material {materialName} not needed to evolve.");
        return -1;
    }

    //GETTERS & SETTERS LEVEL SYSTEM
    public int CurrentLevel{
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    public int CurrentExp{
        get { return currentExp; }
        set { currentExp = value; }
    }

    public List<LevelExperiencePair> LevelSystem
    {
        get { return levelSystem; }
        set { levelSystem = value; }
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

    //GETTERS & SETTERS EVOLVUTION SYSTEM
    public int MinimumLevelToEvolve{
        get { return minimumLevelToEvolve; }
        set { minimumLevelToEvolve = value; }
    }

    public List<MaterialToEvolveQuantityPair> MaterialAndQuantityToEvolveList
    {
        get { return materialAndQuantityToEvolveList; }
        set { materialAndQuantityToEvolveList = value; }
    }

    //Create a Getter to know the materials i need to evolve, later you can access the material name or anything you need from the list
    public List<Item> GetMaterialsToEvolve(){
        List<Item> materials = new List<Item>();
        foreach(var pair in materialAndQuantityToEvolveList){
            materials.Add(pair.materialToEvolve);
        }

        return materials;
    }

    //Create a Getter to know the quantity of a material you need to evolve
    public int GetQuantityOfAMaterialNeededToEvolve(string materialName){
        foreach(var pair in materialAndQuantityToEvolveList){
            if(pair.materialToEvolve.ItemName == materialName){
                return pair.quanity;
            }
        }

        Debug.LogWarning($"Material {materialName} not needed to evolve.");
        return -1;
    }

    public Monster MonsterEvolution{
        get { return monsterEvolution; }
        set { monsterEvolution = value; }
    }

    //GETTERS & SETTERS ATTACKS
    public Attack[] AttacksList{
        get { return attacksList; }
        set { attacksList = value; }
    }

    public Attack[] SpecialAttacksList{
        get { return specialAttacksList; }
        set { specialAttacksList = value; }
    }

    //OTHER FUNCTIONS
    //Function to make the monster take damage from any source
    public int TakeDamage(int damageAmount){
        healthPoints -= damageAmount;

        if(healthPoints < 0){
            healthPoints = 0;
        }

        return healthPoints;
    }

    //Function to check if the monster leveled up
    public bool CheckLevelUp(){
        if(currentExp >= GetExperienceToLevelUp(currentLevel)){
            currentLevel++;
            currentExp -= GetExperienceToLevelUp(currentLevel);
            return true;
        }else{
            return false;
        }
    }

    //We want to set up the level system when the monster object gets created
    void OnEnable()
    {
        levelSystem.Clear();
        int baseExperience = 1000;

        for(int actualLevel = 2; actualLevel <= 150; actualLevel++){
            int actualExperienceToLevelUp = (int)(baseExperience * Math.Pow(1.021, actualLevel - 2)); //2.1% more per level (1.021 is 2.1%, 1.1 is 10%)

            levelSystem.Add(new LevelExperiencePair
            {
                level = actualLevel,
                experienceToLevelUp = actualExperienceToLevelUp
            });
        }
    }
}
