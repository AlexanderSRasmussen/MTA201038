using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class IdeaScript : MonoBehaviour
{

    #region Variables
    public List<GameObject> nameList = new List<GameObject>();
    //public List<float> distances = new List<float>();

    //public Dictionary<GameObject, float> objDetected = new Dictionary<GameObject, float>();

    public bool cCollide = false;
    bool triggerCheck;
    string hit;
    public Button OnButton, OffButton;
    public GameObject cane, objHit, lastObjHit, closestObject;
    public float currentDistance, currentDistance2;
    //public string objColW;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjToCaneDist();
        if (cCollide == true)
        {
            //OnButton.onClick.Invoke();
        }
        else if (cCollide == false)
        {
            //OffButton.onClick.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        //ObjToCaneDist(cane, lastObjHit);
        if (other.CompareTag("Obstacle"))
        {
            //objHit = other.gameObject;
            //currentDistance = Vector3.Distance(cane.transform.position, other.transform.position);
            //objDetected.Add(objHit, currentDistance);
            nameList.Add(other.gameObject);
            //ObjToCaneDist(cane, lastObjHit);
            //currentDistance = Vector3.Distance(cane.transform.position, other.transform.position);
            //distances.Add(currentDistance);

            cCollide = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            nameList.Remove(other.gameObject);
            cCollide = false;
            //if (objDetected.ContainsKey(other.gameObject)){
            //objDetected.Remove(other.gameObject);
            //}

        }

        //objDetected.Remove(other.gameObject, currentDistance);
        
        //distances.Remove(currentDistance);
        //triggerCheck = false;
        //if (other.gameObject == objHit)
        //{
        //    cCollide = false;
        //    objHit = null;
        //    triggerCheck = false;
        //}

    }


        public void ObjToCaneDist()
        {
        //for (var i = 0; i < nameList.Count; i++)
        //{
        //    lastObjHit = nameList[i];
        //    currentDistance = Vector3.Distance(cane.transform.position, lastObjHit.transform.position);
        //    distances[i] = currentDistance;
        //    distances.Add(distances[i]);
        //    //distances.Add(distances[i]);
        //   //make a variable that gets set to the distance of given object and updates the varaibel, not adding to the list
        //}
        float lowest = float.MaxValue;
            foreach (GameObject o in nameList)
            {
                float temp = Vector3.Distance(transform.position, o.transform.position);
                if (temp < lowest)
                {
                currentDistance = temp;
                lowest = temp;
                closestObject = o;
                }
            }

            if (nameList.Count == 0)
            {
            currentDistance = 0f;
            closestObject = null;
            }
        }
}