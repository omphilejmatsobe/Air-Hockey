using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puck : MonoBehaviour
{
    public GameObject border;
    private Rigidbody2D rb;

    [SerializeField]
    float maxSpeed = 20f;

    Vector2 boundary;
    // Start is called before the first frame update
    void Start()
    {
        boundary = border.GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        

        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

       // Debug.Log("velocity of puck is :" + rb.velocity.magnitude);

        Vector2 puckPosition = new Vector2(Mathf.Clamp(transform.position.x, boundary.x , boundary.x * (-1)),
                                             Mathf.Clamp(transform.position.y, boundary.y , boundary.y * (-1)));

        transform.position = puckPosition;

    }
}
