using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObracajRamie : MonoBehaviour {
    public Slider SliderTh1, SliderTh2, SliderTh3;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame

    public void obrocTh1zSlider()
    {
        float xxx = transform.localEulerAngles.x;
        float katObrotu = SliderTh1.value;
        float zzz = transform.localEulerAngles.z;
        transform.localEulerAngles = new Vector3(xxx, katObrotu, zzz);
    }
    
    public void ObrotTh2zSlider()
    {
        float xxx = transform.localEulerAngles.x;
        float yyy = transform.localEulerAngles.y;
        float katObrotu = SliderTh2.value;
        transform.localEulerAngles = new Vector3(xxx, yyy, katObrotu);
    }

    public void ObrotTh3zSlider()
    {
        float xxx = transform.localEulerAngles.x;
        float yyy = transform.localEulerAngles.y;
        float katObrotu = SliderTh3.value;
        transform.localEulerAngles = new Vector3(xxx, yyy, katObrotu);
    }


}
