using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    private float _initalVelocity = 300f;
    private Rigidbody _rb;
    private float _initialBallAngle;
    void Awake()
    {
        StartCoroutine(FireBall());
        _rb = GetComponent<Rigidbody>();
        _initialBallAngle = UnityEngine.Random.Range(0, 360);
    }

    private IEnumerator FireBall()
    {
        yield return new WaitForSeconds(2);

        _rb.isKinematic = false;
        _rb.AddForce(new Vector3(_initalVelocity*Mathf.Sin(_initialBallAngle *Mathf.Deg2Rad), _initalVelocity * Mathf.Cos(_initialBallAngle * Mathf.Deg2Rad), 0));

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Brick")
        {
            Destroy(col.gameObject);
        }
        

    }

    /*void Update() {
        Debug.Log(_rb.velocity.magnitude);
    }*/
}
