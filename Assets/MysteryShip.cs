using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    public float speed = 8f;
    public float moveDirection = 1f;
    public float lifespan = 4f;
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * moveDirection * Time.deltaTime);

        if (transform.position.x >= Camera.main.orthographicSize * Camera.main.aspect ||
            transform.position.x <= -Camera.main.orthographicSize * Camera.main.aspect)
        {
            moveDirection *= -1;
        }
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                scoreManager.UpdateScore(100);
                Debug.Log("Mystery Ship träffades av spelaren!");
            }
            else
            {
                Debug.LogError("ScoreManager är inte tilldelad i MysteryShip!");
            }

            Destroy(gameObject);
        }
    }

}
