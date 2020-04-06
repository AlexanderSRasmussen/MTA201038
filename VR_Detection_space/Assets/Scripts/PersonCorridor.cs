using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCorridor : MonoBehaviour
{

    public bool pCollide, cCollide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pCollide && cCollide == true)
        {
            Debug.Log("It wörks");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Person"))
        {
            pCollide = true;
        }

        if (other.CompareTag("Cane"))
        {
            cCollide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Person"))
        {
            pCollide = false;
        }

        if (other.CompareTag("Cane"))
        {
            cCollide = false;
        }
    }

        //switch (other.tag)
        //{
        //    case "Person":
        //        ///Debug.Log("Do something else here");
        //        pCollide = true;
        //        break;

        //    case "Cane":
        //        //Debug.Log("Floating object hit");
        //        cCollide = true;
        //        break;
        //}
}