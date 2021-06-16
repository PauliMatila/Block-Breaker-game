using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {       
        FindObjectOfType<GameSession>().LoseALifePoint();
        FindObjectOfType<Ball>().StartNewBall();
        if (GameSession.playerLives == 0)
        {
            SceneManager.LoadScene("Game Over");
        }        
    }
}
