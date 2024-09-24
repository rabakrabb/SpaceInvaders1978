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

        private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= this.animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = this.animationSprites[animationFrame];
    }


    private void OnTriggerEnter2D(Collider2D other)    
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile")) {
            this.ScoreUpdated.Invoke();
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
        /*if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            ScoreUpdated.Invoke();
        }*/
    }
}