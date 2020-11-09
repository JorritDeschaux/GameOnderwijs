using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public List<GameObject> legeVakken = new List<GameObject>();

    private int huidigVak;
    private void Start()
    {
        gameObject.transform.position = legeVakken[0].transform.position;
        huidigVak = 0;
    }

    public void CheckInput(string richting)
    {
        if (richting == "R")
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
        else if (richting == "L")
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

}
