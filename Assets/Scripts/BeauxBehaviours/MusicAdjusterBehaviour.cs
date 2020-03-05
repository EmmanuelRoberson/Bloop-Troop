using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class objHolder
{
    public float? floatObj = null;
    public bool? boolObj = null;
    public Rigidbody rigidbodyObj = null;
}

public class MusicAdjusterBehaviour : MonoBehaviour {

    //this is the song to be played and at what time to kick in.
    [SerializeField]
    AudioSource song;
    [SerializeField]
    protected float secOfSong;

    //this is the songs to stop when the other is selected.
    [SerializeField]
    AudioSource[] songListToStop;

    //variable that is tested to see if music change will happen
    public objHolder ObjectOfRef=new objHolder();
    
    /// ///////////////////////////////////////////////////////////

    //float or int
    [SerializeField]
    bool greaterThan, lessThan, equalTo, absoluteValue;

    [SerializeField]
    float numComparison;

    //bool
    [SerializeField]
    bool boolComparison;

    //trigger
    [SerializeField]
    bool triggerComparison;

    //this will change to help with the switch below
    private int objectType;


    //here's the big one
    void songStartup()
    {
        if (song.isPlaying == false)
        {
            foreach (AudioSource stopSong in songListToStop)
            {
                stopSong.Stop();
            }
            song.time = secOfSong;
            song.Play();
        }
        
    }

    //sets which if statement the switch will go through
    void ObjSet()
    {
        if (ObjectOfRef.floatObj != null)
        {
            objectType = 1;
        }

        else if (ObjectOfRef.boolObj != null)
        {
            objectType = 2;
        }

        //else if (ObjectOfRef is Rigidbody)
        //{
        //    objectType = 3;
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
        ObjSet();

        switch (objectType)
        {
            //float/int checks
            case 1:
                if (greaterThan == true && equalTo == true)
                {
                    //absolute value check
                    if (absoluteValue == true)
                    {
                        if (Math.Abs((double)ObjectOfRef.floatObj) >= numComparison)
                        {
                            songStartup();
                        }
                        break;
                    }

                    //standard check
                    if (ObjectOfRef.floatObj >= numComparison)
                    {
                        songStartup();
                    }
                    break;
                }
                else if (lessThan == true && equalTo == true)
                {
                    //absolute value check
                    if (absoluteValue == true)
                    {
                        if (Math.Abs((double)ObjectOfRef.floatObj) <= numComparison)
                        {
                            songStartup();
                        }
                        break;
                    }

                    //standard check
                    if (ObjectOfRef.floatObj <= numComparison)
                    {
                        songStartup();
                    }
                    break;
                }
                else if (greaterThan == true)
                {
                    //absolute value check
                    if (absoluteValue == true)
                    {
                        if (Math.Abs((double)ObjectOfRef.floatObj) > numComparison)
                        {
                            songStartup();
                        }
                        break;
                    }

                    //standard check
                    if (ObjectOfRef.floatObj > numComparison)
                    {
                        songStartup();
                    }
                    break;
                }
                else if (lessThan == true)
                {
                    //absolute value check
                    if (absoluteValue == true)
                    {
                        if (Math.Abs((double)ObjectOfRef.floatObj) < numComparison)
                        {
                            songStartup();
                        }
                        break;
                    }

                    //standard check
                    if (ObjectOfRef.floatObj < numComparison)
                    {
                        songStartup();
                    }
                    break;
                }
                else if (equalTo == true)
                {
                    //absolute value check
                    if (absoluteValue == true)
                    {
                        if (Math.Abs((double)ObjectOfRef.floatObj) == numComparison)
                        {
                            songStartup();
                        }
                        break;
                    }

                    //standard check
                    if (ObjectOfRef.floatObj == numComparison)
                    {
                        songStartup();
                    }
                    break;
                }
                break;
            //bool check
            case 2:
                if (ObjectOfRef.boolObj == boolComparison)
                {
                    songStartup();
                }
                break;
            //trigger
            //case 3:
                //if (OnTriggerStay((Rigidbody)ObjectOfRef) == triggerComparison)
                //{
                //    ;
                //}
                //break;
            default:
                break;
        }
	}
}
