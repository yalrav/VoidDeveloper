using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AudioFin : MonoBehaviour
{
    public AudioSource sfxPoint;
    public GameObject[] targetObjects;

    private void Start()
    {
        sfxPoint = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (targetObjects.Contains(collision.gameObject))
        {
            Debug.Log("1");
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (sfxPoint != null)
        {
            sfxPoint.Play();
        }
    }
}