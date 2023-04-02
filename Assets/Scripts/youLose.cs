using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youLose : MonoBehaviour
{
    public Text loseText1;
    public Text loseText2;
    public Text loseText3;
    public Text gameStartText;

    private int deathCounter = 0;

    private void Start()
    {
        gameStartText.gameObject.SetActive(true);
        Invoke("disapearText", 5f);


        loseText1.gameObject.SetActive(false);
        loseText2.gameObject.SetActive(false);
        loseText3.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            deathCounter++;
            if (deathCounter == 1)
            {
                Debug.Log("2 lives left");
                loseText1.gameObject.SetActive(true);

                Invoke("disapearText", 3f);  //this makes the text disappear
            }
            else if (deathCounter == 2)
            {
                Debug.Log("1 life left");
                loseText2.gameObject.SetActive(true);

                Invoke("disapearText", 3f);  //this makes the text disappear
            }
            else
            {
                Debug.Log("You lose, game over");
                loseText3.gameObject.SetActive(true);

            }
        }
    }

    private void disapearText()
    {
        loseText1.gameObject.SetActive(false);
        loseText2.gameObject.SetActive(false);
        gameStartText.gameObject.SetActive(false);

    }
}

