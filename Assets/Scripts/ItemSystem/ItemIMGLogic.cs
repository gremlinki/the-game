using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIMGLogic : MonoBehaviour
{
    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;
    //logic if(item 1 number = 2 { grafika = szpadel})
    public int Item_1_Number;
    public int Item_2_Number;
    public int Item_3_Number;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemImgLoader(Item_1_Number,item_1);
        itemImgLoader(Item_2_Number,item_2);
        itemImgLoader(Item_3_Number,item_3);
    }

    void itemImgLoader(int x, GameObject y){
        switch(x){
            case 0:
                y.GetComponent<Image>().sprite = sprNone;
                break;
            case 1:
                y.GetComponent<Image>().sprite = Carrot;
                break;
            case 2:
                y.GetComponent<Image>().sprite = Shovel;
                break;
            case 3:
                y.GetComponent<Image>().sprite = Sword;
                break;
            case 4:
                y.GetComponent<Image>().sprite = Shield;
                break;
            case 5:
                y.GetComponent<Image>().sprite = Coat_of_arms;
                break;
            case 6:
                y.GetComponent<Image>().sprite = BeerMug;
                break;
            case 7:
                y.GetComponent<Image>().sprite = Apple;
                break;
            case 8:
                y.GetComponent<Image>().sprite = Book;
                break;
            case 9:
                y.GetComponent<Image>().sprite = Hammer;
                break;
        }
    }
}