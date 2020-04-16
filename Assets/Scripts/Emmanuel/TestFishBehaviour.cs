using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
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

        public int playerFishAttached;
        
        public GameObject nextSchoolPosition;
        public GameObject nextSchoolPositionTwo;

        public FISH_STATE state;
        [FormerlySerializedAs("direction")] public POSITION_ASSIGN_DIRECTION assignmentDirection;
        
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
            playerFishAttached = 0;
            if (isPlayer)
            {
                state = FISH_STATE.COLLECTED;
            }
            else
            {
                state = FISH_STATE.UNCOLLECTED;
            }
            
            
            fishAttached = 0;
            SpringConnected = false;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            TestFishBehaviour testFishBeh = other.gameObject.GetComponent<TestFishBehaviour>();
            
            //probably dont need, gonna delete later
            TestPlayerBehaviour testBeh = other.gameObject.GetComponent<TestPlayerBehaviour>();
            
            if (testBeh != null)
            {
                testBeh.TestPlayerFunction();

                fishEnd = testBeh.nextSchoolPosition;
                ConnectSpring(fishEnd);

                state = FISH_STATE.COLLECTED;
            }

            if (testFishBeh != null)
            {
                if (testFishBeh.isPlayer)
                {
                    if (playerFishAttached == 0)
                    {
                        ConnectSpring(other.gameObject);
                    }
                }
                //if im collected
                if (state == FISH_STATE.COLLECTED)
                {
                    if (fishAttached == 0)
                    {
                        //if the other fish is uncollected
                        if (testFishBeh.state == FISH_STATE.UNCOLLECTED)
                        {
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

        //teleports the gameobject to the position, then it connects a spring to it
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

        public void ConnectSpring(GameObject gameObject, Vector3 positionOffset)
        {
            if (!SpringConnected)
            {
                transform.position = gameObject.transform.position + positionOffset;
            
                SpringConnected = true;
            
                springJoint = ((Component) this).gameObject.AddComponent<SpringJoint>();
                springJoint.anchor = Vector3.zero;
                springJoint.connectedBody = gameObject.GetComponent<Rigidbody>();
                springJoint.connectedAnchor = gameObject.transform.position;
                springJoint.spring = 300-;
                springJoint.damper = 10;
                springJoint.enableCollision = false;
                springJoint.tolerance = 0.025f;
            }
        }

        public Vector3 PlayerBeginningPositions()
        {
            
        }
        
        //sets position direction for next fish positions
        public void SetPositionDirection(POSITION_ASSIGN_DIRECTION newDirection)
        {
            assignmentDirection = newDirection;
        }

        //Returns the offset vector that correlates with each direction of fish position
        public Tuple<Vector3, Vector3> FishDirectionOffsetVector
        {
            get
            {

                switch(assignmentDirection)
                {
                    case POSITION_ASSIGN_DIRECTION.UP:
                    {
                        Vector3 offset1;
                        Vector3 offset2;
                        
                        offset1 = new Vector3(Random.Range(-3f, -1f), Random.Range(1.15f, 2.15f));
                        offset2 = new Vector3(Random.Range(1f, 3f),Random.Range(1.15f, 2.15f));

                        Tuple<Vector3, Vector3> positions = new Tuple<Vector3, Vector3>(offset1, offset2);
                        return positions;
                    }
                    case POSITION_ASSIGN_DIRECTION.UP_RIGHT:
                    {
                        Vector3 offset1;
                        Vector3 offset2;
                        
                        offset1 = new Vector3(Random.Range(1.5f, 2f), Random.Range(1.5f, 2.5f));
                        offset2 = new Vector3(Random.Range(2.5f, 5f), Random.Range(-0.5f, 0.5f));

                        Tuple<Vector3, Vector3> positions = new Tuple<Vector3, Vector3>(offset1, offset2);
                        return positions;
                    }
                    case POSITION_ASSIGN_DIRECTION.DOWN_RIGHT:
                    {
                        Vector3 offset1;
                        Vector3 offset2;
                        
                        offset1 = new Vector3(Random.Range(1.5f, 2f), Random.Range(-1.5f, -2.5f));
                        offset2 = new Vector3(Random.Range(2.5f, 5f), Random.Range(-0.5f, 0.5f));

                        Tuple<Vector3, Vector3> positions = new Tuple<Vector3, Vector3>(offset1, offset2);
                        return positions;
                    }
                    case POSITION_ASSIGN_DIRECTION.DOWN:
                    {
                        Vector3 offset1;
                        Vector3 offset2;
                        
                        offset1 = new Vector3(Random.Range(-3f, -1f), Random.Range(-1.15f, -2.15f));
                        offset2 = new Vector3(Random.Range(1f, 3f),Random.Range(-1.15f, -2.15f));

                        Tuple<Vector3, Vector3> positions = new Tuple<Vector3, Vector3>(offset1, offset2);
                        return positions;
                    }
                    case POSITION_ASSIGN_DIRECTION.DOWN_LEFT:
                    {
                        Vector3 offset1;
                        Vector3 offset2;
                        
                        offset1 = new Vector3(Random.Range(-1.5f, 2f), Random.Range(-1.5f, -2.5f));
                        offset2 = new Vector3(Random.Range(-2.5f, 5f), Random.Range(-0.5f, 0.5f));

                        Tuple<Vector3, Vector3> positions = new Tuple<Vector3, Vector3>(offset1, offset2);
                        return positions;
                    }
                    case POSITION_ASSIGN_DIRECTION.UP_LEFT:
                    {
                        Vector3 offset1;
                        Vector3 offset2;
                        
                        offset1 = new Vector3(Random.Range(-1.5f, 2f), Random.Range(1.5f, 2.5f));
                        offset2 = new Vector3(Random.Range(-2.5f, 5f), Random.Range(-0.5f, 0.5f));

                        Tuple<Vector3, Vector3> positions = new Tuple<Vector3, Vector3>(offset1, offset2);
                        return positions;
                    }
                    default:
                    {
                        return null;
                    }
                }
            }
        }

        //spawns in the next two positions for the next fish to go to
        [ExecuteInEditMode]
        public void InstantiateNextFishPositions()
        {
            GameObject firstPosition = Instantiate(new GameObject(), transform, false);
            transform.position = transform.position += FishDirectionOffsetVector.Item1;
            firstPosition.name = "Next Position 1";

            GameObject secondPosition = Instantiate(new GameObject(), transform, false);
            transform.position = transform.position += FishDirectionOffsetVector.Item2;
            firstPosition.name = "Next Position 2";
        }

        
        //intended to be a routine that the fish activate when they are collected
        private IEnumerator JoinTheSchoolRoutine()
        {
            yield return null;
        }
    }
}