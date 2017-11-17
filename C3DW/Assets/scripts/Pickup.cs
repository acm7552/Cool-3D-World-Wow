using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pickup : MonoBehaviour {

    public bool hasObject;
    public bool rotateMode = false;
    public float rotateSpeed;

    public float range;
    public GameObject heldObject;
    public Transform hand;

    public float throwSpeed;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (heldObject)
                Throw();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (heldObject)
                Drop();
            else
                TryPickUp();
        }

        if (Input.GetMouseButtonDown(1))
            rotateMode = true;
        if (Input.GetMouseButtonUp(1))
            rotateMode = false;

        if (rotateMode && heldObject) {
            heldObject.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
            GetComponent<FirstPersonController>().enabled = false;
        } else if ((!rotateMode || !heldObject) && PlayerPrefs.GetInt("Run") != 3) {
            GetComponent<FirstPersonController>().enabled = true;
        }
    }

    void TryPickUp() {
        RaycastHit r;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out r, range)) {
            if (!heldObject && r.collider.gameObject.tag == "Pickup")
                PickUp(r.collider.gameObject);
        }
    }

    void PickUp(GameObject obj) {
        obj.transform.position = hand.position;
        obj.transform.parent = hand;

        hasObject = true;
        heldObject = obj;

        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        //heldObject.GetComponent<Collider>().enabled = false;
    }

    void Drop() {
        if (hasObject) {
            heldObject.transform.parent = null;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            //heldObject.GetComponent<Collider>().enabled = true;

            heldObject = null;
            hasObject = false;

        }
    }

    void Throw() {
        if (hasObject) {
            heldObject.transform.parent = null;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            //heldObject.GetComponent<Collider>().enabled = true;

            heldObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwSpeed);

            heldObject = null;
            hasObject = false;
        }
    }
}
