using System.Collections;
using System.Collections.Generic;
using RhythmTool;
using UnityEditor;
using UnityEngine;

public class RespondToRhythm : MonoBehaviour
{
    public RhythmEventProvider eventProvider;
    public float speed;
    public Vector3 velocity;
    public float scaleAmount;

    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        eventProvider.Register<Beat>(ScaleFunction);
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            transform.localScale += new Vector3(0, scaleAmount, 0) * Time.fixedDeltaTime;
    }

    void ScaleFunction(Beat onBeat)
    {
        canMove = true;
        scaleAmount *= -1;
    }
}
