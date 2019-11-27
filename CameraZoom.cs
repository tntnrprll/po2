using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public Transform player;
    float Zoom;
    private Transform tr;

	// Use this for initialization
	void Start () {
        Zoom = 10f;
        tr = GetComponent<Transform>();
	}
	
	void LateUpdate()
    {
        CameraZoomm();
    }
    void CameraZoomm()
    {
        Vector3 dist_position = (tr.position) - (player.position);
        dist_position = Vector3.Normalize(dist_position);
        


        tr.position -= (dist_position * Input.GetAxis("Mouse ScrollWheel") * Zoom);
    }


}
