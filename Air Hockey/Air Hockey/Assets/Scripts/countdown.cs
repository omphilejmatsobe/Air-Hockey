using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class countdown : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textDisplay;

    [SerializeField]
    int currentTime;

    [SerializeField]
    GameObject puck;

    [SerializeField]
    GameObject AI;

    [SerializeField]
    private AudioSource countDown;

    [SerializeField]
    private AudioSource audioSource;



    private void Start()
    {
        StartCoroutine(CountdownTimer());
    }


    IEnumerator CountdownTimer()
    {
        while( currentTime > 0)
        {
            // puck.GetComponent<Renderer>().enabled = false;

            countDown.Play();

            AI.gameObject.SetActive(false);
            puck.gameObject.SetActive(false);
            textDisplay.text = currentTime.ToString();

            yield return new WaitForSeconds(1f);

            currentTime--;

        }

        audioSource.Play();
        textDisplay.text = "PLAY!";

        //GameController.instance.BeginGame();

        yield return new WaitForSeconds(1f);

        //puck.GetComponent<Renderer>().enabled = true;
        AI.gameObject.SetActive(true);
        puck.gameObject.SetActive(true);
        textDisplay.gameObject.SetActive(false);
    }
    

}
