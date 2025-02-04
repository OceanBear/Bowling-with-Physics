using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Find all objects of type FallTrigger
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);
        foreach(FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        if (pinObjects)
        {

        }
    }

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
