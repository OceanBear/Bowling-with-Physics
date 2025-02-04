using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    //name booleans like a question
    private bool isBallLaunched;
    private Rigidbody ballRB;
    [SerializeField] private InputManager inputManager;
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
        //transform.parent = ballAnchor;
        //transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        Debug.Log($"BallAnchor: {ballAnchor}");
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
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
        //ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        ResetBall();
    }
    public void ResetBall()
    {
        isBallLaunched = false;

        //Setting the ball to be a Kinematic Body
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        //transform.localPosition = Vector3.zero;
    }

}
