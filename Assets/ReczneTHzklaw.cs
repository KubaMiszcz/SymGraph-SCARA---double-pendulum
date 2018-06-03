using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReczneTHzklaw : MonoBehaviour {
    public KeyCode up;
    public KeyCode down;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(up))
        { transform.GetComponent<Slider>().value++; }
        if (Input.GetKey(down))
        { transform.GetComponent<Slider>().value--; }
    }
    
}
