using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    RawImage img;

    [SerializeField]
    Transform target;

	// Use this for initialization
	void Start () {
        img = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {

        float ang = SignedAngleBetween(target.forward, Vector3.forward, Vector3.up);

        img.uvRect = new Rect(ang / 360.0f, img.uvRect.y, img.uvRect.width, img.uvRect.height);

	}

    float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n) {
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));
        
        float signed_angle = angle * sign;

        // angle in [0,360]
        return (signed_angle + 180) % 360;
    }
}
