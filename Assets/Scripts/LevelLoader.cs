using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelLoader : MonoBehaviour {

    private int _numberOfWalls = 8;
    private float _angleDiff;
    private float _radius = 5.5f;
    private GameObject[] _prefabs;
    
    void Start()
    {
        _angleDiff = 360/_numberOfWalls;
        Vector3 center = transform.position;
        _prefabs =(Resources.LoadAll("GameObjects", typeof(GameObject))).Cast<GameObject>().ToArray();
        bool bSwitchWall = false;
        for (int i = 0; i < _numberOfWalls; i++)
        {
            float angle = i* _angleDiff;
            Vector3 pos;
            pos.x = center.x + _radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            pos.y = center.y + _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            pos.z = center.z;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, center - pos);
            if (bSwitchWall)
            {
                Instantiate(_prefabs[0], pos, rot);
                bSwitchWall = !bSwitchWall;
            }
            else {
                Instantiate(_prefabs[1], pos, rot);
                bSwitchWall = !bSwitchWall;
            }
        }
    }

    
}
