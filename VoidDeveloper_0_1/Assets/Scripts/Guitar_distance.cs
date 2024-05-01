using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Guitar_distance : MonoBehaviour
{
    [SerializeField]
    private AchvimentController controller;

    public Objectinfo[] achviment_objects;
    public GameObject space_ship;

    public float[] des;
    
    // Start is called before the first frame update
    void Start()
    {
        achviment_objects = FindObjectsOfType<Objectinfo>().Where(x=>x.text == "gittare").ToArray();
        des = new float[achviment_objects.Length];
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var obj in achviment_objects)
        {
            if (Vector3.Distance(obj.transform.position, space_ship.transform.position) <=500 )
            {
                controller.On(obj.text);
                Debug.Log(obj);
            }
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        int i = 0;
        foreach (var obj in achviment_objects)
        {
            Gizmos.DrawLine(obj.transform.position, space_ship.transform.position);
            des[i++] = Vector3.Distance(obj.transform.position, space_ship.transform.position);
        }
    }

#endif
}
