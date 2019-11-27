using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeState : MonoBehaviour {


    public Slider redSlider, blueSlider, greenSlider;

    public Slider sizeSliderX, sizeSliderY, sizeSliderZ;

    public Text redText, blueText, greenText;

    public Text sizeXText, sizeYText, sizeZText;

    public string vsText = "BOX";

    



    Renderer renderer;

    public GameObject SelectOption;





    byte r, g, b;

    int x, y, z;

    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void SetColor()
    {
        r = (byte)redSlider.value;
        g = (byte)greenSlider.value;
        b = (byte)blueSlider.value;

        x = (int)sizeSliderX.value;
        y = (int)sizeSliderY.value;
        z = (int)sizeSliderZ.value;


        redText.text = r.ToString();
        greenText.text = g.ToString();
        blueText.text = b.ToString();

        sizeXText.text = x.ToString();
        sizeYText.text = y.ToString();
        sizeZText.text = z.ToString();





        Color color = new Color32(r, g, b, 255);
        Vector3 boxScale = new Vector3(x, y, z);



        renderer.material.color = color;
        transform.localScale = boxScale;


        Text text = SelectOption.GetComponent<Text>();

        this.GetComponent<MeshRenderer>().material.color = color;
    }

}
