using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetujSlad : MonoBehaviour {
    public TrailRenderer Slad;
    private float czastemp;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	public void Resetuj () {
            czastemp = Slad.time;
            Slad.time = 0;
            StartCoroutine(czekaj());
        }

    IEnumerator czekaj() {
        yield return new WaitForEndOfFrame();
        Slad.time = czastemp;
       // (.5f * Time.unscaledDeltaTime);
    }
}
