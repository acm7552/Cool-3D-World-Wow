using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarGlow : MonoBehaviour {

    Animator anim;

    [SerializeField]
    PillarTrigger trigger;

    bool lastTrigger;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(trigger.on != lastTrigger)
        {
            anim.SetBool("On", true);
        }

        lastTrigger = trigger.on;
	}
}
