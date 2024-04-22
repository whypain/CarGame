using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelAndBrake : MonoBehaviour
{
    public float accelForce = 2;
    public float brakeForce = 2;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void accelerate() {
        rb.velocity = new Vector3(0, 0, accelForce);
    }

    public void brake() {
        rb.velocity = new Vector3(0, 0, -brakeForce);
    }

    public void wtf() {
        Debug.Log("W");
    }

}
