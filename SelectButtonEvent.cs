using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonEvent : Photon.PunBehaviour {

    PhotonView photonview;

    public GameObject BoxOption;
    public GameObject LightOption;
    public GameObject SelectOption;

    public Text SelectOptionText;

    public GameObject makeCube;
    public GameObject makeLight;

    private int toggle = 2;

    private void Awake()
    {
        if(!photonView.isMine)
        {
            enabled = false;
        }
    }

    private void OnDisable()
    {
        return;
    }

    // Use this for initialization
    void Start () {
        photonview = PhotonView.Get(this);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectButtonClick()
    {
        if(toggle==2)
        {
            BoxOption.SetActive(false);
            LightOption.SetActive(true);

            SelectOptionText.text = "LIGHT";

            makeCube.SetActive(false);
            makeLight.SetActive(true);
        }
        else if(toggle==1)
        {
            BoxOption.SetActive(true);
            LightOption.SetActive(false);

            SelectOptionText.text = "BOX";

            makeCube.SetActive(true);
            makeLight.SetActive(false);
        }
    }

}
