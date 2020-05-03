using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPosition : MonoBehaviour
{
    public GameObject controller, barrier;
    BoxCollider caneBarrier;
    float c_ScaleX = 1.0f;
    public float barrierLength;
    float c_ScaleZ = 1.0f;
    private Quaternion rotate = Quaternion.Euler(0.0f, 90.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        caneBarrier = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        barrier.transform.position = new Vector3(controller.transform.position.x, 0.8f, controller.transform.position.z);
        
        barrier.transform.localEulerAngles = new Vector3(-90f, controller.transform.localEulerAngles.y, controller.transform.localEulerAngles.z);

        caneBarrier.size = new Vector3(c_ScaleX, barrierLength, c_ScaleZ);
        caneBarrier.center = new Vector3(0.0f , barrierLength / 2, 0.0f);
    }
}
