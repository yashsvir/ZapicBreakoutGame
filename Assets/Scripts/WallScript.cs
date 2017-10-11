using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    private float scale = 0;
    private float incrementFactor = 50f;
    void Awake()
    {
        StartCoroutine(SizeEffect());

    }

    private IEnumerator SizeEffect()
    {
        while (scale < 100) {
            scale += incrementFactor * Time.deltaTime;
            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
        
    }
}
