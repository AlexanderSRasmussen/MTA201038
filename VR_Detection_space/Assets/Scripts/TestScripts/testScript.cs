using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    public bool cCollide = false;
    public Button OnButton, OffButton;

    public int maxCollisions = 12;
    Collider[] collisions;
    public GameObject cane;
    GameObject closestObject;
    //LayerMask mask = ~LayerMask.GetMask("cane");
    LayerMask mask;
    public float closestDistance;
    Vector3 canePos, caneRotation;

    // Start is called before the first frame update
    void Start()
    {
        collisions = new Collider[maxCollisions];
        mask = ~LayerMask.GetMask("cane");
    }

    // Update is called once per frame
    void Update()
    {
        
        canePos = cane.transform.position = new Vector3(cane.transform.position.x, cane.transform.position.y, cane.transform.position.z);
        caneRotation = transform.localEulerAngles = new Vector3(0.0f, transform.localEulerAngles.y, 0.0f);
        if (cCollide == true)
        {
        
        }
        else if (cCollide == false)
        {
        
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Obstacle"))
        {
            FindClosest(out closestDistance);
            //cCollide = true;
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Obstacle"))
        {
            FindClosest(out closestDistance);
            //cCollide = false;
        }
       
    }

    void FindClosest(out float distance)
    {
        Vector3 offset = new Vector3(0.0f - 0.5f, 0.0f, 0.0f);
        distance = float.MaxValue;
        float lowest;
        //Collider col;
        //if (Physics.OverlapBoxNonAlloc(canePos + (transform.position/2), (canePos/2), collisions, transform.rotation) > 0)
        if (Physics.OverlapBoxNonAlloc(transform.position + offset, new Vector3(1, 1.6f, 0.03f), collisions, transform.rotation, mask) > 0)
        {
            lowest = float.MaxValue;

            //foreach (var col in arr)
            for (int i = 0; i < collisions.Length; i++)
            {

                //Collider col = collisions[i];
               
                
                if (collisions[i] != null && null != collisions[i].transform){
                    
                    float temp = Vector3.Distance(transform.position, collisions[i].transform.position);
                   
                    if (temp < lowest)
                    {
                        
                        lowest = temp;
                        
                        closestObject = collisions[i].gameObject;
                        
                        distance = lowest;

                    }
                }
                

            }
            Debug.Log(closestObject.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 offset = new Vector3(0.0f - 0.5f, 0.0f, 0.0f);
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawCube(transform.position + offset, new Vector3(1, 1.6f, 0.03f));
        // Gizmos.DrawCube(canePos + transform.position/2, canePos);
    }
}