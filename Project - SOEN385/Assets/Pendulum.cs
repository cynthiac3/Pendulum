using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;

    // to use next
    public float angleOfDisplacement;


    public GameObject pivot;

    bool moving = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {
            //transform.RotateAround(pivot.transform.position, Vector3.forward, 20 * Time.deltaTime);
        }
        
    }

    public void setPivot(GameObject p) {
        pivot = p;
        moving = true;
    }
}
