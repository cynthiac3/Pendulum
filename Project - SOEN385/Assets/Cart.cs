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

    bool movingForce = false;

    Vector3 accelerationDir = new Vector3(1, 0, 0);
    Vector3 currentVelocity = new Vector3(1, 0, 0);

    GameObject pivot;
    GameObject pendulum;
    Rigidbody2D cartBody;

    Vector3 localposPendulum = new Vector3(-0.25f, -1.35f, -1);
    Vector3 localposPivot = new Vector3(-0.2399998f, -0.06000006f, -2.194935f);

    static float angleOfvalue = 20;
    float angleOfDisplacement= angleOfvalue;

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
        cartBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // We are NOT using this part because we couldn't implement the output function Y in this script
        if (false)
        {
            // Linear movement because of acceleration
            t += Time.deltaTime;
            currentVelocity += accelerationDir * (a(Y(t), t) * t);
            transform.position += currentVelocity * t;

        }
        else if (movingForce)
        {
            // Move the pendulum and pivot relative to the position of the cart
            pendulum.transform.position = transform.position + localposPendulum;
            pivot.transform.position = transform.position + localposPivot;
        }

        // limit pendulum movement 
        if (pendulum.transform.localRotation.z > 0.15)
        {
            angleOfDisplacement = -1 * angleOfvalue;
        }
        else if (pendulum.transform.localRotation.z < -0.15)
        {
            angleOfDisplacement = angleOfvalue;
        }

        // Pendulum movement
        pendulum.transform.RotateAround(pivot.transform.position, Vector3.forward, angleOfDisplacement * Time.deltaTime);

    }

    public void startMovement(float input_force) {
        t = 0;
        F = input_force;

        cartBody.AddForce(accelerationDir * F * 100);
        movingForce = true;
    }
}
