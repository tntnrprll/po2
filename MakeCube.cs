using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeCube : Photon.PunBehaviour
{

    PhotonView photonview;


    public Transform cubeTransform;

    Slider redSlider, blueSlider, greenSlider;
    Text redText, blueText, greenText;

    Slider sizeSliderX, sizeSliderY, sizeSliderZ;
    Text sizeXText, sizeYText, sizeZText;

    [SerializeField]Renderer renderer;

    [SerializeField] byte r;
    [SerializeField] byte g;
    [SerializeField] byte b;

    //byte r,g,b;




    [SerializeField] int x, y, z;

    





    private void Awake()
    {
        if (!photonView.isMine)//내 것에서 일어난 일인가를 판단
        {
            enabled = false;//내것이 아니라면 변화를 허용하지 않음
        }
    }

    void Start()
    {

        photonview = PhotonView.Get(this);

        

        

        redSlider = GameObject.Find("redSlider").GetComponent<Slider>();
        redText = GameObject.Find("redText").GetComponent<Text>();

        blueSlider = GameObject.Find("blueSlider").GetComponent<Slider>();
        blueText = GameObject.Find("blueText").GetComponent<Text>();

        greenSlider = GameObject.Find("greenSlider").GetComponent<Slider>();
        greenText = GameObject.Find("greenText").GetComponent<Text>();


        sizeSliderX = GameObject.Find("sizeSliderX").GetComponent<Slider>();
        sizeXText = GameObject.Find("sizeXText").GetComponent<Text>();

        sizeSliderY = GameObject.Find("sizeSliderY").GetComponent<Slider>();
        sizeYText = GameObject.Find("sizeYText").GetComponent<Text>();

        sizeSliderZ = GameObject.Find("sizeSliderZ").GetComponent<Slider>();
        sizeZText = GameObject.Find("sizeZText").GetComponent<Text>();


        renderer = gameObject.GetComponent<Renderer>();

    }


    private void OnDisable()
    {
        return;
    }

    private void OnEnable()
    {

    }


    // Update is called once per frame
    void Update()
    {
        r = (byte)redSlider.value;
        g = (byte)greenSlider.value;
        b = (byte)blueSlider.value;

        x = (int)sizeSliderX.value;
        y = (int)sizeSliderY.value;
        z = (int)sizeSliderZ.value;

        redText.text = r.ToString();
        blueText.text = b.ToString();
        greenText.text = g.ToString();

        sizeXText.text = x.ToString();
        sizeYText.text = y.ToString();
        sizeZText.text = z.ToString();

        Color colorvar = new Color32(r, g, b, 255);
        Vector3 boxScale = new Vector3(x, y, z);
        transform.localScale = boxScale;
        renderer.material.color = colorvar;

        if (Input.GetMouseButtonDown(1))//마우스 오른쪽 버튼이 눌리면
        {

            GameObject cube = PhotonNetwork.Instantiate("Cube", cubeTransform.transform.position, cubeTransform.transform.rotation, 0);
            /*현재의 위치에 Cube 오브젝트를 생성*/

            cube.GetComponent<Transform>().localScale = boxScale;


            PhotonView photonview = cube.GetComponent<PhotonView>();
            /* 생성된 Cube오브젝트의 관찰 컴포넌트 PhotonView를 가져옴*/

            photonview.RPC("ChangeColor", PhotonTargets.All,r,g,b);
            /*원격 프로시저 호출 Cube에 있는 함수중 ChangeColor를 호출, 호출되는 대상은 모든 사용자,전달할 내용은 r,g,b 값*/

        }

    






    }



    
    void CreateCube()
    {
        

        //Color colorvar = new Color32(r, g, b, 255);
        //Vector3 boxScale = new Vector3(x, y, z);

        //renderer.material.color = colorvar;
        //transform.localScale = boxScale;
        
        
        //GameObject cube = PhotonNetwork.Instantiate("Cube", cubeTransform.transform.position, cubeTransform.transform.rotation, 0);
        //cube.GetComponent<MeshRenderer>().material.color = colorvar;
        //cube.GetComponent<Transform>().localScale = boxScale;
        

        



    }
    


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(r);
            stream.SendNext(g);
            stream.SendNext(b);
        }
        else if (stream.isReading)
        {
            r = (byte)stream.ReceiveNext();
            g = (byte)stream.ReceiveNext();
            b = (byte)stream.ReceiveNext();
        }
    }


}
