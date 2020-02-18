using UnityEngine;

namespace Flocking
{
    [RequireComponent(typeof(Collider))]
    public class FlockAgent : MonoBehaviour
    {
        private Flock agentFlock;
        public Flock AgentFlock {get { return agentFlock; }}
        
        
        private Collider agentCollider;
        public Collider AgentCollider { get { return AgentCollider; } }

        // Start is called before the first frame update
        void Start()
        {
            agentCollider = GetComponent<Collider>();
        }

        public void Initialize(Flock flock)
        {
            agentFlock = flock;
        }

        public void Move(Vector3 velocity)
        {
            transform.forward = velocity;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
