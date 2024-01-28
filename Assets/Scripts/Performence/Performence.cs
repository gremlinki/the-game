using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Performence : MonoBehaviour
{
    private GameManager gameManager;
    private RelationManager relationManager;

    public GameObject JesterFill;
    public GameObject KingFill;
    public GameObject NobleFill;

    public TMP_Text JesterText;
    public TMP_Text KingText;
    public TMP_Text NobleText;

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

        if (relationManager.mentalLevel == 1){
            JesterText.text = "I \"Ignoramus\"";
        }else if (relationManager.mentalLevel == 2){
            JesterText.text = "II \"Initium\"";
        }else if(relationManager.mentalLevel == 3){
            JesterText.text = "III \"Floret\"";
        }else if(relationManager.mentalLevel == 4){
            JesterText.text = "IV \"Fulcrum\"";
        }


        if (relationManager.kingLevel == 1){
            KingText.text = "I \"Apprentice jester\"";
        }else if (relationManager.kingLevel == 2){
            KingText.text = "II \"Jester\"";
        }else if(relationManager.kingLevel == 3){
            JesterText.text = "III \"Senior Jester\"";
        }else if(relationManager.kingLevel == 4){
            KingText.text = "IV \"Toomfollery PhD\"";
        }

        if (relationManager.nobillityLevel == 1){
            NobleText.text = "I \"No name\"";
        }else if (relationManager.nobillityLevel == 2){
            NobleText.text = "II \"Rising Star\"";
        }else if(relationManager.nobillityLevel == 3){
            NobleText.text = "III \"Popular Figurehead\"";
        }else if(relationManager.nobillityLevel == 4){
            NobleText.text = "IV \"Expert Joketeller\"";
        }
    }
}
