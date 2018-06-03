using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AktualizujUstawienia : MonoBehaviour {
    public GameObject Ramie1,Ramie2,Efektor;
    public GameObject slPredkosc;
    public GameObject tglPokazUkladWsp;
    public GameObject tglPokazSladRuchu;
    public GameObject CzasTrwaniaSladu;
    private obracaj skrypt;

    // Use this for initialization
    void Start () {
        skrypt = Ramie1.GetComponent<obracaj>();
        Aktualizuj();
    }
	
	// Update is called once per frame
	public void Aktualizuj () {
        skrypt.wspKompresjiCzasu = (float) (Math.Pow(slPredkosc.GetComponent<Slider>().value,3f))*8;
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time=float.Parse(this.CzasTrwaniaSladu.GetComponent<InputField>().text);
        StartCoroutine(ZgasSlad());
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().enabled = tglPokazSladRuchu.GetComponent<Toggle>().isOn;
    }

    IEnumerator ZgasSlad()
    {
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time = 0;
        yield return new WaitForSeconds(.001f);
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time = float.Parse(skrypt.czasSladu.GetComponent<Text>().text);
    }
}



