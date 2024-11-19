using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonstersUI : MonoBehaviour
{
    [SerializeField]
    MonsterHolder Holder;

    [SerializeField]
    GameObject[] MonstersPanels;

    // Start is called before the first frame update
    void Start()
    {
        Monster[] PlayerMonsters = Holder.Monsters;

        /*for(int i = 0; i < PlayerMonsters.Length; i ++){
            if(PlayerMonsters[i] != null){
                MonstersPanels[i].transform.GetChild(0).GetComponent<Image>().sprite = PlayerMonsters[i].MiniSprite;
                MonstersPanels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerMonsters[i].name;
            }
        }*/

        UpdateUI(MonstersPanels, PlayerMonsters);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI(GameObject[] panels, Monster[] monsters){
        for(int i = 0; i < monsters.Length; i ++){
            if(monsters[i] != null){
                panels[i].transform.GetChild(0).GetComponent<Image>().sprite = monsters[i].MiniSprite;
                panels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = monsters[i].Name;
                panels[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "LvL: " + monsters[i].Level;
            }
        }
    }
}
