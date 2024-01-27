using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;
using Unity.VisualScripting;

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
            itemImgLoader(itemList[0],item_1);
        if(itemList[1] != null)
            itemImgLoader(itemList[1],item_2);
        if(itemList[2] != null)
            itemImgLoader(itemList[2],item_3);
    }

    void itemImgLoader(CItem x, GameObject y)
    {
        y.GetComponent<Image>().sprite = x.icon();
    }
}