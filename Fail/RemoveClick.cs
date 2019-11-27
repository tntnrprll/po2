using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveClick : MonoBehaviour {

    private GameObject target;

    public Ray ray;
    public RaycastHit hitInfo;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.R))
        {
            if (Input.GetMouseButtonDown(0))
            {

                
                target = GetClickedObject();
                

                Destroy(target);
            }
        }



    }

    
    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (true==(Physics.Raycast(ray.origin,ray.direction*10,out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

}
