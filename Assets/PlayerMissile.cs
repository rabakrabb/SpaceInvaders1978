using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rBody;
    [SerializeField] float missileSpeed = 13.0f;
    [SerializeField] float playerMissile;
    private ScoreManager scoreManager;
    //public EnemyLaser enemyLaserPrefab;
    //public System.Action destroyed;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void Launch(Vector3 direction)
    {
        rBody.velocity = direction * missileSpeed;
        Destroy(gameObject, 3.0f);
    }

    /*private void Update()
    {
        this.transform.position += this.direction * this.missileSpeed * Time.deltaTime
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this.destroyed.Invoke();
        Destroy(collision.gameObject);
        scoreManager.UpdateScore(10);
        Destroy(gameObject);
    }
}
