using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorChange : Photon.PunBehaviour {

    [SerializeField] byte r, g, b;
    [SerializeField] int s, e;

    PhotonView photonview;



	// Use this for initialization
	void Start () {
        photonview = this.GetComponent<PhotonView>();
        
	}
	
    [PunRPC]
    void ChangeLightColor(byte r,byte g,byte b,int s,int e)
    {
        Light light = this.GetComponent<Light>();

        light.color = new Color32(r, g, b, 255);
        light.intensity = s;
        light.range = e;
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {



            stream.SendNext(r);
            stream.SendNext(g);
            stream.SendNext(b);

            stream.SendNext(s);
            stream.SendNext(e);
            //Debug.Log("writing = " + r + " " + g + " " + b);
        }
        else if (stream.isReading)
        {


            r = (byte)stream.ReceiveNext();
            g = (byte)stream.ReceiveNext();
            b = (byte)stream.ReceiveNext();

            s = (int)stream.ReceiveNext();
            e = (int)stream.ReceiveNext();
            Debug.Log("reading = " + r + " " + g + " " + b);
        }
    }
}
