using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public TMP_Text AIScoretext, PlayerScoretext, GoalText, AiGoalText, PlayerLoseText, PlayerWinText;

    private int ai, player;
    private bool scoredFor = false;
    private bool scoredAgainst = false;
    public GameObject spawn;
    int x, y;


    [SerializeField]
    GameObject playerGoal;
    [SerializeField]
    GameObject AIGoal;
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    private GameObject AITextOBJ, GoalTextOBJ, WinTextObj, LoseTextObj, AIObj;
    [SerializeField]
    GameObject playerPaddle;
    [SerializeField]
    GameObject aiPaddle;
    [SerializeField]
    private AudioSource touch;

    private void Start()
    {
        
        AIScoretext.text = ai.ToString();
        PlayerScoretext.text = player.ToString();

        //PlayerWinText.text = "";
        //PlayerLoseText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D Goal)
    {
        x = 0;
        y = 0; 

        if (Goal.gameObject == (playerGoal || AIGoal))
        {

            if (Goal.tag == "AIGoal" || Goal.tag == "PlayerGoal")
            {
                this.gameObject.GetComponent<Renderer>().enabled = false;
                rb.velocity = new Vector2(0, 0);
            }

            if (Goal.tag == "AIGoal")
            {
                ai++;
                AIScoretext.text = ai.ToString();
                scoredFor = true;
               
            }
            else if (Goal.tag == "PlayerGoal")
            {
                player++;
                PlayerScoretext.text = player.ToString();
                scoredAgainst = true;
            }

            if (scoredFor)
            {
                GoalText.text = "GOAL!";
                GoalTextOBJ.gameObject.SetActive(true);

                StartCoroutine(resetPuck(true));
                Debug.Log("scroed for");
                scoredFor = false;
            }

            else if (scoredAgainst)
            {
                AiGoalText.text = "GOAL!";
                AITextOBJ.gameObject.SetActive(true);

                StartCoroutine(resetPuck(false));
                Debug.Log("Scored Against");
                scoredAgainst = false;
            }

            if ( ai == 5)
            {
                PlayerLoseText.text = "YOU LOSE!";
            }

            if ( player == 5 )
            {
                PlayerWinText.text = "YOU WIN!";
            }

            if ( ai == 5 || player == 5)
            {
                GoalTextOBJ.gameObject.SetActive(false);
                AITextOBJ.gameObject.SetActive(false);
                AIObj.gameObject.SetActive(false);

                Invoke("restartMenuAppear", 3);
            }

            
        }
    }

    //Decrements the score whenever the puck collides with either paddles twice
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject == playerPaddle)
        {
            x++;
            y = 0;
            
        }

        if (collision.gameObject == aiPaddle)
        {
            y++;
            x = 0;

        }

        if (x > 1)
        {
            player--;
            Debug.Log("Touched player paddle more than once, x = " + x + " y = " + y);
            x = 0;
            touch.Play();
        }

        if (y > 1)
        {
            ai--;
            Debug.Log("Touched ai paddle more than once, y = " + y + " x = " + x);
            y = 0;
            touch.Play();
        }

        Debug.Log("ai  = " + ai);
        Debug.Log("player = " + player);



        if (ai < 0) { ai = 0; }
        if (player < 0) { player = 0; }

        AIScoretext.text = ai.ToString();
        PlayerScoretext.text = player.ToString();


    }

    public void restartMenuAppear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator resetPuck(bool waitTime)
    {
        yield return new WaitForSecondsRealtime(1);
        Vector2 reset = this.gameObject.GetComponent<Transform>().position;
        float x = 0;

        if (waitTime == true)
        {
            x = spawn.transform.position.y;
        }

        if (waitTime == false)
        {
            x = spawn.transform.position.y * (-1);
        }

        AiGoalText.text = "";
        GoalText.text = "";

        
        rb.position = new Vector2(0, x);

        

        this.gameObject.GetComponent<Renderer>().enabled = true;
    }

    
}
