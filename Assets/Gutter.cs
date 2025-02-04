using UnityEngine;

public class Gutter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider triggeredBody)
    {
        //Debug.Log("Ball entered the gutter!");
        if (!triggeredBody.CompareTag("Ball")) return;
        //first get the rigidbody of the ball
        //store it in a local variable ballRigidBody
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
        if (ballRigidBody == null) return;
        //store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        //reset the linear and angular velocity
        //cuz the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        //add force in the forward direction of the gutter
        //use the cached velocity magnitude to keep it a little realistic
        ballRigidBody.AddForce(transform.up * velocityMagnitude, ForceMode.VelocityChange);
    }
}
