using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pickup : MonoBehaviour {

    [SerializeField]
    bool hasObject, rotateMode = false;

    [SerializeField]
    float rotateSpeed, range, placeSpeed, throwSpeed, rotateTransitionSpeed, angularLaunchSpeed;

    [HideInInspector]
    public GameObject heldObject;

    [SerializeField]
    Transform hand;

    [SerializeField]
    LayerMask mask;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (heldObject)
                Throw(throwSpeed);
            else
                TryPickUp();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (heldObject)
                Drop();
        }

        if (Input.GetMouseButtonDown(1))
            rotateMode = true;
        if (Input.GetMouseButtonUp(1))
            rotateMode = false;

        if (rotateMode && heldObject) {
            hand.transform.localPosition = Vector3.Lerp(hand.transform.localPosition, new Vector3(0, 0, 1.5f), Time.deltaTime * rotateTransitionSpeed);

            heldObject.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed, Space.World);
            GetComponent<FirstPersonController>().enabled = false;
        } else if ((!rotateMode || !heldObject)) {
            hand.transform.localPosition = Vector3.Lerp(hand.transform.localPosition, new Vector3(0.5f, -0.5f, 1f), Time.deltaTime * rotateTransitionSpeed);
            GetComponent<FirstPersonController>().enabled = true;
        }
    }

    void TryPickUp() {
        RaycastHit r;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out r, range, mask)) {
            Debug.Log(r.collider.gameObject.name);
            if (!heldObject && r.collider.gameObject.tag == "Pickup") {
                PickUp(r.collider.gameObject);

                if (r.collider.GetComponent<Shard>()) {
                    r.collider.GetComponent<Shard>().Pickup();
                }
            }
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
            Throw(placeSpeed);

        }
    }

    void Throw(float force) {
        if (hasObject) {
            heldObject.transform.parent = null;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            //heldObject.GetComponent<Collider>().enabled = true;

            heldObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force);
            heldObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(
                Random.Range(-angularLaunchSpeed, angularLaunchSpeed),
                Random.Range(-angularLaunchSpeed, angularLaunchSpeed),
                Random.Range(-angularLaunchSpeed, angularLaunchSpeed));

            heldObject = null;
            hasObject = false;
        }
    }
}
