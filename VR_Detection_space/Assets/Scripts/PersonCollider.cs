using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCollider : MonoBehaviour
{

    public string collidedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            collidedObject = other.gameObject.name;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            collidedObject = null;
        }
    }
}