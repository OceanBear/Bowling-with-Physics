using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
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
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        //inputManager.OnSpacePressed.AddListener(Resetball);
        //transform.parent = ballAnchor;
        //transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        Debug.Log($"BallAnchor: {ballAnchor}");
        //ResetBall();
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
        Debug.Log($"Launch Direction: {launchIndicator.forward}");
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
        //ResetBall();
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
