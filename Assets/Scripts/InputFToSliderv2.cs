using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class InputFToSliderv2 : MonoBehaviour
{
    public Slider target;
    private InputField source;
    // Use this for initialization
    void Start()
    {
        source = transform.GetComponent<InputField>();
    }

    // Update is called once per frame
    public void Aktualizuj()
    {
        target.value = float.Parse(source.text);
    }
}

