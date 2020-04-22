using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdeaScript : MonoBehaviour
{

    #region Variables
    public List<GameObject> nameList = new List<GameObject>();
    public List<float> distances = new List<float>();
    public bool cCollide = false;
    bool triggerCheck;
    string hit;
    public Button OnButton, OffButton;
    public GameObject cane, objHit, lastObjHit;
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
        
        //DistanceCalculator(cane, objHit);
        //DistanceCalculator2(cane, lastObjHit);
        if (cCollide = true)
        {
            //OnButton.onClick.Invoke();
        }
        else if (cCollide = false)
        {
            //OffButton.onClick.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        //ObjToCaneDist(cane, lastObjHit);
        if (other.CompareTag("Obstacle"))
        {
            nameList.Add(other.gameObject);
            ObjToCaneDist(cane, lastObjHit);
            //currentDistance = Vector3.Distance(cane.transform.position, other.transform.position);
            //distances.Add(currentDistance);
            cCollide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        nameList.Remove(other.gameObject);
        distances.Remove(currentDistance);
        //triggerCheck = false;
        if (other.gameObject == objHit)
        {
            cCollide = false;
            objHit = null;
            triggerCheck = false;
            //currentDistance = 0f;
            //currentDistance2 = 0f;
        }
    }

    //void DistanceCalculator(GameObject cane, GameObject objHit)
    //{
    //    currentDistance = Vector3.Distance(cane.transform.position, objHit.transform.position);
    //    //return currentDistance;
    //}

    //void DistanceCalculator2(GameObject cane, GameObject lastObjHit)
    //{
    //    currentDistance2 = Vector3.Distance(cane.transform.position, lastObjHit.transform.position);
    //    //return currentDistance;
    //}

    public void ObjToCaneDist(GameObject cane, GameObject lastObjHit)
    {
        
        for (var i = 0; i < nameList.Count; i++)
       {
            lastObjHit = nameList[i];
            currentDistance = Vector3.Distance(cane.transform.position, lastObjHit.transform.position);
            distances.Add(currentDistance);
       }
    }
}