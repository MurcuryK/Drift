using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstical : MonoBehaviour
{
    public float speed = -3f;
    private float timeSinceSpeedUp;
    public float speedRate = 5f;
    Rigidbody rb;

    private float timeSinceReset;
    public float restRate = 1f;

    Vector3[] Spawn = new[] { new Vector3(-1.57f, -0.2f, 11), new Vector3(-0.53f, -0.2f, 11), new Vector3(0.48f, -0.2f, 11), new Vector3(1.442f, -0.2f, 11), new Vector3(2.45f, -0.2f, 11) };
    int currentspawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeSinceSpeedUp = 0f;
        timeSinceReset = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentspawn = Random.Range(0, 4);
        timeSinceReset += Time.deltaTime;
        timeSinceSpeedUp += Time.deltaTime;

        rb.velocity = new Vector3(transform.position.x, transform.position.y, speed);

        if (timeSinceSpeedUp >= speedRate)
        {
            timeSinceSpeedUp = 0f;
            speed = speed - 0.1f;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        //Respawn
        if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "PickUp")
        {
            timeSinceReset += Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y -10, this.transform.position.z);
            if (timeSinceReset >= restRate)
            {
                Debug.Log("Hit its self");
                this.transform.position = Spawn[currentspawn];
                timeSinceReset = 0f;
            }

        }

    }
}
