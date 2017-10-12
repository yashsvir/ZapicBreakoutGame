using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructParticle : MonoBehaviour {

    void Awake()
    {   
        StartCoroutine(DestroyAfterSeconds());
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(GameSettings.destroyParticlesTime);
        Destroy(gameObject);
    }
}
