using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        
        public GameObject nextSchoolPosition = null;
        public GameObject nextSchoolPositionTwo = null;

        public FISH_STATE state;
        [FormerlySerializedAs("direction")] public POSITION_ASSIGN_DIRECTION assignmentDirection;
        
        private SpringJoint springJoint;
        public bool SpringConnected = false;

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
            if (state == FISH_STATE.UNCOLLECTED) return;
            
            TestFishBehaviour testFishBeh = other.gameObject.GetComponent<TestFishBehaviour>();
            //if i am the player
            if (isPlayer && testFishBeh != null && testFishBeh.state == FISH_STATE.UNCOLLECTED)
            {
                //how many fish do i have attached to me
                if (playerFishAttached == 0 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(0f, 2.5f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.UP;
                    testFishBeh.InstantiateNextFishPositions(POSITION_ASSIGN_DIRECTION.UP);
                    testFishBeh.MakeMyselfCollected();
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
                if (playerFishAttached == 1 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(3, 1, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.UP_RIGHT;
                    testFishBeh.InstantiateNextFishPositions(assignmentDirection);
                    testFishBeh.MakeMyselfCollected();
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
                
                if (playerFishAttached == 2 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(3, -1, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN_RIGHT;
                    testFishBeh.InstantiateNextFishPositions(assignmentDirection);
                    testFishBeh.MakeMyselfCollected();
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
                
                if (playerFishAttached == 3 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(0f, -2.5f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN;
                    testFishBeh.InstantiateNextFishPositions(assignmentDirection);
                    testFishBeh.MakeMyselfCollected();
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }

                if (playerFishAttached == 4 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(-3, -1f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.DOWN_LEFT;
                    testFishBeh.InstantiateNextFishPositions(assignmentDirection);
                    testFishBeh.MakeMyselfCollected();
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }

                if (playerFishAttached == 5 && !initialList.Contains(testFishBeh.gameObject))
                {
                    testFishBeh.ConnectSpring(gameObject, new Vector3(-3, 1f, 0f));
                    playerFishAttached++;
                    assignmentDirection = POSITION_ASSIGN_DIRECTION.UP_LEFT;
                    testFishBeh.InstantiateNextFishPositions(assignmentDirection);
                    testFishBeh.MakeMyselfCollected();
                    initialList.Add(testFishBeh.gameObject);
                    return;
                }
            }
            
            
            //if i am not the player
            if (testFishBeh != null && !isPlayer)
            {
                Debug.Log("I am not the player and the other fish is not null");
                //if im collected and the other is uncollected
                if (state == FISH_STATE.COLLECTED && testFishBeh.state == FISH_STATE.UNCOLLECTED)
                {
                    Debug.Log("I am Collected and the other fish is uncollected");
                    if (fishAttached == 0)
                    {
                        //collect the other fish
                        testFishBeh.MakeMyselfCollected();

                        //connect his spring to his ending position
                        testFishBeh.ConnectSpring(nextSchoolPosition, gameObject);
                        
                        testFishBeh.InstantiateNextFishPositions(assignmentDirection);

                        //increase the number of fish attached
                        fishAttached = 1;
                        
                        return;
                    }

                    if (fishAttached == 1)
                    {

                        //collect the other fish
                        testFishBeh.MakeMyselfCollected();

                        //connect his spring to his ending position
                        testFishBeh.ConnectSpring(nextSchoolPositionTwo, gameObject);

                        //increase the number of fish attached
                        fishAttached = 2;
                        return;

                    }
                }
            }
            
        }

        //teleports the gameobject to the position, then it connects a spring to it
        public void ConnectSpring(GameObject gameObject, GameObject rigidBodyObject)
        {
            if (!SpringConnected)
            {
                transform.position = gameObject.transform.position;
            
                SpringConnected = true;
            
                springJoint = this.gameObject.AddComponent<SpringJoint>();
                springJoint.anchor = Vector3.zero;
                springJoint.connectedBody = rigidBodyObject.GetComponent<Rigidbody>();
                springJoint.connectedAnchor = rigidBodyObject.transform.position;
                springJoint.spring = 300;
                springJoint.damper = 10;
                springJoint.enableCollision = false;
                springJoint.tolerance = Random.Range(0.025f, 0.1f);
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
                springJoint.tolerance = Random.Range(0.025f, 0.1f);
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
        public void InstantiateNextFishPositions(POSITION_ASSIGN_DIRECTION assignDirection)
        {
            SetPositionDirection(assignDirection);
            
            nextSchoolPosition = new GameObject();
            nextSchoolPosition.name = "Next Position 1";
            nextSchoolPosition.transform.parent = transform;
            nextSchoolPosition.transform.position = transform.position + FishDirectionOffsetVector.Item1;

            nextSchoolPositionTwo = new GameObject();
            nextSchoolPositionTwo.name = "Next Position 2";
            nextSchoolPositionTwo.transform.parent = transform;
            nextSchoolPositionTwo.transform.position = transform.position + FishDirectionOffsetVector.Item2;
        }

        public void MakeMyselfCollected()
        {
            state = FISH_STATE.COLLECTED;
        }
        
        //intended to be a routine that the fish activate when they are collected
        private IEnumerator JoinTheSchoolRoutine()
        {
            yield return null;
        }
    }
}