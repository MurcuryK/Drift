using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float thrust = 100.0f;
    public float defaultDrag = 7.0f;
    Rigidbody rb;
    Animator ani;
    public GameObject Player;
    public Button Left;
    public Button Right;
    
    Vector3 p;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;


    // Start is called before the first frame update
    void Start()
    {
        Button LeftButton = Left.GetComponent<Button>();
        LeftButton.onClick.AddListener(MobeLeft);

        Button RightButton = Right.GetComponent<Button>();
        RightButton.onClick.AddListener(MobeRight);

        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();


        p = Player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Creates a boundry for the player
        if (p.x <= -1.52f)
        {
            Player.transform.position = new Vector3(-1.52f, Player.transform.position.y, Player.transform.position.z);
            rb.velocity = Vector3.zero;
            theTouch.phase = TouchPhase.Canceled;
            ani.SetBool("SRight", false);
            ani.SetBool("SLeft", false);
        }
        if (p.x >= 2.5f)
        {
            Player.transform.position = new Vector3(2.5f, Player.transform.position.y, Player.transform.position.z);
            rb.velocity = Vector3.zero;
            theTouch.phase = TouchPhase.Canceled;
            ani.SetBool("SRight", false);
            ani.SetBool("SLeft", false);
        }

        
        // Calls Player Movement Fuction
        PlayerMovements();

        MoblieMovement();
    }

    void PlayerMovements()
    {
        // Player moves Left if A or a position on the Left side of the screen is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.left * thrust);
            rb.drag = 0;

            ani.SetBool("SLeft", true);
        }
        // Stops the animation when the key or screen is no longer pressed
        if (Input.GetKeyUp(KeyCode.A)) { ani.SetBool("SLeft", false); }

        // Player moves Right if D or a position on the Right side of the screen is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.right * thrust);
            rb.drag = 0;

            ani.SetBool("SRight", true);
        }
        // Stops the animation when the key or screen is no longer pressed
        if (Input.GetKeyUp(KeyCode.D)) { ani.SetBool("SRight", false); }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) rb.drag = defaultDrag;

    }

    void MoblieMovement()
    {
        
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;

                if (theTouch.phase == TouchPhase.Ended)
                {

                    ani.SetBool("SRight", false);
                    ani.SetBool("SLeft", false);

                    rb.drag = defaultDrag;
                }

                // Left
                else if (x < 0)
                {
                    rb.velocity = Vector3.zero;
                    rb.AddForce(Vector3.left * thrust);
                    rb.drag = 0;

                    ani.SetBool("SLeft", true);
                }

                // Right
                else if (x > 0)
                {
                    rb.velocity = Vector3.zero;
                    rb.AddForce(Vector3.right * thrust);
                    rb.drag = 0;

                    ani.SetBool("SRight", true);
                }

            }
        }
    }



    public void MobeLeft()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.left * thrust);
        rb.drag = 0;

        ani.SetBool("SLeft", true);

    }

    public void MobeRight()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.right * thrust);
        rb.drag = 0;

        ani.SetBool("SRight", true);

    }

    void OnTriggerEnter(Collider col)
    {
        //Death
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
            Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        }

    }


}
