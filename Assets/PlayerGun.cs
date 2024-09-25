using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject playerMissilePrefab;
    [SerializeField] Transform missileOrigin;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject missileInstance = Instantiate(playerMissilePrefab, missileOrigin.position, Quaternion.identity);
            PlayerMissile playerMissile = missileInstance.GetComponent<PlayerMissile>();
            playerMissile.Launch(transform.TransformDirection(Vector2.up));
            {

            }
        }
    }
}
