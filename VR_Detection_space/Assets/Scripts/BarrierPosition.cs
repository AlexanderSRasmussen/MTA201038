using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPosition : MonoBehaviour
{
    public GameObject controller;
    public GameObject barrier;
    private Quaternion rotate = Quaternion.Euler(0.0f, 90.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barrier.transform.position = new Vector3(controller.transform.position.x, 0.8f, controller.transform.position.z);
        
        barrier.transform.localEulerAngles = new Vector3(0.0f, controller.transform.localEulerAngles.y, 0.0f);
    }
}
