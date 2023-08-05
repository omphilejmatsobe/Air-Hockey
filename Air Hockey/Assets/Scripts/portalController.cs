using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController : MonoBehaviour
{
    [SerializeField]
    Transform destination;

    [SerializeField]
    GameObject puck;

    Rigidbody2D rigidBody;

    Vector2 lb;

    private void Awake()
    {
        rigidBody = puck.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == puck)
        {
            Debug.Log(rigidBody.velocity);

            if (Vector2.Distance(puck.transform.position , transform.position) > 0.5f)
            {
                puck.transform.position = destination.transform.position;
               
            }
        }
    }
}
