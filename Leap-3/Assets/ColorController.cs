using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    public Material cubeColor;
    public Material backgroundColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cubeColor.color = Color.Lerp(Color.green, Color.blue, Mathf.PingPong(Time.time, 1));
        backgroundColor.color = Color.Lerp(Color.red, Color.magenta, Mathf.PingPong(Time.time, 1));
    }
}
