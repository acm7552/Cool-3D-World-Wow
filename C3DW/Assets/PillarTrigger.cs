using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTrigger : MonoBehaviour {

    public bool on;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            on = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            on = false;
    }
}
