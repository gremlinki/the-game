using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameChanger : MonoBehaviour
{
    public Sprite[] SPR;
    public string[] STR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 9; i++){
            if(gameObject.GetComponent<SpriteRenderer>().sprite == SPR[i]){
                gameObject.name = STR[i];
            }
        }
    }
}
