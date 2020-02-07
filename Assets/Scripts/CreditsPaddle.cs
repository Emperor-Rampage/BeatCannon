using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPaddle : MonoBehaviour
{
    public SpriteRenderer renderer1;
    public SpriteRenderer renderer2;
    public SpriteRenderer renderer3;

    public AudioClip[] ChromaClips = new AudioClip[12];

    public AudioClip CreditClip;
    public AudioSource CreditSource;

    private float errorMargin = 7.5f; // degrees

    AudioClip SelectClip()
    {
        int DegInt = (int)(Vector3.SignedAngle(Vector3.down, transform.up, Vector3.forward) + errorMargin);
        int NoteIndex = Mathf.Abs((DegInt / 15) % 12);

        return ChromaClips[NoteIndex];
    }

    private void OnMouseDown()
    {
        CreditSource.PlayOneShot(CreditClip);
        iTween.PunchScale(gameObject, new Vector3(.1f, .1f, 0), 0.8f);
    }

}
