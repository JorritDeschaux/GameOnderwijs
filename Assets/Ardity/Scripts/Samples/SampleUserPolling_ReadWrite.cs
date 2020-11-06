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

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    public LevelManager levelManager;
    private GameObject cursor;
    private CursorScript cursorScript;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        cursorScript = cursor.GetComponent<CursorScript>();
    }

    // Executed each frame
    void Update()
    {
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
        else if (message == "1")
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                levelManager.LaadScene(2);
            }
        }
        else if (message == "2")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                levelManager.LaadVolgendeScene();
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

        }
        else if (message == "A")
        {
            cursor.transform.position = cursorScript.legeVakken[0].transform.position;
        }
        else if (message == "4")
        {
            Debug.Log("Key 4 pressed");
        }
        else if (message == "5")
        {
            Debug.Log("Key 5 pressed");
        }
        else if (message == "6")
        {
            Debug.Log("Key 6 pressed");
        }
        else if (message == "B")
        {
            cursor.transform.position = cursorScript.legeVakken[1].transform.position;
        }
        else if (message == "7")
        {
            Debug.Log("Key 7 pressed");
        }
        else if (message == "8")
        {
            Debug.Log("Key 8 pressed");
        }
        else if (message == "9")
        {
            Debug.Log("Key 9 pressed");
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
            Debug.Log("Key 0 pressed");
        }
        else if (message == "#")
        {
            Debug.Log("Key # pressed");
        }
        else if (message == "D")
        {
            cursor.transform.position = cursorScript.legeVakken[3].transform.position;
        }
    }
}
