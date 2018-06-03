using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class orbitkuba : MonoBehaviour {
    public GameObject target;
    public Transform XY, XZ, YZ;
    private Vector3 startPos;
    private Quaternion startRot;
    public Transform osX, osY, osZ;

    public Slider czuloscZoom;
    public Slider czuloscPan;
    public Slider czuloscRotate;
       

    //public GameObject SliderSzybkoscZoom;

    //zoom
    //private Vector3 distance;
    private float _x, _y;
    public float _xSpeed,_ySpeed;
    public float _zoomStep;
    public float offset;

    //PAN
    public float mouseSensitivity = 20f;
    //private GameObject SliderSzybkoscPan;
    private Vector3 lastPosition;
    //private int x = 0, y = 0;

    // Use this for initialization
    void Start () {
        ResetCameraXZ();
        //startRot = transform.rotation;

        //Zoom
        //distance = target.transform.position - this.transform.position;
        _xSpeed = czuloscRotate.value;
        _ySpeed=czuloscRotate.value;
        _zoomStep = czuloscZoom.value*20f;

        //Pan
        mouseSensitivity = czuloscPan.value;// SliderSzybkoscPan.GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update() {
        _xSpeed = czuloscRotate.value;
        _ySpeed = czuloscRotate.value;
        _zoomStep = czuloscZoom.value*20f;
        mouseSensitivity = czuloscPan.value;
    }


	void LateUpdate () {

        //obracanie kamery
        if (Input.GetMouseButton(2) )    //0,1,2 => left,right,middle mouse button
        {
            _x = -Input.GetAxis("Mouse X") * _xSpeed;
            _y = -Input.GetAxis("Mouse Y") * _ySpeed;
            transform.Translate(_x, _y, 0);
            transform.LookAt(target.transform);
        }

        //zoom
        Zoom();


        //pan
        //mouseSensitivity = SliderSzybkoscPan.GetComponent<Slider>().value;
        if (Input.GetMouseButtonDown(1))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            transform.Translate(-delta.x * mouseSensitivity / 1000f, -delta.y * mouseSensitivity / 1000f, 0);
            lastPosition = Input.mousePosition;
        }
    }


    void Zoom()
    {
        //_zoomStep = SliderSzybkoscZoom.GetComponent<Slider>().value;

        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            
            transform.GetComponent<Camera>().orthographicSize += _zoomStep / 100f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            transform.GetComponent<Camera>().orthographicSize -= _zoomStep / 100f;
        }

    }

    public void ResetCameraXZ()
    {
        ResetCamera(XZ);
        osX.eulerAngles = new Vector3(0f, 0f, 0f);
        osY.eulerAngles = new Vector3(0f, 90f, 0f);
        osZ.eulerAngles = new Vector3(0f, 0f, 90f);
    }

    public void ResetCameraXY()
    {
        ResetCamera(XY);
        osX.eulerAngles = new Vector3(90f, 0f, 0f);
        osY.eulerAngles = new Vector3(90f, 90f, 0f);
        osZ.eulerAngles = new Vector3(0f, 0f, 90f);
    }
    public void ResetCameraYZ()
    {
        ResetCamera(YZ);
        osX.eulerAngles = new Vector3(0f, 0f, 0f);
        osY.eulerAngles = new Vector3(0f, 90f, 0f);
        osZ.eulerAngles = new Vector3(0f, 90f, 90f);
    }

    void ResetCamera(Transform baza) {
        transform.position = baza.position;
        transform.rotation = baza.rotation;

    }


    
}

