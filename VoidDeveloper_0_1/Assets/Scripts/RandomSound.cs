using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public int minTime;
    public int maxTime;
    public AudioSource audioSource;
    public AudioClip [] clip;

    private void Start()
    {
        StartCoroutine(nameof(OnTime));
    }

    private IEnumerator OnTime()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        if (audioSource.isPlaying)
        {

        }
        else
        {
            audioSource.clip = clip[Random.Range(0, clip.Length)];
            audioSource.Play();
        }
        StartCoroutine(nameof(OnTime));
    }
}
