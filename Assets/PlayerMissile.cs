using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rBody;
    [SerializeField] float missileSpeed = 5.0f;
    [SerializeField] float playerMissile;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //rBody.velocity = transform.right * bulletSpeed;
    }
    public void Launch(Vector2 dir)
    {
        rBody.velocity = dir * missileSpeed;
        Destroy(gameObject, 3.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Deal damage if hit
        Destroy(gameObject);
    }
}
