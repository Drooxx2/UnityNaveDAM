using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isRight = true;
    float limit = 6f;
    public GameObject gameManager;
    private GameManager _gameManager;

    #region Sleep
    private float sleep = 0.7f;
    private float minSleep = 0.2f;
    public float Sleep
    {
        get { return sleep; }
        set { sleep = (value < minSleep) ? minSleep : value; }
    }
    #endregion
    

    void Start()
    {
        _gameManager = gameManager.GetComponent<GameManager>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Sleep);
        MoveEnemy();
        StartCoroutine(Wait());
    }

    void MoveEnemy()
    {
        if (isRight)
        {
            if(transform.position.x >= limit)
            {
                Sleep -= 0.05f;
                isRight = false;
                transform.Translate(Vector2.down);
            }
            else
            {
                transform.Translate(Vector2.right);
            }
        }
        else
        {
            if(transform.position.x <= -limit)
            {
                Sleep -= 0.05f;
                isRight = true;
                transform.Translate(Vector2.down);
            }
            else
            {
                transform.Translate(Vector2.left);
            }
        }
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
