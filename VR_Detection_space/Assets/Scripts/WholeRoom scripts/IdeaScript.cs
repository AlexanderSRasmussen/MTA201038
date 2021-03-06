﻿using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class IdeaScript : MonoBehaviour
{

    #region Variables
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
        DistanceCalculator(cane, objHit);
        DistanceCalculator2(cane, lastObjHit);
        //Debug.Log(objHit);
        if (cCollide == true)
        {
            OnButton.onClick.Invoke();
        }
        else if (cCollide == false)
        {
            OffButton.onClick.Invoke();
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject holder;
        //Just check if a newly entered gameobjet is closer - if not, stay at the same objHit


        if (other.CompareTag("Obstacle"))
        {
            cCollide = true;
            objHit = other.gameObject;

            //objHit = GameObject.Find(other.gameObject.name);
            if (!triggerCheck)
            {
                lastObjHit = objHit;
                triggerCheck = true;
            }

            if (currentDistance < currentDistance2)
            {
                holder = objHit;
                objHit = lastObjHit;
                lastObjHit = holder;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //triggerCheck = false;
        if (other.gameObject == objHit)
        {
            cCollide = false;
            objHit = null;
            triggerCheck = false;
            currentDistance = 0f;
            currentDistance2 = 0f;
        }

    }

    void DistanceCalculator(GameObject cane, GameObject objHit)
    {
        currentDistance = Vector3.Distance(cane.transform.position, objHit.transform.position);
        //return currentDistance;
    }

    void DistanceCalculator2(GameObject cane, GameObject lastObjHit)
    {
        currentDistance2 = Vector3.Distance(cane.transform.position, lastObjHit.transform.position);
        //return currentDistance;
    }

    //Old distancechecker
    //for (var i = 0; i < nameList.Count; i++)
    //{
    //    lastObjHit = nameList[i];
    //    currentDistance = Vector3.Distance(cane.transform.position, lastObjHit.transform.position);
    //    distances[i] = currentDistance;
    //    distances.Add(distances[i]);
    //}
}