using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExitScript : MonoBehaviour {


    public GameObject Menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuSetExit()
    {
        Menu.SetActive(!Menu.active);
    }
}
