using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    AudioSource source;
    public AudioClip clip;

    float time;
    float interval;

    private void Awake()
    {
        source = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && time <= Time.time)
        {
            time = Time.time + interval;
            source.PlayOneShot(clip);
        }
    }
}
