using UnityEngine;
using System.Collections;

public class ObrocDoPoziomu : MonoBehaviour {
    public GameObject bazaX;
    public GameObject bazaY;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float xxx = bazaX.transform.position.x;
        float yyy = bazaY.transform.position.y;
        float zzz = transform.position.z;
        transform.position = new Vector3(xxx, yyy, zzz);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
    }
}
