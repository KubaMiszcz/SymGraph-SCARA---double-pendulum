using UnityEngine;
using System.Collections;

public class testForce : MonoBehaviour {
    public float thrusty;
    public float thrustx;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.up * thrusty);
        rb.AddForce(transform.right * thrustx);
    }

}


