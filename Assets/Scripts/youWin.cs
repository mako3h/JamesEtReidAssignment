using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youWin : MonoBehaviour
{
    public Text winText;
    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WINNER"))
        {
            Debug.Log("You win!");
            winText.gameObject.SetActive(true);
        }

    }
}
