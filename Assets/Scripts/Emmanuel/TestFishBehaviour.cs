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
        public bool isPlayer;

        public int fishAttached;

        public int playerFishAttached;
        
        [FormerlySerializedAs("nextSchoolPosition")] public GameObject schoolPositionOne = null;
        [FormerlySerializedAs("nextSchoolPositionTwo")] public GameObject schoolPositionTwo = null;

        public GameObject parentFish;
        [FormerlySerializedAs("childFish")] public List<GameObject> childrenFish;

        public FISH_STATE state;
        [FormerlySerializedAs("direction")] public POSITION_ASSIGN_DIRECTION assignmentDirection;
        
        private SpringJoint springJoint;
        public bool SpringConnected = false;

        public bool childrenLost = false;
        public GameObject contextualPosition;

        public Queue<GameObject> vacantPositions;
        public Queue<POSITION_ASSIGN_DIRECTION> vacantDirections;

        [FormerlySerializedAs("playerNextPostitions")] [FormerlySerializedAs("playerNextPostions")] public List<GameObject> playerNextPositions;
        
        private float startTime;

        // Start is called before the first frame update
        void Start()
        {
            playerFishAttached = 0;
            if (isPlayer)
            {
                playerFishAttached = 0;
                state = FISH_STATE.COLLECTED;
                assignmentDirection = POSITION_ASSIGN_DIRECTION.UP;
                //InstantiatePlayerPostitons();
            }
            else
            {
                fishAttached = 0;
                state = FISH_STATE.UNCOLLECTED;
            }

            fishAttached = 0;
            SpringConnected = false;
            
            childrenFish = new List<GameObject>();
            vacantPositions = new Queue<GameObject>();
            playerNextPositions = new List<GameObject>();
            vacantDirections = new Queue<POSITION_ASSIGN_DIRECTION>();
        }
        
        
        // Update is called once per frame
        void Update()
        {
            if (playerNextPositions.Count <= 0)
            {
                InstantiatePlayerPostitons();
            }
            
            if (fishAttached > 0)
                fishAttached = 0;

            if (playerFishAttached < 0)
                playerFishAttached = 0;
        }

        private void OnTriggerEnter(Collider other)
        { 
            if (state == FISH_STATE.UNCOLLECTED) return;
            
            TestFishBehaviour testFishBeh = other.gameObject.GetComponent<TestFishBehaviour>();
            if (testFishBeh != null)
            {
                AttachFishToSchool(testFishBeh);
            }
        }

        //teleports the gameobject to the position, then it connects a spring to it
        public void ConnectSpring(GameObject objToTeleportTo, GameObject rigidBodyObject)
        {
            Debug.Log("Connect Spring Called");
            if (!SpringConnected)
            {
                transform.position = objToTeleportTo.transform.position;
                contextualPosition = objToTeleportTo;
            
                SpringConnected = true;
            
                springJoint = gameObject.AddComponent<SpringJoint>();
                Debug.Log("Spring Joint Added");
                springJoint.anchor = Vector3.zero;
                springJoint.connectedBody = rigidBodyObject.GetComponent<Rigidbody>();
                springJoint.connectedAnchor = rigidBodyObject.transform.position;
                springJoint.spring = 300;
                springJoint.damper = 10;
                springJoint.enableCollision = false;
                springJoint.tolerance = Random.Range(0.025f, 0.1f);
            }
        }

        public void ConnectSpringWithOffset(GameObject objToTeleportTo, Vector3 positionOffset)
        {
            if (!SpringConnected)
            {
                transform.position = objToTeleportTo.transform.position + positionOffset;
            
                contextualPosition = objToTeleportTo;
                
                SpringConnected = true;
            
                springJoint = this.gameObject.AddComponent<SpringJoint>();
                springJoint.anchor = Vector3.zero;
                springJoint.connectedBody = objToTeleportTo.GetComponent<Rigidbody>();
                springJoint.connectedAnchor = objToTeleportTo.transform.position;
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

        //spawns in the next two positions for the next fish to go to
        public void InstantiateNextFishPositions(POSITION_ASSIGN_DIRECTION assignDirection)
        {
            SetPositionDirection(assignDirection);
            
            schoolPositionOne = new GameObject();
            schoolPositionOne.name = "Next Position 1";
            schoolPositionOne.transform.parent = transform;
            schoolPositionOne.transform.position = transform.position + FishDirectionOffsetVector.Item1;

            schoolPositionTwo = new GameObject();
            schoolPositionTwo.name = "Next Position 2";
            schoolPositionTwo.transform.parent = transform;
            schoolPositionTwo.transform.position = transform.position + FishDirectionOffsetVector.Item2;
        }

        public void InstantiatePlayerPostitons()
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject nextObj = Instantiate(new GameObject("Next Position " + i));
                nextObj.transform.parent = transform;
                playerNextPositions[i] = nextObj;
                switch (i)
                {
                    case 0:
                    {
                        playerNextPositions[i].transform.position =
                            transform.position + new Vector3(0f, 2.5f, 0f);
                        break;
                    }
                    case 1:
                    {
                        playerNextPositions[i].transform.position =
                            transform.position + new Vector3(3, 1, 0f);
                        break;
                    }
                    case 2:
                    {
                        playerNextPositions[i].transform.position =
                            transform.position + new Vector3(3, -1, 0f);
                        break;
                    }
                    case 3:
                    {
                        playerNextPositions[i].transform.position =
                            transform.position + new Vector3(0f, -2.5f, 0f);
                        break;
                    }
                    case 4:
                    {
                        playerNextPositions[i].transform.position =
                            transform.position + new Vector3(-3, -1f, 0f);
                        break;
                    }
                    case 5:
                    {
                        playerNextPositions[i].transform.position =
                            transform.position + new Vector3(-3, 1f, 0f);
                        break;
                    }
                }
            }
        }

        public void MakeMyselfCollected()
        {
            state = FISH_STATE.COLLECTED;
        }

        public void SetParentAndChildren(TestFishBehaviour parent)
        {
            parentFish = parent.gameObject;
            parent.childrenFish.Add(gameObject);
        }

        public void AttachFishToSchool(TestFishBehaviour fishToAttach)
        {
            Debug.Log(playerFishAttached + "playerfishattached");
            Debug.Log(fishAttached+ " fish attached");
            if (fishToAttach.state == FISH_STATE.UNCOLLECTED)
            {
                if (isPlayer) //player fish
                {
                    if (!childrenFish.Contains(fishToAttach.gameObject))
                    {
                        bool fishAttachedLimit = playerFishAttached < 6;
                        
                        Debug.Log(fishAttachedLimit);
                        
                        switch (fishAttachedLimit)
                        {
                            case (true):
                            {
                                Debug.Log("Case is True");
                                
                                if (childrenLost)
                                {
                                    fishToAttach.ConnectSpring(vacantPositions.Dequeue(), this.gameObject);
                                    fishToAttach.InstantiateNextFishPositions(vacantDirections.Dequeue());
                                    if (vacantPositions.Count == 0)
                                    {
                                        childrenLost = false;
                                    }
                                }
                                else
                                {
                                    Debug.Log("No children lost, and the next line is to connect spring");
                                    GameObject nextObj = playerNextPositions[playerFishAttached];
                                    fishToAttach.ConnectSpring(nextObj, this.gameObject);
                                    fishToAttach.InstantiateNextFishPositions(assignmentDirection);
                                    assignmentDirection++;
                                }

                                fishToAttach.MakeMyselfCollected();
                                fishToAttach.SetParentAndChildren(this);

                                //increase number of attached fish
                                playerFishAttached++;
                                break;
                            }
                            default:
                            {
                                return;
                            }
                        }
                    }
                }
                else //non player fish
                {
                    if (state == FISH_STATE.COLLECTED)
                    {
                        if (!childrenFish.Contains(fishToAttach.gameObject))
                        {
                            bool fishAttachedLimit = playerFishAttached < 2;
                            switch (fishAttachedLimit)
                            {
                                case true:
                                {
                                    if (childrenLost)
                                    {
                                        fishToAttach.ConnectSpring(vacantPositions.Dequeue(), gameObject);
                                        if (vacantPositions.Count == 0)
                                        {
                                            childrenLost = false;
                                        }
                                    }
                                    else
                                    {
                                        fishToAttach.ConnectSpring(NextSchoolPosition, gameObject);
                                    }

                                    fishToAttach.InstantiateNextFishPositions(assignmentDirection);
                                    fishToAttach.MakeMyselfCollected();
                                    fishToAttach.SetParentAndChildren(this);

                                    //increase number of attached fish
                                    fishAttached++;
                                    break;
                                }
                                default:
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void DetachFishFromSchool(TestFishBehaviour fishToDetach)
        {
            TestFishBehaviour parentFishBehaviour = fishToDetach.parentFish.GetComponent<TestFishBehaviour>();
            parentFishBehaviour.childrenLost = true;

            if (parentFishBehaviour.isPlayer)
            {
                parentFishBehaviour.playerFishAttached -= (playerFishAttached > 0 )? 1: 0;

                parentFishBehaviour.childrenFish.Remove(fishToDetach.gameObject);
                parentFishBehaviour.vacantDirections.Enqueue(fishToDetach.assignmentDirection);
                parentFishBehaviour.vacantPositions.Enqueue(fishToDetach.contextualPosition);
            }
            else
            {
                parentFishBehaviour.fishAttached -= (parentFishBehaviour.fishAttached > 0)? 1 : 0;
                
                parentFishBehaviour.childrenFish.Remove(fishToDetach.gameObject);
                parentFishBehaviour.vacantPositions.Enqueue(fishToDetach.contextualPosition);
            }
        }
        

        //intended to be a routine that the fish activate when they are collected
        private IEnumerator JoinTheSchoolRoutine()
        {
            yield return null;
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
        
        //Returns the gameobject for the next fish to attach to
        public GameObject NextSchoolPosition
        {
            get
            {
                if (fishAttached == 0)
                {
                    return schoolPositionOne;
                }

                if (fishAttached == 1)
                {
                    return schoolPositionTwo;
                }

                return null;
            }
        }
    }
}