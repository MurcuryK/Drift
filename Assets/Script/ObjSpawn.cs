using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawn : MonoBehaviour
{
    Vector3[] SpawnOb = new[] { new Vector3(-1.57f, -0.66f, 11), new Vector3(-0.53f, -0.66f, 11), new Vector3(0.48f, -0.66f, 11), new Vector3(1.442f, -0.66f, 11), new Vector3(2.45f, -0.66f, 11) };
    Vector3[] SpawnPick = new[] { new Vector3(-1.57f, -0.40f, 11), new Vector3(-0.53f, -0.40f, 11), new Vector3(0.48f, -0.40f, 11), new Vector3(1.442f, -0.40f, 11), new Vector3(2.45f, -0.40f, 11) };
    public GameObject[] Objects;
    public GameObject ObjectPrefab;
    public GameObject PickUpPrefab;
    int cheak = 0;
    int currentspawn = 0;
    public int currentObject = 0;
    int ObjectPoolSize = 10;


    private float timeSinceLastSpawned;
    public float spawnRate = 3f;

    int pickUpOne;
    int pickUpTwo;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;
        pickUpOne = Random.Range(1, 4);
        pickUpTwo = Random.Range(5, 8);
        //Initialize the columns collection.
        Objects = new GameObject[ObjectPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < ObjectPoolSize; i++)
        {
            Vector3 SpawnPoint = SpawnOb[Random.Range(0, SpawnOb.Length)];
            if (i == pickUpOne || i == pickUpTwo)
            {
                Objects[i] = (GameObject)Instantiate(PickUpPrefab, new Vector3(-0.53f, -10.2f, 11), Quaternion.identity);
            }
            else
            {
                //...and create the individual columns.
                Objects[i] = (GameObject)Instantiate(ObjectPrefab, new Vector3(-0.53f, -10.2f, 11), Quaternion.identity);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        currentspawn = Random.Range(0, 4);

        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            Vector3 SpawnPointOb = SpawnOb[Random.Range(0, SpawnOb.Length)];
            Vector3 SpawnPointPick = SpawnPick[Random.Range(0, SpawnPick.Length)];
            //...then set the current column to that position.
            if (Objects[currentObject].transform.position.z < -12 && Objects[currentObject].transform.tag == "PickUp") Objects[currentObject].transform.position = SpawnPointPick;
            if (Objects[currentObject].transform.position.z < -12 && Objects[currentObject].transform.tag == "Obstacle") Objects[currentObject].transform.position = SpawnPointOb;
            else { currentObject++; }

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            //currentObject++;

            if (currentObject >= ObjectPoolSize)
            {
                currentObject = 0;
            }

            if (spawnRate < 0.5f) { spawnRate = .5f; }
            else spawnRate = spawnRate - 0.05f;
        }

    }
}
