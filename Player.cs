using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.PunBehaviour {

    Camera playerCam;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        playerCam = GetComponentInChildren<Camera>();

        if(!photonView.isMine)
        {
            playerCam.gameObject.SetActive(false);
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
