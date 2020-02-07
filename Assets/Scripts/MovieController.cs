using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    public VideoPlayer vp;
    public SceneLoader SL;
    public bool prepared = false;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

            if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {
                vp.Play();
            }
        }

        if (vp.isPrepared)
        {
            prepared = true;
        }

        if(prepared && !vp.isPaused && !vp.isPlaying)
        {
            SL.InvokeLoad();
        }
    }
}
