using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class XYcoords : MonoBehaviour {
    public Text XYlabel;
    public GameObject bazaXY;
    public Camera MainCamera;
    float offsetX;
    float offsetY;
    float offsetZ;
    public Toggle onoff;

    // Use this for initialization
    void Start () {
        offsetX = bazaXY.transform.position.x;
        offsetY = bazaXY.transform.position.y;
        offsetZ = bazaXY.transform.position.z;
    }
    void Update() {
        transform.gameObject.SetActive(true);
    }

	// Update is called once per frame
	void LateUpdate () {
        double XXX = Math.Round((transform.parent.transform.position.x-offsetX)* (10 / 3.122925f),1);
        double YYY = Math.Round((transform.parent.transform.position.y - offsetY)* (10 / 3.122925f),1);
        double ZZZ = Math.Round((transform.parent.transform.position.z - offsetZ)* (10 / 3.122925f),1);
        XYlabel.text = XXX.ToString("0.0") + "\n" + YYY.ToString("0.0") + "\n" + ZZZ.ToString("0.0"); ;
        //transform.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
        transform.LookAt(MainCamera.transform);

    }
}
