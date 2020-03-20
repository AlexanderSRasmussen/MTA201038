using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMeasure : MonoBehaviour
{

    public GameObject object1;
    public GameObject object2;
    public float currentDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCalculator(object1, object2);
    }

    public void DistanceCalculator(GameObject object1, GameObject object2)
    {
        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        currentDistance = distance;
    }
}