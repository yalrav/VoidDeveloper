using System.Collections.Generic;
using UnityEngine;
using System.IO;
using sys = System;
using System.Linq;

[sys.Serializable]
public class MyCLass
{
    public List<int> Num = new List<int>();
    public List<string> Name = new List<string>();
    public List<Vector3> pos = new List<Vector3>();
    public List<Vector3> size = new List<Vector3>();
    public List<Quaternion> a = new List<Quaternion>();
}

[sys.Serializable]
public class MyClass2
{
    public List<MyCLass> myCLasses;
}

public static class JsonUtilityHelper
{
    public static void WriteJson(string filename, object content)
    {
        string json = JsonUtility.ToJson(content, true);
        File.WriteAllText(filename, json);
    }

    public static T LoadJson<T>(string filename)
    {
        string json = File.ReadAllText(filename);
        return JsonUtility.FromJson<T>(json);
    }
}

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

    private void Start()
    {
        PrintHelloWorld();
    }

    public void PrintHelloWorld()
    {
        if (ñenerator == true)
        {
            Bounds[] nondegenerateBounds = nondegenerateCubes.Select(x=>x.GetComponent<Renderer>().bounds).ToArray();
            int numObjects = Random.Range(random4, random3);
            Debug.Log(numObjects);

            var list = new MyCLass();
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
                if (!nondegenerateBounds.Any(x=>x.Contains(position)))
                {
                    var ind = i % objects.Length;
                    GameObject obj = Instantiate(objects[ind], position, Quaternion.identity);
                    obj.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                    obj.transform.eulerAngles = new Vector3(randomRotateZ, randomRotateX, randomRotateY);
                    //obj.AddComponent<movecommet>();

                    list.Num.Add(ind);
                    list.Name.Add(obj.name);
                    list.a.Add(obj.transform.rotation);
                    list.pos.Add(position);
                    list.size.Add(obj.transform.localScale);
                }
            }

            JsonUtilityHelper.WriteJson("ser.json", list);
        }
        else
        {
            MyClass2 loadedData = JsonUtilityHelper.LoadJson<MyClass2>("ser.json");
            foreach (var myClass in loadedData.myCLasses)
            {
                for (int i = 0; i < myClass.Num.Count; i++)
                {
                    GameObject obj = Instantiate(objects[myClass.Num[i]], myClass.pos[i], myClass.a[i]);
                    obj.name = myClass.Name[i];
                    obj.transform.localScale = myClass.size[i];
                }
            }
        }
    }
}