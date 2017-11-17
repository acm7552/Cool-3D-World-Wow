using UnityEngine.UI;
using UnityEngine;

public class CollectibleCounter : MonoBehaviour {

    [SerializeField]
    Sprite[] amounts;

    [SerializeField]
    Image image;

    int count;
    public int Count {
        get { return count; }
        set {
            count = value;
            count = (int)Mathf.Clamp(count, 0, 8);

            UpdateUi();
        }
    }

	// Use this for initialization
	void Start () {
        Count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUi() {
        image.sprite = amounts[count];
    }
}
