using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public int random1 = 1000;
    public int random2 = 1000;
    public int random3 = 1000;
    public int random4 = 1000;
    public float minScale = 1000;
    public float maxScale = 1000;
    private void Start()
    {
        GenerateObjects();
    }

    public void GenerateObjects()
    {
        int numObjects = Random.Range(random4, random3);

        for (int i = 0; i < numObjects; i++)
        {
            float randomX = Random.Range(random1, random2);
            float randomY = Random.Range(random1, random2);
            float randomZ = Random.Range(random1, random2);
            float randomScale = Random.Range(minScale, maxScale);
            Vector3 position = new Vector3(randomX, randomY, randomZ);
            GameObject obj = Instantiate(objects[i % objects.Length], position, Quaternion.identity);
            obj.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}