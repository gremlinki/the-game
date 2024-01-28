using System.Collections;
using System.Collections.Generic;
using ItemSystem;
using UnityEngine;

public class NameChanger : MonoBehaviour
{
    [SerializeField] private ItemDefinition[] defs;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 9; i++){
            if(gameObject.GetComponent<SpriteRenderer>().sprite == defs[i].icon){
                gameObject.name = defs[i].name;
            }
        }
    }
}
