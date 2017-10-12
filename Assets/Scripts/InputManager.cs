using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GameObject _parentObject;
    private float _roateSpeed = 0;
    private bool _isRotating = false;
    private Ball _ball;

    void Start()
    {
        _parentObject = GameObject.Find("BrickObject");
        _ball = GameObject.Find("Sphere").GetComponent<Ball>();
    }
    void Update() {
        if (GameSettings.gameState == EnumTypes.GameState.PlayMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isRotating = true;
                Vector3 mousePos = Input.mousePosition;
                mousePos.x -= Screen.width / 2;
                _roateSpeed = mousePos.x > 0 ? -(GameSettings.rotatingSpeed) : (GameSettings.rotatingSpeed);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isRotating = false;
            }

            if (_isRotating)
            {
                _parentObject.transform.Rotate(new Vector3(0, 0, _roateSpeed * Time.deltaTime));
            }
        }
    }

    public void BeginGame()
    {
        
        GameSettings.gameState = EnumTypes.GameState.PlayMode;
        Camera.main.transform.Rotate(0, 180, 0);
        _ball.Reset();
    }
}
