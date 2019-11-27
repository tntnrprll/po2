using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeLight : Photon.PunBehaviour {

    PhotonView photonview;

    public Transform lightTransform;

    Slider redSlider, blueSlider, greenSlider;
    Text redText, blueText, greenText;

    Slider LightStrengthSlider, LightEffectAreaSlider;
    Text LSSText, LEASText;

    //[SerializeField]Renderer renderer;

    [SerializeField] byte r, g, b;
    [SerializeField] int s, e;

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


        redSlider = GameObject.Find("RedSlider").GetComponent<Slider>();
        redText = GameObject.Find("RSText").GetComponent<Text>();

        blueSlider = GameObject.Find("BlueSlider").GetComponent<Slider>();
        blueText = GameObject.Find("BSText").GetComponent<Text>();

        greenSlider = GameObject.Find("GreenSlider").GetComponent<Slider>();
        greenText = GameObject.Find("GSText").GetComponent<Text>();

        LightStrengthSlider = GameObject.Find("LightStrengthSlider").GetComponent<Slider>();
        LSSText = GameObject.Find("LSSText").GetComponent<Text>();

        LightEffectAreaSlider = GameObject.Find("LightEffectAreaSlider").GetComponent<Slider>();
        LEASText = GameObject.Find("LEASText").GetComponent<Text>();

        


        //renderer = gameObject.GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        return;
    }

    // Update is called once per frame
    void Update () {
        r = (byte)redSlider.value;
        g = (byte)greenSlider.value;
        b = (byte)blueSlider.value;

        redText.text = r.ToString();
        blueText.text = b.ToString();
        greenText.text = g.ToString();

        s = (int)LightStrengthSlider.value;
        e = (int)LightEffectAreaSlider.value;

        LSSText.text = s.ToString();
        LEASText.text = e.ToString();

        Color colorvar = new Color32(r, g, b, 255);
        this.GetComponent<Light>().color = colorvar;
        this.GetComponent<Light>().intensity = s;
        this.GetComponent<Light>().range = e;

        if (Input.GetMouseButtonDown(1))
        {
            GameObject light = PhotonNetwork.Instantiate("Light", lightTransform.transform.position, lightTransform.transform.rotation, 0);

            
            

            PhotonView photonview = light.GetComponent<PhotonView>();

            photonview.RPC("ChangeLightColor", PhotonTargets.All, r, g, b, s, e);



        }

    }
    public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
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
