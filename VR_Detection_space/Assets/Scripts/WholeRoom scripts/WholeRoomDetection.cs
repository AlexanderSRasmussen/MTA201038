using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeRoomDetection : MonoBehaviour
{
    public bool cCollide = false;
    string hit;
    public Button OnButton, OffButton;
    public GameObject cane, object1, objHit;
    public float currentDistance;
    //public string objColW;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (cCollide == true)
        {
            DistanceCalculator(object1, cane);
            //hit = "1";
            //Sending.HitRegistered();
            OnButton.onClick.Invoke();
            //CSVWrite.objectHit = cCollide;
        }
        else if (cCollide == false)
        {
            OffButton.onClick.Invoke();
            //CSVWrite.objectHit = cCollide;
            //hit = "0";
            //Sending.NullRegistered();
        }
        

        //switch (hit)
        //{
        //    case "1":
        //        Sending.HitRegistered();
        //        break;

        //    case "0":
        //        break;
        //}
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Obstacle"))
        {
            cCollide = true;
            //objColW = other.gameObject.name;
            objHit = GameObject.Find(other.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Obstacle"))
        {
            cCollide = false;
            //objColW = null;
            objHit = null;
        }
    }

    public float DistanceCalculator(GameObject cane, GameObject object1)
    {
        currentDistance = Vector3.Distance(cane.transform.position, object1.transform.position);
        return currentDistance;
    }

}