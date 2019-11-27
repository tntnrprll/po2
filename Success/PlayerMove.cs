using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Slider moveSpeed;


    public float moveSpeedvalue;
    public float rotSpeed = 5.0f;

    public Camera cam;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCtrl();
        RotCtrl();



    }

    void MoveCtrl()
    {
        moveSpeedvalue = (float)moveSpeed.value;


        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * moveSpeedvalue * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * moveSpeedvalue * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSpeedvalue * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSpeedvalue * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Translate(Vector3.up * moveSpeedvalue * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Translate(Vector3.down * moveSpeedvalue * Time.deltaTime);

        }
    }

    void RotCtrl()
    {
        
        if (Input.GetMouseButton(0))
        {

            float yRot = Input.GetAxis("Mouse X") * rotSpeed;
            float xRot = Input.GetAxis("Mouse Y") * rotSpeed;


            this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
            cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float yRot = Input.GetAxis("Mouse X") * rotSpeed;
            float xRot = Input.GetAxis("Mouse Y") * rotSpeed;


            this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
            cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
        }






    }
}
