using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeasurement : MonoBehaviour
{
    public GameObject person;
    public float vel;
    Vector3 velocity, lastPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lastPos = person.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lastMove = transform.position - lastPos;
        lastMove /= Time.deltaTime;
        vel = lastMove.magnitude;
        lastPos = transform.position;

    }

}