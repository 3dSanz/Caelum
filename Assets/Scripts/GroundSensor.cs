using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    } 

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }

}
