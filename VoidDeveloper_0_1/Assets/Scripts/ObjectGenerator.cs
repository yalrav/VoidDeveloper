using UnityEngine;
using System.Linq;
using System.IO;
using Assets.Scripts.Config;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public int random1 = 1000;
    public int random2 = 1000;
    public int random3 = 1000;
    public int random4 = 1000;
    public float minScale = 1000;
    public float maxScale = 1000;
    public GameObject[] nondegenerateCubes;
    public bool ñenerator = false;
    public string filePath = "map.txt";
    private ConfigFile Config = new ConfigFile();

    private void Awake()
    {
        if(Config.Read() == 1)
        {
            GenerateMap();
            Config.Write(0);

        }
        else
        {
            LoadMap();
        }
    }

    public void GenerateMap()
    {
        Bounds[] nondegenerateBounds = nondegenerateCubes.Select(x => x.GetComponent<Renderer>().bounds).ToArray();
        int numObjects = Random.Range(random4, random3);
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            for (int i = 0; i < numObjects; i++)
            {
                float randomX = Random.Range(random1, random2);
                float randomY = Random.Range(random1, random2);
                float randomZ = Random.Range(random1, random2);
                float randomRotateZ = Random.Range(-360, 360);
                float randomRotateX = Random.Range(-360, 360);
                float randomRotateY = Random.Range(-360, 360);
                float randomScale = Random.Range(minScale, maxScale);
                Vector3 position = new Vector3(randomX, randomY, randomZ);
                if (!nondegenerateBounds.Any(x => x.Contains(position)))
                {
                    var ind = i % objects.Length;
                    sw.WriteLine($"{objects[ind].name} {position.x} {position.y} {position.z} {randomScale} {randomRotateZ} {randomRotateX} {randomRotateY}");
                    GameObject obj = Instantiate(objects[ind], position, Quaternion.identity);
                    obj.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                    obj.transform.eulerAngles = new Vector3(randomRotateZ, randomRotateX, randomRotateY);
                }
            }
        }
    }

    public void LoadMap()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(' ');
                    string objectName = values[0];
                    GameObject obj = objects.FirstOrDefault(o => o.name == objectName);
                    if (obj != null)
                    {
                        Vector3 position = new Vector3(float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
                        float scale = float.Parse(values[4]);
                        Vector3 rotation = new Vector3(float.Parse(values[5]), float.Parse(values[6]), float.Parse(values[7]));
                        obj = Instantiate(obj, position, Quaternion.identity);
                        obj.transform.localScale = new Vector3(scale, scale, scale);
                        obj.transform.eulerAngles = rotation;
                    }
                    else
                    {
                        Debug.LogError($"Object with name {objectName} not found in objects array.");
                    }
                }
            }
        }
    }
}