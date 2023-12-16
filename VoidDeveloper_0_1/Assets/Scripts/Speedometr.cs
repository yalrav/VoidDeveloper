
using System;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public GameObject Player;
    public Text Speed;

    public float CurrentSpeed
    {
        get { return Player.GetComponent<Rigidbody>().velocity.magnitude; }
    }

    private void Update()
    {
        Speed.text = Mathf.RoundToInt(CurrentSpeed).ToString();
    }
}

