using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkalujRamiev2 : MonoBehaviour {
    public InputField input;
    public GameObject KolejnySegment;
    private float wspSkali;
    private Vector3 skala;
	// Use this for initialization
	void Start () {
        wspSkali = float.Parse(input.GetComponent<InputField>().text);
        skala = transform.Find("Beam").localScale;
	}
	
	// Update is called once per frame
	public void Skaluj () {
        wspSkali = float.Parse(input.GetComponent<InputField>().text);
        transform.Find("Beam").localScale = new Vector3(skala.x, skala.y * (wspSkali / 5), skala.z);
        Vector3 newpos = transform.Find("Beam").transform.Find("Koniec").transform.position;
        KolejnySegment.transform.position =  newpos;
    }

}
