using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeRoomDetection : MonoBehaviour
{
    public bool cCollide = false;
    string hit;
    public Button OnButton;
    public Button OffButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Signal();

        if (cCollide == true)
        {
            //Debug.Log("It wörks");
            //hit = "1";
            //Sending.HitRegistered();
            OnButton.onClick.Invoke();
            //Signal();
        }
        else if (cCollide == false)
        {
            OffButton.onClick.Invoke();
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

        if (other.CompareTag("Cane"))
        {
            cCollide = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Cane"))
        {
            cCollide = false;
        }
    }

    IEnumerator Signal()
    {
        Sending.HitRegistered();
        yield return new WaitForSeconds(2);
    }

}
