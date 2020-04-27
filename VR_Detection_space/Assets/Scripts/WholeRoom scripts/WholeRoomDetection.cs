using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeRoomDetection : MonoBehaviour
{

    #region Variables
    public List<GameObject> nameList = new List<GameObject>();
    public bool cCollide = false;
    bool triggerCheck;
    string hit;
    public Button OnButton, OffButton;
    public GameObject closestObject;
    public float currentDistance;
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
        if (other.CompareTag("Obstacle"))
        {
            nameList.Add(other.gameObject);
            cCollide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            nameList.Remove(other.gameObject);
            cCollide = false;
        }
    }

    public void ObjToCaneDist()
    {
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