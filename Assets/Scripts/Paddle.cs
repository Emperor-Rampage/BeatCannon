using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paddle : MonoBehaviour
{
    public SpriteRenderer renderer1;
    public SpriteRenderer renderer2;
    public SpriteRenderer renderer3;

    public AudioClip[] ChromaClips = new AudioClip[12];

    public Color[] ChromaColors = new Color[12];

    AudioClip selectedClip; 

    private float errorMargin = 7.5f; // degrees

    private void Start()
    {
        SetHue();
    }

    int GetClampedRot()
    {
        int DegInt = (int)(Vector3.SignedAngle(Vector3.down, transform.up, Vector3.forward) + errorMargin);
        return Mathf.Abs((DegInt / 15) % 12);
    }

    AudioClip SelectClip()
    {
        int DegInt = (int) (Vector3.SignedAngle(Vector3.down, transform.up, Vector3.forward) + errorMargin);

        return ChromaClips[GetClampedRot()];
    }

    public void SetHue()
    {       
        if(ChromaColors.Length > 0)
        {
            int index = GetClampedRot();
            renderer1.color = ChromaColors[index];
            renderer2.color = ChromaColors[index];
            renderer3.color = ChromaColors[index];
        }
    }


    public void ballImpact()
    {
        selectedClip = SelectClip();

        SoundManager.instance.PlayImpact(selectedClip);
        Conductor.instance.LogPaddleHit();
        Visualizer.instance.SpawnNote();
        iTween.PunchScale(gameObject, new Vector3(.1f,.1f,0) , 0.8f);
    }
}
