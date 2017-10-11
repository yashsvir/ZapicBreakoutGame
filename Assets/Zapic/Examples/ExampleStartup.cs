using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZapicSDK;

public class ExampleStartup : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Zapic.Connect();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
