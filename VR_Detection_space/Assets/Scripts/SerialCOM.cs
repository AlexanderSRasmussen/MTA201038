using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO.Ports;

public class SerialCOM : MonoBehaviour
{
    #region parameters
    //declare variables
    //port name
    public string port = "COM7";
    //port speed in bps
    public int boardrate;

    //declare the serial port
    private SerialPort sp;

    //boolean variable for reading values
    bool isStreaming = false;

    public GameObject btn;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStreaming)
        {
            string value = ReadSerialPort();
            if (value != null && float.Parse(value) >= 1.0f)
            {
                Debug.Log(value);
            }
        }
    }


    public void Open()
    {
        isStreaming = true;

        sp = new SerialPort(port, boardrate);
        sp.ReadTimeout = 100;
        sp.Open();
        Debug.Log("port Opened!");
    }

    public string ReadSerialPort(int timeout = 50)
    {
        string message;

        sp.ReadTimeout = timeout;
        //we will try to read values from our serial port
        try
        {
            message = sp.ReadLine();
            return message;
        }
        catch (TimeoutException)
        {
            return null;
        }

    }

    public void Close()
    {

        sp.Close(); //closes the serial port
    }

    public void HitRegistered()
    {
        sp.Write("1");

    }

    public void NullRegistered()
    {
        sp.Write("0");

    }

}
