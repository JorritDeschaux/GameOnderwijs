using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public static WinManager current;

    public List<GameObject> lampjes = new List<GameObject>();
    public List<Image> geplaatsteKabels = new List<Image>();
    public List<Image> kabels = new List<Image>();

    private void Awake()
    {
       current = this;

    }

    public void Gewonnen()
    {
        foreach (var lamp in lampjes)
        {
            lamp.GetComponent<Image>().color = Color.green;
        }

        foreach (var kabel in geplaatsteKabels)
        {
            kabel.color = Color.yellow;
        }

        foreach (var kabel in kabels)
        {
            kabel.color = Color.yellow;
        }
    }


}
