using System.Collections;
using UnityEngine;

namespace Emmanuel
{
    public class TestCollectBehaviour : MonoBehaviour
    {
        //THE INTENDED BEHAVIOUR
        /*
         
         ///COLLECTION
         1. WHEN THE SCHOOL RUNS INTO THE FISH, IT WILL COLLECT -- need to get the collision to register
         2. WHEN IT COLLECTS, THE FISH WILL BE ASSIGNED TO A NODE
         3. WHEN IT IS ASSIGNED TO A NODE, IT WILL SLERP TO A POSITION
         4. WHEN IT SLERPS, IT WILL SLERP TO A POSITION THATS -4 IN THE X OF ITS PARENT NODE
         5. ONCE IT GETS WITHIN TOLERANCE DISTANCE OF Z (WHICH IS 5) IT WILL STOP THE SLERP
         6. ONCE IT STOPS SLERPING, IT WILL ATTACH A SPRING TO ITSELF AND ITS PARENT 
         
         ///LOSING FISH
         1. WHEN THE SCHOOL GETS DAMAGED, IT WILL GET A NODE FROM THE END, THE OTHER FISH WILL PLAY THE HURT ANIMATION
         2. WHEN IT GETS A NODE FROM THE END, THE FISH WILL BE DETACHED
         3. WHEN THE FISH IS DETACHED, IT WILL FLIP UPSIDE DOWN
         4. WHEN IT IS FLIPPED UPSIDE DOWN, IT WILL FLOAT UPWARD
    
         * */
         
        
        /// <summary>
        /// Number of rows away from the first fish
        /// </summary>
        public int numOfRows;

        /// <summary>
        /// number of fish in a row
        /// </summary>
        public int rowLength;
        
        /// <summary>
        /// the lead fish that the player directly controls
        /// </summary>
        [SerializeField] private GameObject mainPlayer;
        
        /// <summary>
        /// chain system to keep track of the fist
        /// </summary>
        private ChainSystem<GameObject> chainSystem;
        
        ////////////////THE SPRING DATA WILL GO HERE/////////////////
        
        
        /////////////////////////////////////////////////////////////

        // Start is called before the first frame update
        void Start()
        {
            GlobalFishController.fishChainSystem = new ChainSystem<GameObject>(mainPlayer, numOfRows, rowLength);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void AssignFishToSchool()
        {
            
        }

    }
}
