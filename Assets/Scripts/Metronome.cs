using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public static Metronome instance;

    public Cannon BassCannon;
    public Info info;
    public LevelTimeline LT;
    public int CurrentStep = 1;
    public int MeasureLimit = 3;
    public int CurrentMeasure;
    public int TempVictoryPoints = 0;

    //public LevelTimeline[] Levels;

    private float interval;
    private float nextTime;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartMetronome();
    }

    public void StartMetronome()
    {
        StopCoroutine("DoTick");
        CurrentStep = 1;
        var multiplier = info.Base / 4f;
        var tmpInterval = 60f / info.BPM;
        interval = tmpInterval / multiplier;
        nextTime = Time.time; // set the relative time to now
        StartCoroutine("DoTick");
    }

    IEnumerator DoTick() // yield methods return IEnumerator
    {
        for (; ; )
        {
           //Debug.Log("bop");
            if (CurrentStep == 1)
                FireBall();
            nextTime += interval; // add interval to our relative time
            yield return new WaitForSeconds(nextTime - Time.time); // wait for the difference delta between now and expected next time of hit
            CurrentStep++;
            if (CurrentStep > info.Step)
            {
                CurrentStep = 1;
                ++CurrentMeasure;
                if (CurrentMeasure > MeasureLimit)
                {
                    ResetTimeline(); //Reset after the measures limit (for how long the ditty lasts)
                }
            }
        }
    }

    void EvaluateTimeline( /*PaddleHit info*/) //Check the timeline to see if a hit was on time
    {
        /*if (LT contains a note near impact time)
         * {
         * Evaluate if the note matches the impact, check it off on the dictionary.
         * if(TempVictory points == number of notes in the LevelTimeline) Check to see if the player has completed the melody. 
         * {
         *  Stop DoTick() coroutine;
         *  Set win state.
         * }
         * 
         * }
         * */
    }

    public void LogPaddleHit() //Store any incoming hits from the paddles and their time
    {
        /*Collect data that was passed and the current time along the timeline, add it to the list of hits and send it to...
        EvaluateTimeline();
        */
    }

    void ResetTimeline() //Clear out all hits and reset everything back to a starting position.
    {

    }

    void FireBall()
    {
        BassCannon.FireBall();
    }

}
