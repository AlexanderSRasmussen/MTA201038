using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonCorridor : MonoBehaviour
{
#region Variables
    public List<GameObject> nameList = new List<GameObject>();
    public bool cCollide = false;
    bool triggerCheck;
    string hit;
    public Button OnButton, OffButton;
    public GameObject closestObject, closestPersonObject;
    public float currentDistance;
#endregion
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
                closestPersonObject = o;
            }
        }

        if (nameList.Count == 0)
        {
            currentDistance = 0f;
            closestPersonObject = null;
        }
    }

    #region GetCaneCollision
    void GetCaneCollision()
    {
        var caneCollisionClass = FindObjectOfType<CaneCorridor>();

        if (caneCollisionClass.closestCaneObject == closestPersonObject)
        {
            closestObject = closestPersonObject;
            OnButton.onClick.Invoke();
        }
        else
        {
            closestObject = null;
            OffButton.onClick.Invoke();
        }
    }
    #endregion
}