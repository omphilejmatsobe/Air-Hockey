using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backPosition : MonoBehaviour
{
    [SerializeField]
    GameObject puck;
    Vector2 puckPos;
    Vector2 thisPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        puckPos = puck.transform.position;
        thisPos = gameObject.transform.position;

        thisPos.x = puckPos.x;
        transform.position = thisPos;
    }
}
