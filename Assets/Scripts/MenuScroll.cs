using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScroll : MonoBehaviour
{

    public LevelManager levelManager;
    public static MenuScroll current;

    public List<GameObject> buttons = new List<GameObject>();
    private int huidigeButton;

    private void Awake()
    {
        current = this;
        huidigeButton = 0;
    }

    public void CheckInput()
    {
        switch (huidigeButton)
        {
            case 0:
                levelManager.LaadScene(2);
                break;
            case 1:
                levelManager.LaadVolgendeScene();
                break;
            case 2:
                levelManager.SpelAfsluiten();
                break;
            default:
                break;
        }
    }

    public void Scroll(string richting)
    {
        switch (richting)
        {
            case "R":

                if(huidigeButton < buttons.Count - 1)
                {
                    huidigeButton++;                
                }
                else
                {
                    huidigeButton = 0;
                }

                gameObject.transform.position = new Vector3(gameObject.transform.position.x, buttons[huidigeButton].transform.position.y, gameObject.transform.position.z);

                break;
            case "L":
                if (huidigeButton <= buttons.Count - 1 && huidigeButton > 0)
                {
                    huidigeButton--;
                }
                else
                {
                    huidigeButton = buttons.Count - 1;
                }

                gameObject.transform.position = new Vector3(gameObject.transform.position.x, buttons[huidigeButton].transform.position.y, gameObject.transform.position.z);
                break;
            default:
                break;
        }
    }

}
