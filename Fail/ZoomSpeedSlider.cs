using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSpeedSlider : MonoBehaviour {

    public Slider ZoomSlider;
    byte zoomvalue;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        zoomvalue = (byte)ZoomSlider.value;
        


	}
}
