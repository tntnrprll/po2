using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : Photon.PunBehaviour {

    [SerializeField]byte r;
    [SerializeField] byte g;
    [SerializeField] byte b;

    PhotonView photonview;

    Renderer renderer;


    // Use this for initialization
    void Start () {
        photonview = this.GetComponent<PhotonView>();

        renderer = gameObject.GetComponent<Renderer>();
    }
	
    


    [PunRPC]
    void ChangeColor(byte r,byte g,byte b)//원격 프로시저로 호출될 수 있는 함수
    {
        this.GetComponent<Renderer>().material.color = new Color32(r,g,b,255);
        /*현재 이 컴포넌트를 가진 오브젝트의 Renderer를 가져와 material 의 색을 전달받은 r,g,b값으로 변경한다*/ 
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(r);
            stream.SendNext(g);
            stream.SendNext(b);

            //Debug.Log("Writing " + r + " " + g + " " + b);
        }
        else if(stream.isReading)
        {
            r = (byte)stream.ReceiveNext();
            g = (byte)stream.ReceiveNext();
            b = (byte)stream.ReceiveNext();

            //Debug.Log("Reading "+r+" "+g+" "+b);

        }
    }

}
