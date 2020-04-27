using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVWrite : MonoBehaviour
{
    #region Variables

    public GameObject cane, person, obstHit;
    private List<string[]> rowData = new List<string[]>();
    public int participantID, testID;
    float distToObject, wcX, wcY, wcO, pX, pY, pO, objX, objY;
    public float detectDist;
    string time;
    public string fov;
    public bool objectHit;
    string[] rowDataTemp = new string[15];


    #endregion
    // Use this for initialization
    void Start()
    {
        //Save();

        // Creating First row of titles manually..
        rowDataTemp[0]  = "Participant ID";
        rowDataTemp[1]  = "Test ID";
        rowDataTemp[2]  = "Detection range in meters";
        rowDataTemp[3]  = "FOV";
        rowDataTemp[4]  = "Whitecane pos X";
        rowDataTemp[5]  = "Whitecane pos Y";
        rowDataTemp[6]  = "Whitecane orientation";
        rowDataTemp[7]  = "Person pos X";
        rowDataTemp[8]  = "Person pos Y";
        rowDataTemp[9]  = "Person orientation";
        rowDataTemp[10] = "Object hit";
        rowDataTemp[11] = "Object pos X";
        rowDataTemp[12] = "Object pos Y";
        rowDataTemp[13] = "Distance to object";
        rowDataTemp[14] = "Time stamp";
        rowData.Add(rowDataTemp);
    }

    void Update()
    {
        Save();
        GetCoordinates();
        GetObjectHit();
    }
    
    void Save()
    {
        
        // You can add up the values in as many cells as you want. However, this limits your dataset's rows to the amount of iterations.
        //for (int i = 0; i < 100; i++)
        //{
        //-----Formatting Starts-----//
        rowDataTemp = new string[15];
            rowDataTemp[0]  = participantID.ToString();       // name                      %DONE
            rowDataTemp[1]  = testID.ToString();              // ID                        %DONE
            rowDataTemp[2]  = detectDist.ToString();          //Detection range in meters  %DONE
            rowDataTemp[3]  = fov;                            //FOV                        %DONE
            rowDataTemp[4]  = wcX.ToString();                 //Whitecane pos X            %DONE
            rowDataTemp[5]  = wcY.ToString();                 //Whitecane pos Y            %DONE
            rowDataTemp[6]  = wcO.ToString();                 //Whitecane orientation      %DONE
            rowDataTemp[7]  = pX.ToString();                  //Person pos X               %DONE
            rowDataTemp[8]  = pY.ToString();                  //Person pos Y               %DONE
            rowDataTemp[9]  = pO.ToString();                  //Person orientation         %DONE
            rowDataTemp[10] = objectHit.ToString();           //Object hit checker         %DONE
            rowDataTemp[11] = objX.ToString();                //Object pos X               %DONE
            rowDataTemp[12] = objY.ToString();                //Object pos Y               %DONE
            rowDataTemp[13] = distToObject.ToString("0.000"); //Distance to the object hit %DONE
            rowDataTemp[14] = time = GetTimeStamp();          //Time                       %DONE

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

        objectHit = wholeRoomClass.cCollide;
        distToObject = wholeRoomClass.currentDistance;

        obstHit = wholeRoomClass.closestObject;
        obstHit.transform.position = new Vector3(obstHit.transform.position.x, obstHit.transform.position.y, obstHit.transform.position.z);
        objX = obstHit.transform.position.x;
        objY = obstHit.transform.position.z;


        //objX = new Vector3(objDetectedName.transform.position.x, objDetectedName.transform.position.y, objDetectedName.transform.position.z);
        //objX = wholeRoomClass.gameObject.transform.position.x;
        //objY = wholeRoomClass.gameObject.transform.position.z;
        //cane.transform.position = new Vector3(cane.transform.position.x, cane.transform.position.y, cane.transform.position.z);

        //distToObject = WholeRoomDetection.currentDistance;
        //Debug.Log(distToObject + " " + wholeRoomClass.gameObject.name);
    }
#endregion
}