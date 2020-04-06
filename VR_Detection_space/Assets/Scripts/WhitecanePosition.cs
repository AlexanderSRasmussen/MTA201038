using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------- This is a fluff script ----------//

public class WhitecanePosition : MonoBehaviour
{
    public GameObject controller;
    public GameObject whitecane;
    //private Vector3 offset = new Vector3 (0.0f, -0.082f, 0.25f);
    private Quaternion rotate = Quaternion.Euler (-95,0,0);

    // Start is called before the first frame update
    void Start()
    {
        //controllerPos = 
    }

    // Update is called once per frame
    void Update()
    {
        whitecane.transform.position = controller.transform.position;
        whitecane.transform.rotation = controller.transform.rotation * rotate;
       
    }
}
