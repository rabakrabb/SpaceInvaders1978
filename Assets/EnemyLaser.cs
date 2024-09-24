using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
 
    //[SerializeField] Rigidbody2D rBody;
    [SerializeField] float missileSpeed = 6.0f;
    [SerializeField] float enemyMissile;
    
    void Start()
    {
        //rBody = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector3 direction)
    {
        //rBody.velocity = direction * missileSpeed;
        Destroy(gameObject, 3.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * missileSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            //Reset game!
        }
        if (collision.tag == "Meteor")
        {
            Destroy(gameObject);
        }

    }
}






/*
    private float laserTime;
    private float counter;
    public float laserSpeed = 6.0f;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] Transform enemyLaserOrigin;
    [SerializeField] Rigidbody2D rBody;

    private void Start()
    {
        NewTime();
        rBody = GetComponent<Rigidbody2D>();

    }
    public void Launch(Vector2 direction)
    {
        rBody.velocity = direction * laserSpeed;
        Destroy(gameObject, 3.0f);
    }

    void NewTime()
    {
        counter = 0;
        laserTime = Random.Range(1.0f, 4.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * laserSpeed * Time.deltaTime);

        counter += Time.deltaTime;
        if (counter >= laserTime)
        {
            //GameObject laserInstance = Instantiate(gameObject, transform.position, Quaternion.identity);
            //EnemyLaser enemyLaserPrefab = laserInstance.GetComponent<EnemyLaser>();
            Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
            
            /*enemyLaserPrefab.Launch(transform.TransformDirection(Vector2.down));
            {

            }
            NewTime();
        }
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            //reset the game!
        }
        if (collision.tag == "Meteor")
        {
            Destroy(gameObject);
        }
    }
}
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   transform.Translate(Vector2.down * speed * time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}*/


