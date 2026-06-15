using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Pins")]
    public GameObject[] pins;
    private Vector3[] pinStartPositions;
    private Quaternion[] pinStartRotations;

    [Header("Ball")]
    public GameObject ball;
    private Vector3 ballStartPosition;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public GameObject endGamePanel;
    public TextMeshProUGUI finalScoreText;

    [Header("Game State")]
    int totalScore = 0;
    int currentRound = 1;
    int currentAttempt = 1;
    int pinsKnockedThisAttempt = 0;
    int pinsKnockedThisRound = 0;
    private bool roundEnding = false;
    void Start()
    {
        pinStartPositions = new Vector3[pins.Length];
        pinStartRotations = new Quaternion[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            pinStartPositions[i] = pins[i].transform.position;
            pinStartRotations[i] = pins[i].transform.rotation;
        }

        ballStartPosition = ball.transform.position;
        endGamePanel.SetActive(false);
        UpdateUI();
    }

    public void PinKnocked()
{
    pinsKnockedThisAttempt++;
    pinsKnockedThisRound++;
    totalScore++;
    scoreText.text = "Score: " + totalScore;

    if (!roundEnding && currentAttempt == 1 && pinsKnockedThisRound >= 10)
    {
        roundEnding = true;
        Invoke("NextRound", 2f);
    }
    else if (!roundEnding && currentAttempt == 2 && pinsKnockedThisRound >= 10)
    {
        roundEnding = true;
        Invoke("NextRound", 2f);
    }
}

    public void BallStopped()
{
    if (!roundEnding && currentAttempt == 1 && pinsKnockedThisRound < 10)
    {
        roundEnding = true;
        Invoke("NextAttempt", 2f);
    }
    else if (!roundEnding && currentAttempt == 2)
    {
        roundEnding = true;
        Invoke("NextRound", 2f);
    }
}

    void NextAttempt()
{
    roundEnding = false;
    currentAttempt = 2;
    pinsKnockedThisAttempt = 0;
    ResetBall();
    UpdateUI();
}

    void NextRound()
{
    roundEnding = false;
    if (currentRound >= 3)
    {
        EndGame();
        return;
    }

    currentRound++;
    currentAttempt = 1;
    pinsKnockedThisAttempt = 0;
    pinsKnockedThisRound = 0;
    ResetBall();
    ResetPins();
    UpdateUI();
}

    void ResetPins()
{
    for (int i = 0; i < pins.Length; i++)
    {
        pins[i].SetActive(true);
        pins[i].transform.position = pinStartPositions[i];
        pins[i].transform.rotation = pinStartRotations[i];
        pins[i].GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        pins[i].GetComponent<PinScore>().ResetPin();
    }
}

    void ResetBall()
    {
        ball.transform.position = ballStartPosition;
        ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void EndGame()
    {
        endGamePanel.SetActive(true);
        finalScoreText.text = "Final Score: " + totalScore;
        roundText.gameObject.SetActive(false); 
        scoreText.gameObject.SetActive(false); 
    }

    void UpdateUI()
    {
        roundText.text = "Round: " + currentRound + " Attempt: " + currentAttempt;
    }

    public void RestartGame()
    {
        totalScore = 0;
        currentRound = 1;
        currentAttempt = 1;
        pinsKnockedThisAttempt = 0;
        pinsKnockedThisRound = 0;
        ResetPins();
        ResetBall();
        endGamePanel.SetActive(false);
        UpdateUI();
        scoreText.text = "Score: 0";
        roundText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}