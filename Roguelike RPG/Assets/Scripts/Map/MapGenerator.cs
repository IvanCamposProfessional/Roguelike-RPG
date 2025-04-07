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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Provisional setting, we have to randomly select the layout
        map = 1;
        floor = 1;
        layout = 0;

        //We have to see in wich map we are
        switch(map){
        case 1:
            //We have to see in wich floor of the map 1 we are
            switch(floor){
                case 1:
                    //We have to see the layout we have to Instantiate
                    switch(layout){
                        case 0:
                            Instantiate(layouts[0]);
                            break;
                        default:
                            break;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
