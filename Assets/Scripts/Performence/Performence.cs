using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Performence : MonoBehaviour
{
    private GameManager gameManager;
    private RelationManager relationManager;

    public GameObject JesterFill;
    public GameObject KingFill;
    public GameObject NobleFill;

    public float KingFillNumber;
    public float NobleFillNumber;
    public float JesterillNumber;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        relationManager = gameManager.relationManager;
    }

    // Update is called once per frame
    void Update()
    {
        AutomaticAfflictionSlider();
    }

    public void AutomaticAfflictionSlider(){
        KingFillNumber = 1 - relationManager.kingAffinity / 100.0f;
        NobleFillNumber = 1 - relationManager.nobillityAffinity / 100.0f;
        JesterillNumber = 1 - relationManager.mentalHealth / 100.0f;

        JesterFill.GetComponent<Image>().fillAmount = JesterillNumber;
        NobleFill.GetComponent<Image>().fillAmount = NobleFillNumber;
        KingFill.GetComponent<Image>().fillAmount = KingFillNumber;
    }
}
