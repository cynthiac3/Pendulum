using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    // for linear displacement
    float M = 124; // mass of load
    float m = 20; // mass of cart
    float g = 10f; // gravitational force
    float F; // input force

    float acceleration;

    bool moving = false;

    Vector3 accelerationDir = new Vector3(1, 0, 0);
    Vector3 currentVelocity = new Vector3(1, 0, 0);

    GameObject pivot;
    GameObject pendulum;

    float t = 0;

    // Linear displacement function
    float x(float angle, float t) {
        return (((M * g * angle) + F) / (2 * m)) * (t * t);
    }

    // Acceleration of cart function
    float a(float angle, float t) {
        return ((M * g * angle) / m) + (F / m);
    }

    // Output function from control system
    float Y(float t) {
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.Find("Pivot").gameObject;
        pendulum = transform.Find("Pendulum").gameObject;
        pendulum.GetComponent<Pendulum>().setPivot(pivot);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            // Linear movement because of acceleration
            t += Time.deltaTime;
            currentVelocity += accelerationDir * (a(Y(t), t) * t);
            transform.position += currentVelocity * t;

            // Pendulum movement
            pendulum.transform.RotateAround(pivot.transform.position, Vector3.forward, Y(t) * Time.deltaTime);
        }
    }

    public void setAngularValue(float newValue) {
        transform.GetChild(0).GetComponent<Pendulum>().velocityThreshold = newValue;
    }

    public void startMovement(float input_force) {
        t = 0;
        F = input_force;
        moving = true;
    }
}
