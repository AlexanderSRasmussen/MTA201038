using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCorridor : MonoBehaviour
{

    public bool collide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OnCollisionEnter();
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                Debug.Log("Do something else here");
                collide = true;
                break;
        }

    }
}
