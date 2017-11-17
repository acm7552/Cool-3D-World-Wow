using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    Color colorLow, colorHigh;

    [SerializeField]
    Vector2 bounds;

    [SerializeField]
    float minDensity, maxDensity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float y = target.position.y;

        float f = y / (bounds.y - bounds.x);

        RenderSettings.fogDensity = Mathf.Lerp(minDensity, maxDensity, f);
        RenderSettings.fogColor = Color.Lerp(colorHigh, colorLow, f);
	}
}
