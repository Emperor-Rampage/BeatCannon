using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelTimeline", menuName = "LevelTimeline", order = 1)]
public class LevelTimeline : ScriptableObject
{
    public int LengthOfTimelineInMeasures;
    public List<Note> Notes;
}

[CreateAssetMenu(fileName = "Note", menuName = "Note", order = 1)]
public class Note : ScriptableObject
{
    public int Measure;
    public float Timing;
}
