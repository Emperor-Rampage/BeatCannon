using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //The current relative position of the song within the loop measured between 0 and 1.
    public float loopPositionInAnalog;

    //Conductor instance
    public static Conductor instance;

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //The offset to the first beat of the song in seconds
    public float firstBeatOffset;

    //the number of beats in each loop
    public float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    public int completedLoops = 0;

    //The current position of the song within the loop in beats.
    public float loopPositionInBeats;

    public List<float> Notes;
    public List<float> WinBeats;
    public int CorrectBeats = 0;

    public Cannon BassCannon;
    public GameObject WinText;

    public SongTimer timerData;
        
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
        BassCannon.FireBall();

        //Testing out a new way of visualizing the timing better for level creators
        if(timerData != null)
            SetWinningBeats(timerData.songTimer);
    }

    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        //calculate the loop position
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
        {   
            if(CorrectBeats >= WinBeats.Count && Notes.Count == WinBeats.Count)
            {
                WinText.SetActive(true);
            }

            Notes.Clear();
            CorrectBeats = 0;
            Visualizer.instance.ResetNoteList();
            completedLoops++;
            BassCannon.FireBall();
        }


        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;
    }

    public void LogPaddleHit()
    {
        Notes.Add(loopPositionInBeats);
        if(EvaluateNotes(loopPositionInBeats))
        {
            CorrectBeats++;
        }
    }

    bool EvaluateNotes(float Note)
    {
       for(int i = 0; i < WinBeats.Count; i++)
        {
            if(Note >= WinBeats[i] - .1f && Note <= WinBeats[i] + .1f)
            {
                return true;
            }
        }

        return false;
    }

    void SetWinningBeats(AnimationCurve timer)
    {
        WinBeats.Clear();
        for(int i = 0; i < timer.length; i++)
        {
            WinBeats.Add(timer.keys[i].time);
        }
    }
}
