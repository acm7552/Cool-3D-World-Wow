using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    Image reticle, shardsUi;

    [SerializeField]
    Sprite[] reticles, shards;
    public int numShards;

    [SerializeField]
    float pickupRange;
    
    [SerializeField]
    LayerMask mask;

    Pickup p;

    // Use this for initialization
    void Start () {
        p = FindObjectOfType<Pickup>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!p.heldObject) {

            RaycastHit r;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out r, pickupRange, mask)) {
                reticle.sprite = reticles[1];
            } else
                reticle.sprite = reticles[0];
        } else {

            reticle.sprite = reticles[0];

            if (Input.GetMouseButton(1)) {
                reticle.sprite = reticles[2];
            }
        }
    }

    public void UpdateShardsUi() {
        numShards++;
        shardsUi.sprite = shards[numShards];
    }
}
