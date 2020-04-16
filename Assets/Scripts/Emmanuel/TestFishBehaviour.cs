using System;
using System.Collections;
using System.Collections.Generic;
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
        public List<GameObject> initialList = new List<GameObject>();
        
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
            get { return (Vector3.Distance(transform.position, currentPosition.transform.position) > 0.005); }
        }
        
        //where the fish will end up
        [FormerlySerializedAs("fishEnd")] public GameObject currentPosition;

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
            //if i am the player
            if (isPlayer && testFishBeh != null)
            {
                //how many fish do i have attached to me
                if (playerFishAttached == 0 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(0f, 2.5f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.UP;
                    testFishBeh.InstantiateNextFishPositions();
                    Debug.Log(playerFishAttached + " Player Position Instantiated");  
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
                if (playerFishAttached == 1 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(3, 1, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.UP_RIGHT;
                    testFishBeh.InstantiateNextFishPositions();
                    Debug.Log(playerFishAttached + " Player Position Instantiated"); 
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
                
                if (playerFishAttached == 2 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(3, -1, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN_RIGHT;
                    testFishBeh.InstantiateNextFishPositions();
                    Debug.Log(playerFishAttached + " Player Position Instantiated");  
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
                
                if (playerFishAttached == 3 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(0f, -2.5f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN;
                    testFishBeh.InstantiateNextFishPositions();
                    Debug.Log(playerFishAttached + " Player Position Instantiated");
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }

                if (playerFishAttached == 4 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(-3, -1f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN_LEFT;
                    testFishBeh.InstantiateNextFishPositions();
                    Debug.Log(playerFishAttached + " Player Position Instantiated");  
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }

                if (playerFishAttached == 5 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(-3, 1f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.UP_LEFT;
                    testFishBeh.InstantiateNextFishPositions();
                    Debug.Log(playerFishAttached + " Player Position Instantiated"); 
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
            }


            /*if (testFishBeh != null)
            {
                if (testFishBeh.state == FISH_STATE.COLLECTED)
                {
                    //the first 6 positions
                    if (testFishBeh.isPlayer)
                    {
                        if (testFishBeh.playerFishAttached == 0)
                        {
                            GameObject position = Instantiate(new GameObject(), other.transform, false);

                            ConnectSpring(position, new Vector3(0f, 2.5f, 0f));
                            testFishBeh.playerFishAttached++;
                            assignmentDirection = POSITION_ASSIGN_DIRECTION.UP;
                            InstantiateNextFishPositions();
                            Debug.Log(playerFishAttached + " Player Position Instantiated");                            return;
                        }

                        if (testFishBeh.playerFishAttached == 1)
                        {
                            GameObject position = Instantiate(new GameObject(), other.transform, false);

                            ConnectSpring(position, new Vector3(3, 1, 0f));
                            testFishBeh.playerFishAttached++;
                            assignmentDirection = POSITION_ASSIGN_DIRECTION.UP_RIGHT;
                            InstantiateNextFishPositions();
                            Debug.Log(playerFishAttached + " Player Position Instantiated");                            return;
                        }

                        if (testFishBeh.playerFishAttached == 2)
                        {
                            GameObject position = Instantiate(new GameObject(), other.transform, false);

                            ConnectSpring(position, new Vector3(3, -1, 0f));
                            testFishBeh.playerFishAttached++;
                            assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN_RIGHT;
                            InstantiateNextFishPositions();
                            Debug.Log(playerFishAttached + " Player Position Instantiated");
                            return;
                        }

                        if (testFishBeh.playerFishAttached == 3)
                        {
                            GameObject position = Instantiate(new GameObject(), other.transform, false);

                            ConnectSpring(position, new Vector3(0f, -2.5f, 0f));
                            testFishBeh.playerFishAttached++;
                            assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN;
                            InstantiateNextFishPositions();
                            Debug.Log(playerFishAttached + " Player Position Instantiated");                            return;
                        }

                        if (testFishBeh.playerFishAttached == 4)
                        {
                            GameObject position = Instantiate(new GameObject(), other.transform, false);

                            ConnectSpring(position, new Vector3(-3, -1f, 0f));
                            testFishBeh.playerFishAttached++;
                            assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN_LEFT;
                            InstantiateNextFishPositions();
                            Debug.Log(playerFishAttached + " Player Position Instantiated");                            return;
                        }

                        if (testFishBeh.playerFishAttached == 5)
                        {
                            GameObject position = Instantiate(new GameObject(), other.transform, false);

                            ConnectSpring(position, new Vector3(-3, 1f, 0f));
                            testFishBeh.playerFishAttached++;
                            assignmentDirection = POSITION_ASSIGN_DIRECTION.UP_LEFT;
                            InstantiateNextFishPositions();
                            Debug.Log(playerFishAttached + " Player Position Instantiated");                            return;
                        }
                    }
                    else
                    {
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
                                    testFishBeh.currentPosition = nextSchoolPosition;

                                    //connect his spring to his ending position
                                    testFishBeh.ConnectSpring(testFishBeh.currentPosition);
                                
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
                                    testFishBeh.currentPosition = nextSchoolPositionTwo;

                                    //connect his spring to his ending position
                                    testFishBeh.ConnectSpring(testFishBeh.currentPosition);

                                    //increase the number of fish attached
                                    fishAttached = 2;
                                }
                            }
                        }
                    }
                }
            }*/
        }

        //teleports the gameobject to the position, then it connects a spring to it
        public void ConnectSpring(GameObject gameObject)
        {
            if (!SpringConnected)
            {
                transform.position = gameObject.transform.position;
            
                SpringConnected = true;
            
                springJoint = this.gameObject.AddComponent<SpringJoint>();
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
            
                springJoint = this.gameObject.AddComponent<SpringJoint>();
                springJoint.anchor = Vector3.zero;
                springJoint.connectedBody = gameObject.GetComponent<Rigidbody>();
                springJoint.connectedAnchor = gameObject.transform.position;
                springJoint.spring = 300;
                springJoint.damper = 10;
                springJoint.enableCollision = false;
                springJoint.tolerance = 0.025f;
            }
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
            firstPosition.transform.parent = transform;
            firstPosition.transform.position = transform.position + FishDirectionOffsetVector.Item1;
            firstPosition.name = "Next Position 1";
            nextSchoolPosition = firstPosition;

            GameObject secondPosition = Instantiate(new GameObject(), transform, false);
            transform.parent = transform;
            secondPosition.transform.position = transform.position + FishDirectionOffsetVector.Item2;
            secondPosition.name = "Next Position 2";
            nextSchoolPosition = secondPosition;
        }

        
        //intended to be a routine that the fish activate when they are collected
        private IEnumerator JoinTheSchoolRoutine()
        {
            yield return null;
        }
    }
}