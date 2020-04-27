using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArduinoTestScripts : MonoBehaviour
{
    public Button OnButton, OffButton;
    public bool collide = false;
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
            OnButton.onClick.Invoke();
            //collide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            OffButton.onClick.Invoke();
            //collide = false;
        }
    }
}
