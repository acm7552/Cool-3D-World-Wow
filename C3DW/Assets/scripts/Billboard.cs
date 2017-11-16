using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    Camera cam;

    [SerializeField]
    bool x, y, z;

    // Use this for initialization
    void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {

        //Look at the camera.
        Vector3 lookVector = cam.transform.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(-lookVector);
        transform.rotation = lookRotation;
    }
}
