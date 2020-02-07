using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public static Visualizer instance;
    public RectTransform tracker;
    public GameObject NoteIndicator;
    public Transform ParentTransform;

    public List<GameObject> NoteList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NoteList = new List<GameObject>();
    }

    public void SpawnNote()
    {
        NoteList.Add(Instantiate(NoteIndicator, tracker.position,tracker.rotation, ParentTransform));
    }

    public void ResetNoteList()
    {
        for(int i = 0; i < NoteList.Count; i++)
        {
            GameObject note = NoteList[i];
            Destroy(note);
        }
        NoteList.Clear();
    }
}
