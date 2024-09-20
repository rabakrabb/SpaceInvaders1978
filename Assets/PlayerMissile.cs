using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rBody;
    [SerializeField] float missileSpeed = 5.0f;
    [SerializeField] float playerMissile;
    public System.Action destroyed;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 dir)
    {
        rBody.velocity = dir * missileSpeed;
        Destroy(gameObject, 3.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.destroyed.Invoke();
        Destroy(gameObject);
    }
}
