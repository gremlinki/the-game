using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class PlayerTorch : MonoBehaviour
{
    private Light2D light;
    [SerializeField] private float speed = 40f;

    private void Awake()
    {
        light = GetComponent<Light2D>();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(true)
        {
            float randomIntensity = Random.Range(0.45f, 0.55f);
            light.intensity = randomIntensity;
            float randomTime = Random.Range(0.11f, 0.17f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
