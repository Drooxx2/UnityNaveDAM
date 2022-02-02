using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    #region GameOver
    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }
    #endregion
    #region GameWin
    private bool gameWin = false;
    public bool GameWin
    {
        get { return gameWin; }
        set { gameWin = value; }
    }
    #endregion

    public GameObject gameOverText;
    public GameObject gameWinText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        gameWinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }else if (GameWin)
        {
            Time.timeScale = 0;
            gameWinText.SetActive(true);
        }
    }
}
