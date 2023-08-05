using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private bool moveActive;
    GameObject myObject;

    [SerializeField]
    private GameObject leftBoundary;
    public Vector2 boundary;
    public Vector2 mouseWorldPosition;
    public Vector2 transformCord;
    public Vector2 paddleRadius;


    Vector2 boundMove;
    Rigidbody2D rb;
    Collider2D playerCollider;


    // Start is called before the first frame update

    void Start()
    {
        myObject = GameObject.Find("Puck");
        playerCollider = this.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "puck")
        {
            
            Debug.Log("In Contact");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "player")
        {
            
            Debug.Log("In Contact");
        }
    }

    void Update()
    {
        
        bool leftButtonPress = Input.GetMouseButton(0);

        //mouse position on the screen and the scene world position.

        Vector2 mousePosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 malletPos = this.gameObject.transform.position;
        paddleRadius = gameObject.GetComponent<SpriteRenderer>().bounds.extents;

        boundary = leftBoundary.GetComponent<Transform>().position;

        Vector2 boundaryCod = leftBoundary.GetComponent<Transform>().position;

        //Sets the min and max coordinates for x and y, making a boundary around the area of the player.

        Vector2 clampedPosition = new Vector2(Mathf.Clamp(mouseWorldPosition.x, boundary.x + paddleRadius.x, boundary.x * (-1) - paddleRadius.x),
                                              Mathf.Clamp(mouseWorldPosition.y, boundary.y + paddleRadius.y, paddleRadius.y * (-1)));


        if (leftButtonPress)
        {

            Debug.Log("Left button pressed");
            

            //checks if the mouseWorld position is within the radius of the playe paddle
            //if it is , assign the mouseWorldPosition to the paddle position

            if (playerCollider.OverlapPoint(mouseWorldPosition))
             {
                Debug.Log("Is within the radius of the paddle. Object should move");

                // assignes mouse position to the player paddle when left mouse button is pressed. 

                
                rb.MovePosition(clampedPosition);
             }

        }

        
        else
        {
            Debug.Log("Left button not pressed.");
        }

        transformCord = transform.position;
    }

}
