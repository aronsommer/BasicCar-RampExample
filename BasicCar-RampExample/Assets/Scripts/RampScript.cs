using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampScript : MonoBehaviour
{
    public GameObject Car;
    private bool forwardForce;

    void Start()
    {
        forwardForce = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarCollider")
        {
            Debug.Log("Player has entered ramp");
            forwardForce = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CarCollider")
        {
            Debug.Log("Player has exited ramp");
            forwardForce = false;
        }
    }

    void FixedUpdate()
    {
        if (forwardForce)
        {
            // Boost forward
            Car.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 20000);
        }
        if (!forwardForce)
        {
            // Lock x rotation of car
            Car.transform.eulerAngles = new Vector3(0, Car.transform.eulerAngles.y, Car.transform.eulerAngles.z);
        }
    }
}
