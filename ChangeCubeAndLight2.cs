using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCubeAndLight2 : Photon.PunBehaviour {

    PhotonView photonview;
    
    

    [SerializeField] public GameObject makeCube;
    [SerializeField] public GameObject makeLight;

    [SerializeField] private int toggle = 2;

    private void Awake()
    {
        if(!photonView.isMine)
        {
            enabled = false;
        }
    }

    // Use this for initialization
    void Start () {
        photonview = PhotonView.Get(this);

        //makeCube = GameObject.Find("makeCube");
        //makeLight = GameObject.Find("makeLight");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [PunRPC]
    public void SelectOptionButtonClick(int toggle)
    {

        if (toggle==2)
        {
            /*PhotonView.Find(makeCube).gameObject.SetActive(false);
            PhotonView.Find(makeLight).gameObject.SetActive(true);*/


            makeCube.SetActive(false);
            makeLight.SetActive(true);
            
            
        }
        else if(toggle==1)
        {
            /*PhotonView.Find(makeCube).gameObject.SetActive(true);
            PhotonView.Find(makeLight).gameObject.SetActive(false);*/

            makeCube.SetActive(true);
            makeLight.SetActive(false);
            
        }
    }



    public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(toggle);
            stream.SendNext(makeCube.activeSelf);
            stream.SendNext(makeLight.activeSelf);
            

            
        }
        else if (stream.isReading)
        {
            toggle = (int)stream.ReceiveNext();
            makeCube.SetActive((bool)stream.ReceiveNext());
            makeLight.SetActive((bool)stream.ReceiveNext());
            
            

        }
    }

}
