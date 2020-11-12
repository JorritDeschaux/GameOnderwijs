using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kabel : MonoBehaviour
{
    public GameObject kabelStukPrefab;
    private InputField antwoordInput;
    private Transform kabelTransform;
    private GameObject som;
    private GameObject kabelStuk;
    public GameObject vak;

    public string soortSom;

    private float breukGrootte;
    private void Start()
    {
        antwoordInput = GetComponentInChildren<InputField>();
        kabelTransform = FindObjectOfType<Image>().GetComponent<Transform>();
        som = GameObject.Find("Som");

        vak = CursorScript.current.legeVakken[CursorScript.current.welkVakBezig];
        soortSom = vak.GetComponent<Som>().soortSom;
        som.GetComponent<Text>().text = vak.GetComponent<Som>().som;
    }

    public void VeranderKabelGrootte()
    {
        switch (soortSom)
        {
            case "normaal":
                if (antwoordInput.text != "")
                {
                    kabelTransform.localScale = new Vector3(float.Parse(antwoordInput.text), kabelTransform.localScale.y, kabelTransform.localScale.z);
                }
                break;
            case "breuk":
                if (antwoordInput.text.Contains("/") && antwoordInput.text != "") 
                {
                    if(antwoordInput.text.Length == 3)
                    {
                        Debug.Log(antwoordInput.text);

                        char[] cijfers = antwoordInput.text.ToCharArray();
                        cijfers[1] = ' ';
                        breukGrootte = (float.Parse(cijfers[0].ToString()) / float.Parse(cijfers[2].ToString()));
                        Debug.Log(breukGrootte);
                        kabelTransform.localScale = new Vector3(breukGrootte, kabelTransform.localScale.y, kabelTransform.localScale.z);
                    }
                }
                break;
            default:
                Debug.Log("error");
                break;
        }
        
    }

    private void VoegKabelToe()
    {
        switch (vak.GetComponent<Som>().rotatie)
        {
            case "horizontaal":
                kabelStuk = Instantiate(kabelStukPrefab, new Vector3(CursorScript.current.gameObject.transform.position.x, CursorScript.current.gameObject.transform.position.y, kabelTransform.position.z), Quaternion.identity, CursorScript.current.canvas.transform) as GameObject;
                break;
            case "verticaal":
                kabelStuk = Instantiate(kabelStukPrefab, new Vector3(CursorScript.current.gameObject.transform.position.x, CursorScript.current.gameObject.transform.position.y, kabelTransform.position.z), Quaternion.Euler(0f, 0f, 90f), CursorScript.current.canvas.transform) as GameObject;
                break;
            default:
                break;
        }
    }

    public void CheckAntwoord()
    {

        switch (soortSom)
        {
            case "normaal":
                if (vak.GetComponent<Som>().antwoord == float.Parse(antwoordInput.text))
                {
                    VoegKabelToe();
                    WinManager.current.geplaatsteKabels.Add(kabelStuk.GetComponent<Image>());
                    Debug.Log("Lengte is goed");
                    kabelStuk.transform.localScale = new Vector3(kabelTransform.localScale.x, kabelTransform.localScale.y);
                    CursorScript.current.VeranderLocatieCursor();
                    CursorScript.current.alBezig = false;
                    Destroy(vak);
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Lengte is fout");
                }
                break;
            case "breuk":
                if (vak.GetComponent<Som>().antwoord == breukGrootte)
                {
                    VoegKabelToe();
                    WinManager.current.geplaatsteKabels.Add(kabelStuk.GetComponent<Image>());
                    Debug.Log("Lengte is goed");
                    kabelStuk.transform.localScale = new Vector3(kabelTransform.localScale.x, kabelTransform.localScale.y);
                    CursorScript.current.VeranderLocatieCursor();
                    CursorScript.current.alBezig = false;
                    Destroy(vak);
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Lengte is fout");
                }
                break;
            default:
                break;
        }

    }

}
