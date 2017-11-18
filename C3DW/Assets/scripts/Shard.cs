using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour {

    UIController uic;

	// Use this for initialization
	void Start () {
        uic = FindObjectOfType<UIController>();
	}

    public void Pickup() {
        uic.UpdateShardsUi();
        Destroy(gameObject);
    }
}
