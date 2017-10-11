using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GameObject _parentObject;
    private float _roateSpeed = 0;
    private bool _isRotating = false;

    void Start()
    {
        _parentObject = GameObject.Find("GameObject");
    }
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;

            Vector3 mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2;
            _roateSpeed = mousePos.x > 0 ? 50f : -50f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }

        if (_isRotating)
        {
            _parentObject.transform.Rotate(new Vector3(0, 0, _roateSpeed*Time.deltaTime));
        }
    }
}
