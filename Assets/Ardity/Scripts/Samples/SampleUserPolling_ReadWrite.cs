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

    public string message;

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

        //string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else if (message == "1")
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                levelManager.LaadScene(2);
            }

            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "1";
                    break;
                case "breuk":
                    input.text += "1/";
                    break;
                default:
                    break;
            }
            
        }
        else if (message == "2")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                levelManager.LaadVolgendeScene();
            }

            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "2";
                    break;
                case "breuk":
                    input.text += "2/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "3")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                levelManager.SpelAfsluiten();
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                levelManager.LaadScene(0);
            }

            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "3";
                    break;
                case "breuk":
                    input.text += "3/";
                    break;
                default:
                    break;
            }

        }
        else if (message == "A")
        {
            cursor.transform.position = cursorScript.legeVakken[0].transform.position;
        }
        else if (message == "4")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "4";
                    break;
                case "breuk":
                    input.text += "4/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "5")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "5";
                    break;
                case "breuk":
                    input.text += "5/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "6")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "6";
                    break;
                case "breuk":
                    input.text += "6/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "B")
        {
            cursor.transform.position = cursorScript.legeVakken[1].transform.position;
        }
        else if (message == "7")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "7";
                    break;
                case "breuk":
                    input.text += "7/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "8")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "8";
                    break;
                case "breuk":
                    input.text += "8/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "9")
        {
            switch (kabel.soortSom)
            {
                case "normaal":
                    input.text = "9";
                    break;
                case "breuk":
                    input.text += "9/";
                    break;
                default:
                    break;
            }
        }
        else if (message == "C")
        {
            cursor.transform.position = cursorScript.legeVakken[2].transform.position;
        }
        else if (message == "*")
        {
            Debug.Log("Key * pressed");
        }
        else if (message == "0")
        {
            
        }
        else if (message == "#")
        {
            input.text = "";
        }
        else if (message == "D")
        {
            cursor.transform.position = cursorScript.legeVakken[3].transform.position;
        }
        else if (message == "L" || message == "R")
        {
            if (SceneManager.GetActiveScene().buildIndex >= 2)
            {
                cursorScript.CheckInput(message);
            }
            else
            {
                MenuScroll.current.Scroll(message);
            }
        }
        else if (message == "S")
        {
            if(SceneManager.GetActiveScene().buildIndex >= 2)
            {
                if (!cursorScript.alBezig)
                {
                    cursorScript.MaakKabel();
                }
            }
            else
            {
                MenuScroll.current.CheckInput();
            }
        }

        
    }
}
