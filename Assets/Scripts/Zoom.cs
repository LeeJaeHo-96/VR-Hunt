using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Zoom : MonoBehaviour
{

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * -10, Color.red);
        if (Physics.Raycast(transform.position, -transform.forward, out hit))
        { 
            Debug.Log(hit.collider.name);
        } 
    }
}
