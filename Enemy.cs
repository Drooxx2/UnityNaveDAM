using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float limit = 6f;
    bool isRight;

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.5f, 0.5f);
    }

    void MoveEnemy()
    {
        if (transform.position.x >= limit)
            isRight = true;
        else if (transform.position.x <= -limit)
            isRight = false;

        if(isRight)
            transform.Translate(-transform.right);
        else if(!isRight)
            transform.Translate(transform.right);
    }
}
