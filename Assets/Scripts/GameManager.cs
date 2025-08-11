using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score ELements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighScoreText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;

    private AudioSource audioSource;


    private void Awake()
    {
        gameOverPanel.SetActive(false);  //Deactivate on awake
        GetHighScore();
        audioSource=GetComponent<AudioSource>();
    }

    private void GetHighScore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");  //stores player prefs
        highScoreText.text = "Best:" + highscore;
    }

    public void IncreaseScore(int points)
    {
        score += points;  //increase by 2 or pitns

        scoreText.text=score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Best:" +score.ToString();
        }

    }

    public void OnBombHit()
    {
        Time.timeScale = 0; //stops reduce the speed

        gameOverPanelScoreText.text="Your Score is : " +score.ToString();
        gameOverPanelHighScoreText.text = "Best:" + highscore.ToString();
        gameOverPanel.SetActive(true);
        Debug.Log("Bomb was sliced");
    }


    public void RestartGame() {

        score = 0;
        scoreText.text=score.ToString();

        gameOverPanel.SetActive(false);
     //   gameOverPanelScoreText.text = "Score : 0";

        //Destroy all game objects
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;

    }

    public void PlayRandomSLiceSound()
    {

        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
