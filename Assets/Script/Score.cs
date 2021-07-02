using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Cracked;
    private float PScore;


    // Start is called before the first frame update
    void Start()
    {
        Cracked.text = "SCORE: 0";
    }

    // Update is called once per frame
    void Update()
    {

        PScore += Time.deltaTime;

        Cracked.text = "SCORE: " + (int)PScore;

    }

    private void OnTriggerEnter(Collider coll)
    {
        // Checks if theres a collision with a pick up item
        if (coll.CompareTag("PickUp"))
        {
            coll.gameObject.transform.position = new Vector3(transform.position.x, -10, transform.position.z);
            PScore = PScore + 1;
        }

    }
}
