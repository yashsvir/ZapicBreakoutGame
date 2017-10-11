using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GameObject _parentObject;
    private float _roateSpeed = 5;
    private bool _isRotating = false;

    void Start()
    {
        _parentObject = GameObject.Find("GameObject");
    }
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }

        if (_isRotating)
        {
            _parentObject.transform.Rotate(new Vector3(0, 0, 1));
        }
    }
}
