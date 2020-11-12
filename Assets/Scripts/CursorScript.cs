using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public List<GameObject> legeVakken = new List<GameObject>();

    public int huidigVak;
    public GameObject kabelPrefab;
    public Canvas canvas;

    public bool alBezig = false;

    public int welkVakBezig;


    public static CursorScript current;
    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        gameObject.transform.position = legeVakken[0].transform.position;
        huidigVak = 0;
    }

    public void CheckInput(string input)
    {
        if (input == "R")
        {
            if (huidigVak < legeVakken.Count - 1)
            {
                huidigVak++;
                gameObject.transform.position = legeVakken[huidigVak].transform.position;
            }
            else
            {
                huidigVak = 0;
                gameObject.transform.position = legeVakken[huidigVak].transform.position;
            }
        }
        else if (input == "L")
        {
            if (huidigVak <= legeVakken.Count - 1 && huidigVak > 0)
            {
                huidigVak--;
                gameObject.transform.position = legeVakken[huidigVak].transform.position;
            }
            else
            {
                huidigVak = legeVakken.Count - 1;
                gameObject.transform.position = legeVakken[huidigVak].transform.position;
            }
        }

        Debug.Log(huidigVak);
    }

    public void VeranderLocatieCursor()
    {
        legeVakken.Remove(legeVakken[huidigVak]);

        if (legeVakken.Count == 1)
        {
            gameObject.transform.position = legeVakken[0].transform.position;
        }
        else if (legeVakken.Count == 0)
        {
            Destroy(gameObject);
            WinManager.current.Gewonnen();
        }
        else
        {
            huidigVak = 0;
            gameObject.transform.position = legeVakken[huidigVak].transform.position;
        }
    }

    public void MaakKabel()
    {

        if(legeVakken[huidigVak].GetComponent<Som>().rotatie == "horizontaal")
        {
            var kabel = Instantiate(kabelPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, canvas.transform) as GameObject;
        }
        else if(legeVakken[huidigVak].GetComponent<Som>().rotatie == "verticaal")
        {
            var kabel = Instantiate(kabelPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0f, 0f, 90f), canvas.transform) as GameObject;
        }

        alBezig = true;
        welkVakBezig = huidigVak;
       
    }
}
