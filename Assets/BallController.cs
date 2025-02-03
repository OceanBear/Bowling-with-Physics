using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    //name booleans like a question
    private bool isBallLaunched;
    private Rigidbody ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isBallLaunched = false;
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
        if (isBallLaunched == true) return;
        //ForceMode.Impulse applies an instant force change
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse );
    }
}
