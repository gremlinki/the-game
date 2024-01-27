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
    public Sprite[] ItemRELNames = new Sprite[9];
    public Sprite SPRnone;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        itemList = gameManager.InventoryManager.items();
        ItemsOnMap = GameObject.FindGameObjectsWithTag("Item");
        //Debug.Log(ItemNames.Length);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < ItemsOnMap.Length; i++){
            for(int j = 0; j < ItemRELNames.Length; j++){
                if(ItemsOnMap[i] != null){
                    itemTxtLoader(ItemsOnMap[i].name, ItemNames[j], ItemsOnMap[i].GetComponent<CItemWrapper>().NobleNumber, ItemsOnMap[i].GetComponent<CItemWrapper>().KingNumber, ItemsOnMap[i].GetComponent<CItemWrapper>().PSYNumber, ItemRELNames[j]);
                }
            }
        }
    }

    void itemTxtLoader(string x, string accualX,int SzlachtaOPT, int KingOPT, int MentalOPT, Sprite accualIMG){
        if (x == accualX){
            if(SzlachtaOPT > 0){
                if (Szlachta_Items[0].GetComponent<Image>().sprite == SPRnone){
                    Szlachta_Items[0].GetComponent<Image>().sprite = accualIMG;
                }
                else if (Szlachta_Items[1].GetComponent<Image>().sprite == SPRnone && Szlachta_Items[0].GetComponent<Image>().sprite != accualIMG){
                    Szlachta_Items[1].GetComponent<Image>().sprite = accualIMG;
                }
                else if (Szlachta_Items[2].GetComponent<Image>().sprite == SPRnone && Szlachta_Items[0].GetComponent<Image>().sprite != accualIMG && Szlachta_Items[1].GetComponent<Image>().sprite != accualIMG){
                    Szlachta_Items[2].GetComponent<Image>().sprite = accualIMG;
                }
            }
            if(KingOPT > 0){
                if (Krol_Items[0].GetComponent<Image>().sprite == SPRnone){
                    Krol_Items[0].GetComponent<Image>().sprite = accualIMG;
                }
                else if (Krol_Items[1].GetComponent<Image>().sprite == SPRnone && Krol_Items[0].GetComponent<Image>().sprite != accualIMG){
                    Krol_Items[1].GetComponent<Image>().sprite = accualIMG;
                }
                else if (Krol_Items[2].GetComponent<Image>().sprite == SPRnone && Krol_Items[0].GetComponent<Image>().sprite != accualIMG && Krol_Items[1].GetComponent<Image>().sprite != accualIMG){
                    Krol_Items[2].GetComponent<Image>().sprite = accualIMG;
                }
            }
            if(MentalOPT > 0){
                if (Psycha_Items[0].GetComponent<Image>().sprite == SPRnone){
                    Psycha_Items[0].GetComponent<Image>().sprite = accualIMG;
                }
                else if (Psycha_Items[1].GetComponent<Image>().sprite == SPRnone && Psycha_Items[0].GetComponent<Image>().sprite != accualIMG){
                    Psycha_Items[1].GetComponent<Image>().sprite = accualIMG;
                }
                else if (Psycha_Items[2].GetComponent<Image>().sprite == SPRnone && Psycha_Items[0].GetComponent<Image>().sprite != accualIMG && Psycha_Items[1].GetComponent<Image>().sprite != accualIMG){
                    Psycha_Items[2].GetComponent<Image>().sprite = accualIMG;
                }
            }
        }
    }
}
