using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;

public class ListLogic : MonoBehaviour
{
    public bool isListOpen = true;
    public GameObject ListOBJ;
    public Player MC;

    GameManager gameManager;
    private CItem[] itemList;

    static int three = 3;
    public GameObject[] Szlachta_Items = new GameObject[three];
    public GameObject[] Krol_Items = new GameObject[three];
    public GameObject[] Psycha_Items = new GameObject[three];
    public GameObject[] ItemsOnMap;

    public ItemDefinition[] ItemDefinitions;

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
        for (int i = 0; i < ItemsOnMap.Length; i++)
        {
            if (ItemsOnMap[i] != null)
            {
                CItemWrapper wrapper = ItemsOnMap[i].GetComponent<CItemWrapper>();
                itemTxtLoader(ItemsOnMap[i].name, GameManager.instance.ItemManager.getItem(ItemsOnMap[i].name),
                    wrapper.NobleNumber, wrapper.KingNumber, wrapper.PSYNumber);
            }
        }

        if (isListOpen == true)
        {
            ListOBJ.SetActive(true);
        }
        else
        {
            ListOBJ.SetActive(false);
        }
    }

    void itemTxtLoader(string name, ItemDefinition def, int SzlachtaOPT, int KingOPT, int MentalOPT)
    {
        if (name != def.name) return;
        if (SzlachtaOPT > 0)
        {
            if (Szlachta_Items[0].GetComponent<Image>().sprite == SPRnone)
            {
                Szlachta_Items[0].GetComponent<Image>().sprite = def.icon;
            }
            else if (Szlachta_Items[1].GetComponent<Image>().sprite == SPRnone &&
                     Szlachta_Items[0].GetComponent<Image>().sprite !=  def.icon)
            {
                Szlachta_Items[1].GetComponent<Image>().sprite =  def.icon;
            }
            else if (Szlachta_Items[2].GetComponent<Image>().sprite == SPRnone &&
                     Szlachta_Items[0].GetComponent<Image>().sprite !=  def.icon &&
                     Szlachta_Items[1].GetComponent<Image>().sprite !=  def.icon)
            {
                Szlachta_Items[2].GetComponent<Image>().sprite =  def.icon;
            }
        }

        if (KingOPT > 0)
        {
            if (Krol_Items[0].GetComponent<Image>().sprite == SPRnone)
            {
                Krol_Items[0].GetComponent<Image>().sprite =  def.icon;
            }
            else if (Krol_Items[1].GetComponent<Image>().sprite == SPRnone &&
                     Krol_Items[0].GetComponent<Image>().sprite !=  def.icon)
            {
                Krol_Items[1].GetComponent<Image>().sprite =  def.icon;
            }
            else if (Krol_Items[2].GetComponent<Image>().sprite == SPRnone &&
                     Krol_Items[0].GetComponent<Image>().sprite !=  def.icon &&
                     Krol_Items[1].GetComponent<Image>().sprite !=  def.icon)
            {
                Krol_Items[2].GetComponent<Image>().sprite =  def.icon;
            }
        }

        if (MentalOPT > 0)
        {
            if (Psycha_Items[0].GetComponent<Image>().sprite == SPRnone)
            {
                Psycha_Items[0].GetComponent<Image>().sprite =  def.icon;
            }
            else if (Psycha_Items[1].GetComponent<Image>().sprite == SPRnone &&
                     Psycha_Items[0].GetComponent<Image>().sprite !=  def.icon)
            {
                Psycha_Items[1].GetComponent<Image>().sprite =  def.icon;
            }
            else if (Psycha_Items[2].GetComponent<Image>().sprite == SPRnone &&
                     Psycha_Items[0].GetComponent<Image>().sprite !=  def.icon &&
                     Psycha_Items[1].GetComponent<Image>().sprite !=  def.icon)
            {
                Psycha_Items[2].GetComponent<Image>().sprite =  def.icon;
            }
        }
    }
}