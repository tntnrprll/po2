using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightColor : Photon.PunBehaviour {

    public Slider LredSlider, LblueSlider, LgreenSlider;

    public Slider LStrengthSlider, LEffectSlider;

    public Text LSSText, LEASText, LredText, LgreenText, LblueText;


    

    byte lr, lg, lb;


    public GameObject SelectOption;

    public string vsText = "LIGHT";

    byte lstrength;
    byte lrange;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        lr = (byte)LredSlider.value;
        lg = (byte)LgreenSlider.value;
        lb = (byte)LblueSlider.value;

        lstrength = (byte)LStrengthSlider.value;
        lrange = (byte)LEffectSlider.value;

        LredText.text = lr.ToString();
        LgreenText.text = lg.ToString();
        LblueText.text = lb.ToString();

        LSSText.text = lstrength.ToString();
        LEASText.text = lrange.ToString();


        Color Lightcolor = new Color32(lr, lg, lb, 255);
        

        Text text = SelectOption.GetComponent<Text>();
        

        

        if (Input.GetMouseButtonDown(1))
        {

            if (text.text.Equals(vsText))
            {

                GameObject lightGameObject = new GameObject();

                Light light = lightGameObject.AddComponent<Light>();
                light.transform.position = transform.position;
                light.range = lrange;
                light.intensity = lstrength;
                light.color = Lightcolor;


                
            }


        }
    }
}
