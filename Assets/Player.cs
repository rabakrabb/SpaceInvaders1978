using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed = 4f;
    Rigidbody2D rBody;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero; //Vector2(0,0)

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1.0f; //Vector2(1,0)
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1.0f;
        }

        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
    }
}
