using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        //Add a listener to the OnSpacePressed event.
        //When the space key is pressed.
        //the LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void LaunchBall()
    {
        //ForceMode.Impulse applies an instant force change
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse );
    }
}
