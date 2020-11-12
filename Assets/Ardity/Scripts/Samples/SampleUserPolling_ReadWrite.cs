/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using System;
using UnityEngine.UI;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    public LevelManager levelManager;
    private GameObject cursor;
    private CursorScript cursorScript;

    private InputField input;
    private Kabel kabel;

    //public string message;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        cursorScript = CursorScript.current;
    }

    void Update()
    {
        if (cursorScript != null)
        {
            if (cursorScript.alBezig)
            {
                input = FindObjectOfType<InputField>();
                kabel = GameObject.FindGameObjectWithTag("Kabel").GetComponent<Kabel>();
            }
        }
        
        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else if (message == "1" || message == "2" || message == "3" || message == "4" || message == "5" || message == "6" || message == "7" || message == "8" || message == "9")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = message;
                    break;
                case "breuk":
                    input.text += message + "/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "*")
        {
            SceneManager.LoadScene(0);
        }
        else if (message == "#")
        {
            input.text = "";
        }
        else if (message == "L" || message == "R")
        {
            if (SceneManager.GetActiveScene().buildIndex >= 2)
            {
                if(CursorScript.current.alBezig) { return; }
                cursorScript.CheckInput(message);
            }
            else
            {
                MenuScroll.current.Scroll(message);
            }
        }
        else if (message == "S")
        {
            if (SceneManager.GetActiveScene().buildIndex >= 2)
            {
                if (!cursorScript.alBezig)
                {
                    cursorScript.MaakKabel();
                }
                else
                {
                    kabel.CheckAntwoord();
                }
            }
            else
            {
                MenuScroll.current.CheckInput();
            }
        }

        
    }
}
