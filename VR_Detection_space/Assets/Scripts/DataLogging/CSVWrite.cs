using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.Threading;
using System.Diagnostics;
using UnityEngine.UI;

public class CSVWrite : MonoBehaviour
{
    #region Variables
    public bool logStarter = false;
    public GameObject cane, person, obstHit;
    private List<string[]> rowData = new List<string[]>();
    //public int participantID, testID, scenario;
    float distToObject, wcX, wcY, wcO, pX, pY, pO, objX, objY, pSpeed;
    //public float detectDist;
    string time;
    public string participantID, testID, fod, detectDist, scenario, objectDetected, objectCollide;
    //public bool objectDetected, objectCollide;
    public Stopwatch timer = new Stopwatch();
    Vector3 obstHitPosition = new Vector3(0,0,0);
    string[] rowDataTemp = new string[19];
    
    #endregion

    // Use this for initialization
    void Start()
    {
        //Save();

        // Creating First row of titles manually..
        rowDataTemp[0]  = "Participant ID";
        rowDataTemp[1]  = "Test ID";
        rowDataTemp[2]  = "Detection range in meters";
        rowDataTemp[3]  = "FOD";
        rowDataTemp[4]  = "Scenario";
        rowDataTemp[5]  = "Whitecane pos X";
        rowDataTemp[6]  = "Whitecane pos Y";
        rowDataTemp[7]  = "Whitecane orientation";
        rowDataTemp[8]  = "Object detected";
        rowDataTemp[9]  = "Distance to object";
        rowDataTemp[10] = "Person pos X";
        rowDataTemp[11] = "Person pos Y";
        rowDataTemp[12] = "Person orientation";
        rowDataTemp[13] = "Person Speed";
        rowDataTemp[14] = "Object collision";
        rowDataTemp[15] = "Object pos X";
        rowDataTemp[16] = "Object pos Y";
        
        rowDataTemp[17] = "Time stamp";
        rowDataTemp[18] = "Timer";
        rowData.Add(rowDataTemp);

        timer.Start();
    }

    void Update()
    {
        if (logStarter == true)
        {
            Save();
            GetCoordinates();
            GetObjectHit();
        } 
    }
    
    void Save()
    {
        
        // You can add up the values in as many cells as you want. However, this limits your dataset's rows to the amount of iterations.
        //for (int i = 0; i < 100; i++)
        //{
        //-----Formatting Starts-----//
        rowDataTemp = new string[19];
            rowDataTemp[0]  = participantID;                  //name                       %DONE
            rowDataTemp[1]  = testID;                         //ID                         %DONE
            rowDataTemp[2]  = detectDist;                     //Detection range in meters  %DONE
            rowDataTemp[3]  = fod;                            //Field of Detection         %DONE
            rowDataTemp[4]  = scenario;                       //Scenario                   %DONE
            rowDataTemp[5]  = wcX.ToString();                 //Whitecane pos X            %DONE
            rowDataTemp[6]  = wcY.ToString();                 //Whitecane pos Y            %DONE
            rowDataTemp[7]  = wcO.ToString();                 //Whitecane orientation      %DONE
            rowDataTemp[8]  = objectDetected.ToString();      //Object Detection checker   %DONE    
            rowDataTemp[9]  = distToObject.ToString("0.000"); //Distance to the object hit %DONE                     
            rowDataTemp[10] = pX.ToString();                  //Person pos X               %DONE
            rowDataTemp[11] = pY.ToString();                  //Person pos Y               %DONE
            rowDataTemp[12] = pO.ToString();                  //Person orientation         %DONE
            rowDataTemp[13] = pSpeed.ToString();              //Person Speed               %Done
            rowDataTemp[14] = objectCollide.ToString();       //Object Collision           %DONE
            rowDataTemp[15] = objX.ToString();                //Object pos X               %DONE
            rowDataTemp[16] = objY.ToString();                //Object pos Y               %DONE
            
            rowDataTemp[17] = time = GetTimeStamp();          //Time                       %DONE
            rowDataTemp[18] = timer.Elapsed.ToString();       //Timer

            rowData.Add(rowDataTemp);
       // }

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ";";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        //-----Formatting ends-----//

        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        
        outStream.WriteLine(sb);
        outStream.Close();
    }

    public void StartLogging()
    {
        logStarter = true;
    }
#region GetFunctions
    private string getPath()
    {
        return "C:/Users/Alexander Rasmussen/Documents/GitHub/MTA201038/VR_Detection_space/Assets/Logfiles/test.csv";
        //***Add me when you are testing*** return "C:/Users/Alexander Rasmussen/Documents/GitHub/MTA201038/VR_Detection_space/Assets/Logfiles/test.csv" + "_ParticipantID " + participantID + "_TestID " + testID;
        //return "C:/Dokumenter/Desktop" + "/CSV/" + "Saved_data.csv";
    }

    static string GetTimeStamp()
    {
        return System.DateTime.UtcNow.ToString();
    }

    void GetCoordinates()
    {
        cane.transform.position = new Vector3(cane.transform.position.x, cane.transform.position.y, cane.transform.position.z);
        wcX = cane.transform.position.x;
        wcY = cane.transform.position.z;

        cane.transform.localEulerAngles = new Vector3(cane.transform.localEulerAngles.x, cane.transform.localEulerAngles.y, cane.transform.localEulerAngles.z);
        wcO = cane.transform.localEulerAngles.y;


        person.transform.position = new Vector3(person.transform.position.x, person.transform.position.y, person.transform.position.z);

        pX = person.transform.position.x;
        pY = person.transform.position.z;

        person.transform.localEulerAngles = new Vector3(person.transform.localEulerAngles.x, person.transform.localEulerAngles.y, person.transform.localEulerAngles.z);
        pO = person.transform.localEulerAngles.y;
    }

    void GetObjectHit()
    {
        var wholeRoomClass = FindObjectOfType<WholeRoomDetection>();
        var personColliderClass = FindObjectOfType<PersonCollider>();

        if (wholeRoomClass.closestObject == null)
        {
            objectDetected = "null";

        } else
        {
            objectDetected = wholeRoomClass.closestObject.name;
            obstHitPosition = wholeRoomClass.closestObject.transform.position;
            objX = obstHitPosition.x;
            objY = obstHitPosition.y;
        }

        distToObject = wholeRoomClass.currentDistance;

        //obstHit = wholeRoomClass.closestObject;

        //obstHit.transform.position = new Vector3(obstHit.transform.position.x, obstHit.transform.position.y, obstHit.transform.position.z);
        //objX = obstHit.transform.position.x;
        //objY = obstHit.transform.position.z;

        objectCollide =  personColliderClass.collidedObject;

        //objX = new Vector3(objDetectedName.transform.position.x, objDetectedName.transform.position.y, objDetectedName.transform.position.z);
        //objX = wholeRoomClass.gameObject.transform.position.x;
        //objY = wholeRoomClass.gameObject.transform.position.z;
        //cane.transform.position = new Vector3(cane.transform.position.x, cane.transform.position.y, cane.transform.position.z);

        //distToObject = WholeRoomDetection.currentDistance;
        //Debug.Log(distToObject + " " + wholeRoomClass.gameObject.name);
    }

    void GetSpeed()
    {
        var Speed = FindObjectOfType<SpeedMeasurement>();

        pSpeed = Speed.vel;
    }
#endregion
}