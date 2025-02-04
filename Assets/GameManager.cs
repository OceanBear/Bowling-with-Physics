using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    /*
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    */

    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    private GameObject pinObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        // Find all objects of type FallTrigger
        
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);
        foreach(FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
         
        //inputManager.OnResetPressed.AddListener(HandleReset);
        //SetPins();
    }

    /*
    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }
     */

    /*
         private void SetPins()
    {
        if (pinObjects)
        {
            foreach(Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }
        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
     */

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
