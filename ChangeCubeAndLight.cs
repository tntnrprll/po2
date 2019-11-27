using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCubeAndLight : MonoBehaviour
{

    //PhotonView photonview;

    //public GameObject player;

    public GameObject BoxOption;
    public GameObject LightOption;
    //public Button SelectOption;

    //public Text SelectOptionText;

    //[SerializeField] public GameObject makeCube;
    //[SerializeField] public GameObject makeLight;

    private int toggle = 2;

    /*PhotonView photonviewCube;
    PhotonView photonviewLight;

    int cubeID;
    int lightID;
    


    //public GameObject Player;
    PhotonView photonviewPlayer;*/


    /*private void Awake()
    {
        if(!photonView.isMine)
        {
            enabled = false;
        }
    }

    private void OnDisable()
    {
        return;
    }*/

    // Use this for initialization
    void Start()
    {
        //photonview = PhotonView.Get(this);



        //photonviewPlayer = Player.GetComponent<PhotonView>();




        //photonviewPlayer = GameObject.Find("Capsule(Clone)").GetComponent<PhotonView>();


        //photonviewPlayer = GetComponent<PhotonView>();

        //photonviewPlayer = player.GetPhotonView();



        /*photonviewCube = makeCube.GetPhotonView();
        photonviewLight = makeLight.GetPhotonView();


        cubeID = PhotonNetwork.AllocateViewID();
        lightID = PhotonNetwork.AllocateViewID();


        photonviewCube.viewID = cubeID;
        photonviewLight.viewID = lightID;*/



    }

    // Update is called once per frame
    void Update()
    {
    }

    /*public void SelectOptionButtonClickRecive()
    {

        



        if (toggle==2)
        {

            BoxOption.SetActive(false);
            LightOption.SetActive(true);

            SelectOptionText.text = "LIGHT";



            //photonviewPlayer.RPC("SelectOptionButtonClick", PhotonTargets.All,toggle, photonviewCube.viewID, photonviewLight.viewID);
            //photonviewPlayer.RPC("SelectOptionButtonClick", PhotonTargets.All, 2);
            //photonView.RPC("SelectOptionButtonClick", PhotonTargets.All, 2);
            


            toggle = 1;
        }
        else
        {


            BoxOption.SetActive(true);
            LightOption.SetActive(false);

            SelectOptionText.text = "BOX";


            //photonviewPlayer.RPC("SelectOptionButtonClick", PhotonTargets.All,toggle, photonviewCube.viewID, photonviewLight.viewID);
            //photonviewPlayer.RPC("SelectOptionButtonClick", PhotonTargets.All, toggle);
            //photonView.RPC("SelectOptionButtonClick", PhotonTargets.All, toggle);


            toggle = 2;
            
        }

        
    }*/

    /*[PunRPC]
    void ChangeOption(bool boxoption,bool lightoption)
    {
        BoxOption.SetActive(boxoption);
        LightOption.SetActive(lightoption);
        

    }*/

    public void ChangeOption2(bool boxoption, bool lightoption)
    {
        BoxOption.SetActive(boxoption);//Box의 색과 크기를 변경할수 있는 패널의 활성여부
        LightOption.SetActive(lightoption);//Light의 색과 세기, 범위를 변경할 수 있는 패널의 활성여부

    }



    /*public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(toggle);
            stream.SendNext(makeCube.activeSelf);
            stream.SendNext(makeLight.activeSelf);
            
            
        }
        else if(stream.isReading)
        {
            toggle = (int)stream.ReceiveNext();
            makeCube.SetActive((bool)stream.ReceiveNext());
            makeLight.SetActive((bool)stream.ReceiveNext());
            

        }
    }*/

}
