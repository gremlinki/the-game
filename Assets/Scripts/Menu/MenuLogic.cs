using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    //zmienne
    public bool Options_Open = false;
    public float AudioVolume = 50;
    //Graficzne UI
    public Slider AudioSlider;
    public Button Start_butt;
    public Button Options_butt;
    public Button Options_Exit_butt;
    public Button Exit_butt;
    // GameObjects
    public GameObject Options_PopUp;
    //audio mixer
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        Start_butt.onClick.AddListener(Play);
        Options_butt.onClick.AddListener(Options);
        Exit_butt.onClick.AddListener(Exit);
        Options_Exit_butt.onClick.AddListener(Options_Exit);
        AudioSlider.onValueChanged.AddListener(delegate {AudioValue();});
    }

    // Update is called once per frame
    void Update()
    {
        if(Options_Open == false){
            Options_PopUp.SetActive(false);
        }
        else if(Options_Open == true){
            Options_PopUp.SetActive(true);
        }
    }

    public void Exit(){
        Application.Quit();
    }

    public void Play(){
        SceneManager.LoadScene("Demo");
    }

    public void Options(){
        Options_Open = true;
    }
    public void Options_Exit(){
        Options_Open = false;
    }
    public void AudioValue(){
        AudioVolume = AudioSlider.value;
        mixer.SetFloat("MasterVolume", Mathf.Log10(AudioVolume) * 20);
    }
}
