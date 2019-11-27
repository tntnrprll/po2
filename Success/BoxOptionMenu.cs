using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxOptionMenu : MonoBehaviour {

    public GameObject BoxOption;
    public GameObject LightOption;
    public GameObject SelectOption;

    private bool toggle=false;

    public GameObject makeCube;
    public GameObject makeLight;
    

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectBoxMenu()
    {
        BoxOption.SetActive(!BoxOption.active);
        LightOption.SetActive(!LightOption.active);

        Text text = SelectOption.GetComponent<Text>();

        if (!toggle)
        {

            /*text.text = "LIGHT";*/

            toggle = true;

            makeCube.SetActive(!makeCube.active);
            makeLight.SetActive(!makeLight.active);
        }
        else
        {

            /*text.text = "BOX";*/

            toggle = false;

            makeCube.SetActive(!makeCube.active);
            makeLight.SetActive(!makeLight.active);
        }


        
    }
}
