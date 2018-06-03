using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBarUpdate : MonoBehaviour {
    public GameObject Ramie1;
    private obracaj sk;
	// Use this for initialization
	void Start () {
        sk = Ramie1.GetComponent<obracaj>();
        Update();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().maxValue = sk.maxCzas;
        GetComponent<Slider>().value = sk.aktCzas;
        transform.Find("TextISOCP").GetComponent<Text>().text = sk.aktCzas.ToString("0.0000") + " [s]\n" +
            sk.aktLicznik;
    }

    public void ZerujProgressBar() {
        transform.GetComponent<Slider>().value = 0;
    }
}
