using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelLoader : MonoBehaviour {

    private float _angleDiff;
    private float _radius = 0;
    private GameObject[] _prefabs;
    private GameObject _parentObject;
    
    void Start()
    {
        // Reset();
        _parentObject = GameObject.Find("BrickObject");
        _angleDiff = 360 / GameSettings.numberOfWalls;
        _prefabs = (Resources.LoadAll("GameObjects", typeof(GameObject))).Cast<GameObject>().ToArray();

    }

    public void Reset()
    {
        foreach (Transform child in _parentObject.transform)
        {
            Destroy(child.gameObject);
        }
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() {
        
        while(GameSettings.gameState != EnumTypes.GameState.PlayMode)
        {
            yield return null;
        }
        Vector3 center = transform.position;
        bool bSwitchWall = false;

        for (int zone = 1; zone < 3; zone++)
        {
            ChangeRadius(zone);
            for (int i = 0; i < GameSettings.numberOfWalls; i++)
            {
                float angle = i * _angleDiff;
                Vector3 pos;
                pos.x = center.x + _radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                pos.y = center.y + _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                pos.z = center.z;
                GameObject temp;
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, center - pos);
                if (bSwitchWall)
                {
                    temp = Instantiate(_prefabs[0], pos, rot);
                    bSwitchWall = !bSwitchWall;
                }
                else
                {
                    temp = Instantiate(_prefabs[1], pos, rot);
                    bSwitchWall = !bSwitchWall;
                }
                temp.transform.localScale = new Vector3(0, 0, 0);
                temp.transform.parent = _parentObject.transform;
                temp.GetComponent<WallScript>().SetTime(i * 0.2f);
                temp.GetComponent<WallScript>().SetZone(zone);
            }
            bSwitchWall = !bSwitchWall;
        }

    }

    void ChangeRadius(int zone)
    {
        if (zone == 1)
        {
            _radius = GameSettings.radiusZoneOne;
        }
        else if (zone == 2)
        {
            _radius = GameSettings.radiusZoneTwo;
        }
    }

    
}
