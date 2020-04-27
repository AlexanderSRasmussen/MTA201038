using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaneCorridor : MonoBehaviour
{
    #region Variables
    public List<GameObject> nameListCane = new List<GameObject>();
    public GameObject closestCaneObject;
    public float currentCaneDistance;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjToCaneDist();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            nameListCane.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            nameListCane.Remove(other.gameObject);
        }
    }

    public void ObjToCaneDist()
    {
        float lowest = float.MaxValue;
        foreach (GameObject o in nameListCane)
        {
            float temp = Vector3.Distance(transform.position, o.transform.position);
            if (temp < lowest)
            {
                currentCaneDistance = temp;
                lowest = temp;
                closestCaneObject = o;
            }
        }

        if (nameListCane.Count == 0)
        {
            currentCaneDistance = 0f;
            closestCaneObject = null;
        }
    }
}