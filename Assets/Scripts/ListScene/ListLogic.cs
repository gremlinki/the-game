using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;

public class ListLogic : MonoBehaviour
{
    public bool isListOpen = true;
    public Player MC;

    GameManager gameManager;
    private CItem[] itemList;

    static int three = 3;
    public GameObject[] Szlachta_Items = new GameObject[three];
    public GameObject[] Krol_Items = new GameObject[three];
    public GameObject[] Psycha_Items = new GameObject[three];
    public GameObject[] ItemsOnMap;
    public string[] ItemNames = new string[9]; //{"Carrot","Shovel","Sword","Shield","Coat of Arms","Beer Mug","Apple","Book","Hammer"};
    public Sprite[] ItemRELNames = new Sprite[0];
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        itemList = gameManager.InventoryManager.items();

        if (ItemsOnMap == null)
            ItemsOnMap = GameObject.FindGameObjectsWithTag("Item");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= ItemsOnMap.Length; i++){
            for(int j = 0; j <= ItemNames.Length; j++){
                for(int o = 0; o <= ItemNames.Length; o++){
                    if(ItemsOnMap[i] != null){
                        itemTxtLoader(ItemsOnMap[i].name, ItemNames[j], 1, 0, 0, Szlachta_Items, ItemRELNames[o]);
                    }
                }
            }
        }
    }

    void itemTxtLoader(string x, string accualX,int SzlachtaOPT, int KingOPT, int MentalOPT, GameObject[] y, Sprite accualIMG){
        foreach(GameObject obj in y){
            if (x == accualX){
                if(SzlachtaOPT > 0){
                    obj.GetComponent<Image>().sprite = accualIMG;
                }
                if(KingOPT > 0){
                    obj.GetComponent<Image>().sprite = accualIMG;
                }
                if(MentalOPT > 0){
                    obj.GetComponent<Image>().sprite = accualIMG;
                }
            }
        }
    }
}
