using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelAndBrake : MonoBehaviour
{
    public float accelForce = 2;
    public float brakeForce = 2;

    private float buttonHeldForSeconds;
    private bool buttonIsHeld;
    private Rigidbody rb;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        if (buttonIsHeld) {
            buttonHeldForSeconds = Time.time - startTime;
            accelerate();
        }
    }

    // gets called by unity's Event Trigger component
    public void buttonHeld() {
        startTime = Time.time;
        buttonIsHeld = true;
    }

    public void buttonReleased() {
        startTime = 0;
        buttonIsHeld = false;
    }

    void accelerate() {
        float speed = accelForce * buttonHeldForSeconds;
        Debug.Log("Speed: " + speed.ToString());
        rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
    }

    public void brake() {
        rb.AddForce(Vector3.forward * -brakeForce * Time.deltaTime);

    }

}
