using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class InputFToSlider : MonoBehaviour {
    public GameObject InputFld;
                                       // Use this for initialization
    void Start () {
        double inputValue = float.Parse(InputFld.GetComponent<InputField>().text);
        inputValue = Math.Round(inputValue, 1);
        this.GetComponent<Slider>().value = (float)inputValue;
	}
	
	// Update is called once per frame
	public void AktualizujText () {
        double inputValue = float.Parse(InputFld.GetComponent<InputField>().text);
        inputValue = Math.Round(inputValue, 1);
        this.GetComponent<Slider>().value = (float)inputValue;
    }
}
