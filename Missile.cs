using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private GameObject spaceShip;
    private GameObject missileTrigger;
    private BoxCollider2D triggerCollider;
    private SpaceShipScript shipScript;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player");
        shipScript = spaceShip.GetComponent<SpaceShipScript>();
        missileTrigger = GameObject.Find("MissileTrigger");
        triggerCollider = missileTrigger.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == triggerCollider)
        {
            Destroy(gameObject);
        }

        shipScript.SetcanShot();
    }

    
}
