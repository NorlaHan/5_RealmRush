using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip enemyBreachSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBase>())
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(enemyBreachSFX);

            playerHealth -= other.GetComponent<EnemyBase>().GetDamage();
            healthText.text = playerHealth.ToString();
        }
    }

    public void GetScore(int score) {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    private void Awake()
    {
        if (!healthText)
        {
            healthText = GameObject.Find("HealthText").GetComponent<Text>();
        }
        if (!scoreText)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
    }



    private void Start()
    {
        healthText.text = playerHealth.ToString();
        scoreText.text = playerScore.ToString();
    }


}
