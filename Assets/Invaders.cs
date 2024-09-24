using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public PlayerMissile laserPrefab;
    //public float laserAttackRate = 1.0f;

    public int amountKilled {  get; private set; }
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;

    private Vector3 direction = Vector2.right;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 1.0f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.killed += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += col * 1.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        //InvokeRepeating(nameof(LaserAttack), this.laserAttackRate, this.laserAttackRate);
    }
    private void Update()
    {
        this.transform.position += direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);


        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 0.5f)){
                AdvanceRow();
            } else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 0.5f)){
                AdvanceRow();
            }
        }

    }

    private void AdvanceRow()
    {
        direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 0.2f;
        this.transform.position = position; 
    }

    /* private void LaserAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            if (Random.value < (1.0f / (float)this.amountAlive)){
                Instantiate(this.laserPrefab, invader.position, Quaternion.identity);
                break; }
            }
        }*/
    private void InvaderKilled()
    {
        this.amountKilled++;
    }
    
}
