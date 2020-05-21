using BeauxBehaviours;
using UnityEngine;

namespace Emmanuel
{
    public class CameraCheckpointBehaviour : MonoBehaviour
    {
        public bool adjustCameraMovementSpeed;

        public float newCameraMovementSpeed;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            CamMovementBehaviour camMovement = other.gameObject.GetComponent<CamMovementBehaviour>();
        
            if (camMovement != null)
            {
                //Update the cameras new checkpoint destination
                camMovement.UpdateDestination();
            
                //if true, then update the camera speed
                if (adjustCameraMovementSpeed) 
                    camMovement.SetSpeed(newCameraMovementSpeed);
            
            }
        
            
        }
    }
}
