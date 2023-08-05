using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{

    [SerializeField]
    private AudioSource AIAudio;

    [SerializeField]
    private AudioSource playerAudio;

    [SerializeField]
    private AudioSource goalAudio;

    [SerializeField]
    private AudioSource wallAudio;

    public GameObject wall;
    public GameObject goalAI;
    public GameObject goalPlayer;
    public GameObject paddle;
    public GameObject AIPaddle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == goalAI)
        {
            goalAudio.Play();
            Debug.Log("On Collision with goalAI , Audio should play");
        }

        if (collision.gameObject == goalPlayer)
        {
            goalAudio.Play();
            Debug.Log("On Collision with gaolPLayer , Audio should play");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == wall)
        {
            wallAudio.Play();
            Debug.Log("On Collision with wall , Audio should play");
        }


        if (collision.gameObject == paddle)
        {
            playerAudio.Play();
            Debug.Log("On Collision with player paddle , Audio should play");
        }

        else if (collision.gameObject == AIPaddle)
        {
            AIAudio.Play();
            Debug.Log("On Collision with ai paddle , Audio should play");
        }

    }
}
