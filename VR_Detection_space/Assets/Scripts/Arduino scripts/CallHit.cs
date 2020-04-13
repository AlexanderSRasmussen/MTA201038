using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHit : MonoBehaviour
{
    public bool collide = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                Debug.Log("Hit");
                collide = true;
                Sending.HitRegistered();
                break;

            case "Floating":
                Debug.Log("Floating object hit");
                break;
        }  
    }

    /*void OnMouseDown()
    {
        print("Object Hit!");
        Sending.HitRegistered();
    }*/
}