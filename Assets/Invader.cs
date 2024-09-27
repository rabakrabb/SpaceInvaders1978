using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Invader : MonoBehaviour
{
    [SerializeField] UnityEvent ScoreUpdated;
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;

    public System.Action killed;

    private SpriteRenderer spriteRenderer;

    private int animationFrame;
    [SerializeField] GameObject player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    private void AnimateSprite()
    {
        if (animationSprites.Length == 0) return;
        
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            this.ScoreUpdated.Invoke();
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Planet"))
        {
            Debug.Log("Invader har nått planeten!");
            PlayerHealth playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
            
            if (playerHealth != null)
            {
                Debug.Log("PlayerHealth komponent hittad!");
                playerHealth.TakeDamage(1);
                Destroy(gameObject);  // Bekräfta att invadern förstörs
                Debug.Log("Invader förstörd efter att ha nått planeten!");
            }
            else
            {
                Debug.Log("PlayerHealth komponent saknas på planeten!");
            }
        }
    }
}
