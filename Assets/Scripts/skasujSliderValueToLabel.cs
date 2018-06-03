using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SliderValueToLabel : MonoBehaviour {
    public GameObject Slider;

                                       // Use this for initialization
    void Start () {
        double inputValue = Slider.GetComponent<Slider>().value;
        inputValue = Math.Round(inputValue, 1);
        this.GetComponent<InputField>().text = inputValue.ToString();
	}
	
	// Update is called once per frame
	public void AktualizujText () {
        double inputValue = Slider.GetComponent<Slider>().value;
        inputValue = Math.Round(inputValue, 1);
        this.GetComponent<InputField>().text = inputValue.ToString();
    }
    public void AktualizujTextSkalaNieliniowa()
    {
        double inputValue = Slider.GetComponent<Slider>().value;
        inputValue = Math.Round(Math.Pow(inputValue,3f)*8, 1);
        this.GetComponent<InputField>().text = inputValue.ToString();
    }
}
