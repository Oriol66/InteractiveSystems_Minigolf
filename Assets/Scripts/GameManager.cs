using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text collisionCountText;
    public Text timerText;
    public Text gameOverText;
    public AudioSource cameraAudioSource;

    private int collisionCount = 0;
    private float elapsedTime = 0f;
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
        gameOverText.gameObject.SetActive(false);

        //Reproduce background music from the start
        SoundManager.Instance.PlayBackgroundMusic();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            //Increments the time elapsed and updates the canvas clock
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void IncrementCollisionCount()
    {
        if (!isGameOver)
        {
            //Increments the number of collisions and updates the canvas count
            collisionCount++;
            UpdateCollisionCountText();
        }
    }

    private void UpdateCollisionCountText()
    {
        if (collisionCountText != null)
        {
            collisionCountText.text = "Swings Count: " + collisionCount.ToString();
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 100F) % 100F);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    public void YouWin()
    {
        isGameOver = true;
        gameOverText.text = "CONGRATULATIONS! YOU COMPLETE\nTHE LEVEL";
        gameOverText.gameObject.SetActive(true);

        //Stop playing background music and play final music
        SoundManager.Instance.StopBackgroundMusic();
        SoundManager.Instance.PlayYouWinMusic();
    }

}

