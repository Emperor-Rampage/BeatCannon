using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SongInfo", order = 1)]
public class Info : ScriptableObject
{
    public static Info Instance;

    public int Base  = 4;
    public int Step = 4;
    public float BPM = 60;
}
