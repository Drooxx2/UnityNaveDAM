using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public int speed = 0;
    public GameObject missilePrefab;
    private Rigidbody2D _Rigidbody2D;
    private Rigidbody2D rbmissile;
    private GameObject missile;
    private bool canShoot = true;



    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement of the ship
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        _Rigidbody2D.velocity = movement * speed;

        //Limit of the ship on the screen
        float xPos = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
        float yPos = Mathf.Clamp(transform.position.y, -8f, 8f);
        transform.position = new Vector2(xPos, yPos);

        //Shoot a missile
        if (Input.GetButton("Jump") && canShoot)
        {
            Debug.Log("Disparo!");
            Vector2 missileSpawnPosition = new Vector2(transform.position.x, transform.position.y + 1.5f);
            missile = Instantiate(missilePrefab, missileSpawnPosition, Quaternion.identity);
            rbmissile = missile.GetComponent<Rigidbody2D>();
            rbmissile.AddForce(new Vector2(0, 1000));
            canShoot = false;
        }
    }

    
    public void SetcanShot()
    {
        canShoot = true;
    }
}
