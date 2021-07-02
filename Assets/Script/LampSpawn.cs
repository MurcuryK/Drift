using UnityEngine;
using System.Collections;

public class LampSpawn : MonoBehaviour
{
    public GameObject[] ObjectsLeft;
    public GameObject[] ObjectsRight;

    public GameObject ObjectPrefabLeft;
    int cheak = 0;
    int currentspawn = 0;
    public int currentObjectL = 0;
    public int currentObjectR = 0;
    int ObjectPoolSizeLeft = 7;


    private float timeSinceLastSpawned;
    public float spawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;
        //Initialize the columns collection.
        ObjectsLeft = new GameObject[ObjectPoolSizeLeft];
        ObjectsRight = new GameObject[ObjectPoolSizeLeft];
        //Loop through the collection... 
        for (int i = 0; i < ObjectPoolSizeLeft; i++)
        {
            
            ObjectsLeft[i] = (GameObject)Instantiate(ObjectPrefabLeft, new Vector3(-1.93f, -10.44f, 30), Quaternion.Euler(90f, 0f, 180f));
        }

        for (int i = 0; i < ObjectPoolSizeLeft; i++)
        {
            ObjectsRight[i] = (GameObject)Instantiate(ObjectPrefabLeft, new Vector3(2.76f, -10.44f, 30), Quaternion.Euler(90f, 0f, 180f));
            ObjectsRight[i].transform.localScale = new Vector3(-0.3f, 0.48117f, 0.48117f);
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

            //...then set the current column to that position.
            if (ObjectsLeft[currentObjectL].transform.position.z < -12) ObjectsLeft[currentObjectL].transform.position = new Vector3(-1.93f, 1.44f, 30);
            else { currentObjectL++; }

            //...then set the current column to that position.
            if (ObjectsRight[currentObjectR].transform.position.z < -12) ObjectsRight[currentObjectR].transform.position = new Vector3(2.76f, 1.44f, 30);
            else { currentObjectR++; }
            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            //currentObject++;

            if (currentObjectL >= ObjectPoolSizeLeft)
            {
                currentObjectL = 0;
            }
            if (currentObjectR >= ObjectPoolSizeLeft)
            {
                currentObjectR = 0;
            }
        }

    }

    //private IEnumerator WaitL()
    //{
    //    for (int i = 0; i < ObjectPoolSizeLeft; i++)
    //    {
    //        ObjectsLeft[i] = (GameObject)Instantiate(ObjectPrefabLeft, new Vector3(-1.93f, 1.44f, 30), Quaternion.Euler(90f, 0f, 180f));
    //    }
    //    yield return new WaitForSeconds(1f);
    //}
}
