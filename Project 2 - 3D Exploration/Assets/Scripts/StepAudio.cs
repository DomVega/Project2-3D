using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAudio : MonoBehaviour
{
    public AudioClip musicClipOne;

   
    
    AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
          musicSource.clip = musicClipOne;
          musicSource.Play();
          

         }

     if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
          musicSource.Stop();

         }
    }
}
