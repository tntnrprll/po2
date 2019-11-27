using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCharacterChoose : MonoBehaviour {

    public GameObject FirstSceneUI;
    public GameObject SecondSceneUI;

    public GameObject NextButton;


	// Use this for initialization
	void Start () {
		
	}
	

    public void ButtonClick()
    {
        FirstSceneUI.SetActive(!FirstSceneUI);
        SecondSceneUI.SetActive(!SecondSceneUI);
    }
    
}
