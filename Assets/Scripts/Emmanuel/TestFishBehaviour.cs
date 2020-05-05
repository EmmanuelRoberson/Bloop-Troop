using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

namespace Emmanuel
{
    public enum FISH_STATE
    {
        UNCOLLECTED = 0,
        COLLECTED = 1,

    }

    public enum POSITION_ASSIGN_DIRECTION
    {
        UP = 0,
        UP_RIGHT,
        DOWN_RIGHT,
        DOWN,
        DOWN_LEFT,
        UP_LEFT
    }


    public class TestFishBehaviour : MonoBehaviour
    {
        public bool isPlayer;

        public int fishAttached;
        
        public GameObject nextSchoolPosition;
        public GameObject nextSchoolPositionTwo;

        public FISH_STATE state;
        public POSITION_ASSIGN_DIRECTION direction;
        
        
    
        private SpringJoint springJoint;
        public bool SpringConnected = false;

        public bool NotInPosition
        {
            get { return (Vector3.Distance(transform.position, fishEnd.transform.position) > 0.005); }
        }
    
        
        //where the fish will end up
        public GameObject fishEnd;

        public float speed = 1.0f;
        public float journeyLength = 1.0f;
        private float startTime;

        // Start is called before the first frame update
        void Start()
        {
            if (isPlayer)
            {
                state = FISH_STATE.COLLECTED;
            }
            else
            {
                state = FISH_STATE.UNCOLLECTED;
            }
            
            fishAttached = 0;
            state = FISH_STATE.UNCOLLECTED;

            fishAttached = 0;
            SpringConnected = false;

            //System.Random rand1 = new System.Random((int)Time.time);
            //Vector3 offset = new Vector3(rand1.Next(-5, 5), rand1.Next(-5, 5), 0);

            //nextSchoolPosition.transform.position += offset;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            TestFishBehaviour testFishBeh = other.gameObject.GetComponent<TestFishBehaviour>();
            TestPlayerBehaviour testBeh = other.gameObject.GetComponent<TestPlayerBehaviour>();
            
            if (testBeh != null)
            {
                //parentFish = other.gameObject;
                testBeh.TestPlayerFunction();

                fishEnd = testBeh.nextSchoolPosition;
                ConnectSpring(fishEnd);

                state = FISH_STATE.COLLECTED;
            }

            if (testFishBeh != null)
            {
                Debug.Log("fish behaviour not null" + name);
                //if im collected
                if (state == FISH_STATE.COLLECTED)
                {
                    Debug.Log("i am collected" + name);
                    if (fishAttached == 0)
                    {
                        Debug.Log("I have no fish attached to me" + name);
                        //if the other fish is uncollected
                        if (testFishBeh.state == FISH_STATE.UNCOLLECTED)
                        {
                            Debug.Log("the fish i want to collect is uncollected" + name);
                            //collect the other fish
                            testFishBeh.state = FISH_STATE.COLLECTED;

                            //make his ending the position after me
                            testFishBeh.fishEnd = nextSchoolPosition;

                            //connect his spring to his ending position
                            testFishBeh.ConnectSpring(testFishBeh.fishEnd);
                            
                            //increase the number of fish attached
                            fishAttached = 1;
                            
                            Debug.Log(fishAttached);
                            return;
                        }
                    }
                    
                    if (fishAttached == 1)
                    {
                        //if the other fish is uncollected
                        if (testFishBeh.state == FISH_STATE.UNCOLLECTED)
                        {
                            Debug.Log("ITS DUO TIME" + name);
                            //collect the other fish
                            testFishBeh.state = FISH_STATE.COLLECTED;

                            //make his ending the other position after me
                            testFishBeh.fishEnd = nextSchoolPositionTwo;

                            //connect his spring to his ending position
                            testFishBeh.ConnectSpring(testFishBeh.fishEnd);

                            //increase the number of fish attached
                            fishAttached = 2;
                        }
                    }
                }
            }
        }

        public void ConnectSpring(GameObject gameObject)
        {
            if (!SpringConnected)
            {
                transform.position = gameObject.transform.position;
            
                SpringConnected = true;
            
                springJoint = ((Component) this).gameObject.AddComponent<SpringJoint>();
                springJoint.anchor = Vector3.zero;
                springJoint.connectedBody = gameObject.GetComponent<Rigidbody>();
                springJoint.connectedAnchor = gameObject.transform.position;
                springJoint.spring = 300;
                springJoint.damper = 10;
                springJoint.enableCollision = false;
                springJoint.tolerance = 0.025f;
            }
        }

        public void SetPositionDirection(POSITION_ASSIGN_DIRECTION newDirection)
        {
            direction = newDirection;
        }

        public void PrepareNExtFishPositions()
        {
            
            
            GameObject firstPosition = Instantiate(new GameObject(), transform, false);
            //transform.position = transform.position += 

            GameObject secondPosition = Instantiate(new GameObject());
        }

        public Vector3 NextSchoolPositionOffset
        {
            get
            {
                Vector3 offset = new Vector3();
                return offset;
            }
        }

        private IEnumerator JoinTheSchoolRoutine()
        {
            yield return null;
        }
    }
}