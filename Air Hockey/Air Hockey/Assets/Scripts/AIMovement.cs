using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject puck;

    [SerializeField]
    private GameObject testPuck;

    Vector2 AI;
    GameObject myObject;
    public GameObject rightBoundary;
    public GameObject Line;
    Rigidbody2D rb;
    Vector2 malletRadi;
    Vector2 boundary;
    Vector2 clampedPosition;

    public float speed = 10;
    public float defaultSpeed = 18;

    // Start is called before the first frame update.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AI = this.gameObject.transform.position;

        malletRadi = gameObject.GetComponent<SpriteRenderer>().bounds.extents;

 
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        boundary = rightBoundary.GetComponent<Transform>().position;
        AI = Vector2.MoveTowards(transform.position, puck.transform.position, speed * Time.deltaTime);

        if (puck.transform.position.y < 0)
        {
            AI = Vector2.MoveTowards(transform.position, testPuck.transform.position, speed * Time.deltaTime);

            clampedPosition = new Vector2(Mathf.Clamp(AI.x, boundary.x * (-1) + malletRadi.x + 0.5f , boundary.x - malletRadi.x - 0.5f),
                                               Mathf.Clamp(AI.y, malletRadi.y, boundary.y -1.5f));
        }
        
        else if (puck.transform.position.y >= 0)
        {
           clampedPosition = new Vector2(Mathf.Clamp(AI.x, boundary.x * (-1) + malletRadi.x, boundary.x - malletRadi.x),
                                               Mathf.Clamp(AI.y, malletRadi.y, boundary.y - malletRadi.y));
        }

        rb.MovePosition(clampedPosition);
        
    }
}
