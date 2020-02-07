using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    private AudioSource mainSource;
    public AudioClip TestClip;

    // Start is called before the first frame update
    void Start()
    {
        if(mainSource == null)
        {
            mainSource = GetComponent<AudioSource>();
        }

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayImpact()
    {
        mainSource.PlayOneShot(TestClip);
    }

    public void PlayImpact(AudioClip clip)
    {
        mainSource.PlayOneShot(clip);
    }
}
