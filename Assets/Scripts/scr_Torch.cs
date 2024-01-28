using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scr_Torch : MonoBehaviour{
    UnityEngine.Rendering.Universal.Light2D flickerLightComponent;

    void Start(){
        flickerLightComponent = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        StartCoroutine(Timer());
    }

    IEnumerator Timer(){
        for (; ; ){
            float randomIntensity = Random.Range(0.45f, 0.55f);
            flickerLightComponent.intensity = randomIntensity;
            float randomTime = Random.Range(0.11f, 0.17f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
