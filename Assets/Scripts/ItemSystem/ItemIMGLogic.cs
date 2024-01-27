using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;

public class ItemIMGLogic : MonoBehaviour
{
    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;
    //logic if(item 1 number = 2 { grafika = szpadel})
    //public string Item_1_Number;
    //public string Item_2_Number;
    //public string Item_3_Number;
    // sptite none ma być pusty
    private Sprite sprNone;
    public Sprite Carrot;
    public Sprite Shovel;
    public Sprite Sword;
    public Sprite Shield;
    public Sprite Coat_of_arms;
    public Sprite BeerMug;
    public Sprite Apple;
    public Sprite Book;
    public Sprite Hammer;

    GameManager gameManager;
    private CItem[] itemList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        itemList = gameManager.InventoryManager.items();
    }

    // Update is called once per frame
    void Update()
    {
        if(itemList[0] != null)
            itemImgLoader(itemList[0].name,item_1);
        if(itemList[1] != null)
            itemImgLoader(itemList[1].name,item_2);
        if(itemList[2] != null)
            itemImgLoader(itemList[2].name,item_3);
    }

    void itemImgLoader(string x, GameObject y){
        switch(x){
            case "Carrot":
                y.GetComponent<Image>().sprite = Carrot;
                break;
            case "Shovel":
                y.GetComponent<Image>().sprite = Shovel;
                break;
            case "Sword":
                y.GetComponent<Image>().sprite = Sword;
                break;
            case "Shield":
                y.GetComponent<Image>().sprite = Shield;
                break;
            case "Coat of Arms":
                y.GetComponent<Image>().sprite = Coat_of_arms;
                break;
            case "Beer Mug":
                y.GetComponent<Image>().sprite = BeerMug;
                break;
            case "Apple":
                y.GetComponent<Image>().sprite = Apple;
                break;
            case "Book":
                y.GetComponent<Image>().sprite = Book;
                break;
            case "Hammer":
                y.GetComponent<Image>().sprite = Hammer;
                break;
            default:
                y.GetComponent<Image>().sprite = sprNone;
                break;
        }
    }
}