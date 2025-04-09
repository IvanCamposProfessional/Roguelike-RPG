using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.Overlays;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //Variable to set in wich map we are
    int map;
    //Variable to set in wich floor of the map we are
    int floor;
    //Variable to save the layout we want to instantiate
    int layout;

    //Variable to set the different layouts
    [SerializeField]
    GameObject[] layouts;
    //Create an array to save the prefabs of the map events
    [SerializeField]
    GameObject[] mapEvents;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Provisional setting, we have to randomly select the layout
        map = 1;
        floor = 1;
        GenerateMap(map, floor);
    }

    public void GenerateMap(int Map, int Floor){
        //Create a gameobjects array initialized null
        GameObject[] transforms;

        //Create boolean arrays to control the number of each event we want on the map
        bool[] chests, eliteCombats, healings, randomEvents, shops, combats;

        //Generate a random layout
        layout = 0;

        //We have to see in wich map we are
        switch(Map){
        case 1:
            //We have to see in wich floor of the map 1 we are
            switch(Floor){
                case 1:
                    //Initialize the array of transforms with the quantity of transforms the 1st floor has
                    transforms = new GameObject[11];

                    //Define the event arrays with the number of each event we want on the 1st floor map
                    //chests = new bool[1];
                    chests = new bool[1];
                    eliteCombats = new bool[1];;
                    healings = new bool[2];;
                    randomEvents = new bool[1];;
                    shops = new bool[2];
                    //We want that the combats are the rest of the total transforms - the events
                    combats = new bool[transforms.Length - chests.Length - eliteCombats.Length - healings.Length - randomEvents.Length - shops.Length];
                    
                    //We have to see the layout we have to Instantiate
                    switch(layout){
                        case 0:
                            //Instantiate on the scene the corresponding Map Layout
                            Instantiate(layouts[0]);
                            break;
                        case 1:
                            Instantiate(layouts[1]);
                            break;
                        default:
                            break;
                    }

                    //Create a loop that has the number of transforms
                    for(int i = 0; i < transforms.Length; i++){
                        // initialize the array with the corresponding transforms on the iteration of the loop
                        transforms[i] = GameObject.Find("Transform" + i);
                                
                        //Generate a Random Number between the total number of events we have
                        int randomEvent = Random.Range(1, 7);
                        Debug.Log("Event: " + randomEvent);
                                
                        //Create a switch to control each event
                        switch(randomEvent){
                            //Case 1 = chest
                            case 1:
                                //If the last postiion of the bool chests array is true means that the array is full
                                //And we want to repeat the iteration of the first loop
                                //We don´t control if all the chests bool is true but with the logic we have if the last position
                                //is true all the rest has to be true too
                                if(chests[chests.Length - 1] == true){
                                    i--;
                                    break;
                                //If the array is not full
                                }else{
                                    //Create a loop to check the bool array of the chests
                                    for(int j = 0; j < chests.Length; j++){
                                        //If the chests array position corresponding to the iteration of the loop is false
                                        if(chests[j] == false){
                                            //Instantiate the GameObject of the chest on the transform corresponding to the iteration on the first loop
                                            Instantiate(mapEvents[0], transforms[i].transform.position, transforms[i].transform.rotation);
                                            //Set the bool array chest position to true on the corresponding iteration of the second loop
                                            chests[j] = true;
                                            //End the switch and continue with the next loop iteration
                                             break;
                                        }
                                    }
                                }

                                break;
                            //Case 2 = Combats
                            case 2:
                                //If the last postiion of the bool chests array is true means that the array is full
                                if(combats[combats.Length - 1] == true){
                                    i--;
                                    break;
                                //If the array is not full
                                }else{
                                    //Create a loop to check the bool array of the combats
                                    for(int j = 0; j < combats.Length; j++){
                                        //If the combats array position corresponding to the iteration of the loop is false
                                        if(combats[j] == false){
                                            //Instantiate the GameObject of the combat on the transform corresponding to the iteration on the first loop
                                             Instantiate(mapEvents[1], transforms[i].transform.position, transforms[i].transform.rotation);
                                            //Set the bool array cobat position to true on the corresponding iteration of the second loop
                                            combats[j] = true;
                                            //End the switch and continue with the next loop iteration
                                            break;
                                        }
                                    }
                                }
                                
                                break;
                            //Case 3 = Elite Combats
                            case 3:
                                //If the last postiion of the bool chests array is true means that the array is full
                                if(eliteCombats[eliteCombats.Length - 1] == true){
                                    i--;
                                    break;
                                //If the array is not full
                                }else{
                                    //Create a loop to check the bool array of the elite combats
                                    for(int j = 0; j < eliteCombats.Length; j++){
                                        //If the elite combats array position corresponding to the iteration of the loop is false
                                        if(eliteCombats[j] == false){
                                            //Instantiate the GameObject of the elite combat on the transform corresponding to the iteration on the first loop
                                            Instantiate(mapEvents[2], transforms[i].transform.position, transforms[i].transform.rotation);
                                            //Set the bool array elite combat position to true on the corresponding iteration of the second loop
                                            eliteCombats[j] = true;
                                            //End the switch and continue with the next loop iteration
                                            break;
                                        }
                                    }
                                }

                                break;
                            //Case 4 = Healing
                            case 4:
                                //If the last postiion of the bool chests array is true means that the array is full
                                if(healings[healings.Length - 1] == true){
                                    i--;
                                    break;
                                //If the array is not full
                                }else{
                                    //Create a loop to check the bool array of the healing
                                    for(int j = 0; j < healings.Length; j++){
                                        //If the healings array position corresponding to the iteration of the loop is false
                                        if(healings[j] == false){
                                            //Instantiate the GameObject of the elite combat on the transform corresponding to the iteration on the first loop
                                            Instantiate(mapEvents[3], transforms[i].transform.position, transforms[i].transform.rotation);
                                            //Set the bool array chest position to true on the corresponding iteration of the second loop
                                            healings[j] = true;
                                            //End the switch and continue with the next loop iteration
                                            break;
                                        }
                                    }
                                }

                                break;
                            //Case 5 = Random Event
                            case 5:
                                //If the last postiion of the bool chests array is true means that the array is full
                                if(randomEvents[randomEvents.Length - 1] == true){
                                    i--;
                                    break;
                                //If the array is not full
                                }else{
                                    //Create a loop to check the bool array of the random events
                                    for(int j = 0; j < randomEvents.Length; j++){
                                        //If the randomEvents array position corresponding to the iteration of the loop is false
                                        if(randomEvents[j] == false){
                                            //Instantiate the GameObject of the random event on the transform corresponding to the iteration on the first loop
                                            Instantiate(mapEvents[4], transforms[i].transform.position, transforms[i].transform.rotation);
                                            //Set the bool array random event position to true on the corresponding iteration of the second loop
                                            randomEvents[j] = true;
                                            //End the switch and continue with the next loop iteration
                                            break;
                                        }
                                    }
                                }

                                break;
                            //Case 6 = Shop
                            case 6:
                                //If the last postiion of the bool chests array is true means that the array is full
                                if(shops[shops.Length - 1] == true){
                                    i--;
                                    break;
                                //If the array is not full
                                }else{
                                    //Create a loop to check the bool array of the shops
                                    for(int j = 0; j < shops.Length; j++){
                                        //If the shops array position corresponding to the iteration of the loop is false
                                        if(shops[j] == false){
                                            //Instantiate the GameObject of the shop on the transform corresponding to the iteration on the first loop
                                            Instantiate(mapEvents[5], transforms[i].transform.position, transforms[i].transform.rotation);
                                            //Set the bool array shop position to true on the corresponding iteration of the second loop
                                            shops[j] = true;
                                            //End the switch and continue with the next loop iteration
                                            break;
                                        }
                                    }
                                }
                                
                                break;
                            default:
                                break;
                        }

                        Debug.Log("Transform instanciado: " + i);
                    }

                    break;
                default:
                    break;
            }
            break;
        default:
            break;
        }
    }
}
