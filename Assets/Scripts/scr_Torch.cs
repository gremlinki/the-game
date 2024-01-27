using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scr_Torch : MonoBehaviour
{

    Transform mainLight;
    Transform flickerLight;
    UnityEngine.Rendering.Universal.Light2D mainLightComponent;
    UnityEngine.Rendering.Universal.Light2D flickerLightComponent;


    // Start is called before the first frame update
    void Start()
    {
        flickerLightComponent = this.GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        for (; ; ) //this is while(true)
        {
            float randomIntensity = Random.Range(0.4f, 0.55f);
            flickerLightComponent.intensity = randomIntensity;


            float randomTime = Random.Range(0.09f, 0.14f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}