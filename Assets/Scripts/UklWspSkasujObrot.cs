using UnityEngine;
using System.Collections;

public class UklWspSkasujObrot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.eulerAngles= new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
