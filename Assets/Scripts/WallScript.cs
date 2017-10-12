using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    private float scale = 0;
    private int _maxScale = 0;
    private float _delayTime = 0;
    

    public void SetTime(float iTime)
    {
        _delayTime = iTime;
    }

    public void SetZone(int zone)
    {
        if (zone == 1)
        {
            _maxScale = 100;
        }
        else if(zone == 2)
        {
            _maxScale = 150;
        }

        StartCoroutine(SizeEffect());
    }


    private IEnumerator SizeEffect()
    {
        yield return new WaitForSeconds(_delayTime);
        while (scale < _maxScale) {
            scale += GameSettings.wallIncrementFactor * Time.deltaTime;
            transform.localScale = new Vector3(scale, scale, 100);
            yield return null;
        }
        
    }
}
