using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class SliderToIinputField : MonoBehaviour {
    public InputField target;
    private Slider source;
	// Use this for initialization
	void Start () {
        source = transform.GetComponent<Slider>();
        Aktualizuj();
	}
	
	// Update is called once per frame
	public void Aktualizuj () {
        target.text = Math.Round(source.value,1).ToString();
    }

    public void Aktualizuj4digit()
    {
        target.text = Math.Round(source.value, 4).ToString("0.000");
    }

    public void AktualizujSkalaNieliniowa()
    {
        double inputValue = source.value;
        inputValue = Math.Round(Math.Pow(inputValue, 3f) * 8, 1);
        target.text = inputValue.ToString();
    }
}

