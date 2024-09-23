//Lucas Lovellette
//09/21/2024
// PlayerController.cs
// Controls the player's movement, handles collecting pickups, and manages game states (win/lose).
// Includes a countdown timer, win/loss conditions, and a restart option.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For restarting the game

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    public Text timerText; // Timer display
    public GameObject restartButton; // Restart button

    private float timer = 60f;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
        restartButton.SetActive(false); // Hide the restart button at the start
    }

    // FixedUpdate is in sync with the physics engine
    void FixedUpdate()
    {
        if (!gameOver)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Player movement using velocity
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.velocity = movement * speed;

            // Timer countdown
            timer -= Time.deltaTime;
            int seconds = Mathf.CeilToInt(timer);
            timerText.text = "Time: " + seconds.ToString();

            // Lose condition: if time runs out
            if (seconds <= 0)
            {
                gameOver = true;
                winText.text = "You lose!";
                rb2d.velocity = Vector2.zero; // Stop player movement
                restartButton.SetActive(true); // Show the restart button
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameOver && other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // disappear from scene
            count++;
            countText.text = "Count: " + count.ToString();
        }

        // Win condition: Collect all pickups
        if (count >= 12)
        {
            gameOver = true;
            winText.text = "You win!";
            rb2d.velocity = Vector2.zero; // Stop player movement
            restartButton.SetActive(true); // Show the restart button
        }
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
