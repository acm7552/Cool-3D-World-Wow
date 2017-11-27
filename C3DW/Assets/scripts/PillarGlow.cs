using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarGlow : MonoBehaviour {

    Animator anim;

    [SerializeField]
    Transform player;

    [SerializeField]
    float range;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("On", Vector3.Distance(player.position, transform.position) < range);
	}
}
