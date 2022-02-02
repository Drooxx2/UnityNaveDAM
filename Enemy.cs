using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public GameObject gameManager;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = gameManager.GetComponent<GameManager>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            _gameManager.GameOver = true;
        }
        else
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            _gameManager.GameWin = true;
        }
    }
}
