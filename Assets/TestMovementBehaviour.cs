using System;
using UnityEngine;

public class TestMovementBehaviour : MonoBehaviour
{
    public float MaximumYVelocity;
    public float MaximumXVelocity;

    public float speed;
    public float speedMultiplier;
    
    private Rigidbody rb;
    
    private float yDrag;
    
    private float xDrag;
    private float dragTolerance = 0.005f;

    Vector3 velocity = new Vector3(0,0,0);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");


        velocity = new Vector3(horizontalInput, verticalInput, 0);
        
        
        //if up and down arent pressed
        if (verticalInput == 0)
        {
            if (Math.Abs(yDrag) > dragTolerance)
            {
                yDrag += dragTolerance;
            }
            else
            {
                yDrag = 1;
            }
        }
        else
        {
            if (Math.Abs(yDrag) < 0)
            {
                yDrag -= dragTolerance;
            }
            else
            {
                yDrag = 0;
            }
        }
        
        //if left and right arent pressed
        if (horizontalInput == 0)
        {
            if (Math.Abs(xDrag) > dragTolerance)
            {
                xDrag += dragTolerance;
            }
            else
            {
                xDrag = 1;
            }
        }
        else
        {
            if (Math.Abs(xDrag) < 0)
            {
                xDrag -= 0.001f;
            }
            else
            {
                xDrag = 0;
            }
        }

        velocity.x *= 1 - xDrag;
        velocity.y *= 1 - yDrag;
        
        rb.velocity = (speed * speed * speedMultiplier) * Time.fixedDeltaTime * velocity;

        //transform.position += speed * Time.fixedDeltaTime * new Vector3(Input.GetAxis("Horizontal"), 0,0);
        //transform.position += speed * Time.fixedDeltaTime * new Vector3(0, Input.GetAxis("Vertical"),0);

    }
}
