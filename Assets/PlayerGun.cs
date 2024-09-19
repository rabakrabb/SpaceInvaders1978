using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject playerMissilePrefab;
    [SerializeField] Transform missileOrigin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Shooting
        {
            GameObject missileInstance = Instantiate(playerMissilePrefab, missileOrigin.position, Quaternion.identity);
            PlayerMissile playerMissile = missileInstance.GetComponent<PlayerMissile>();
            playerMissile.Launch(transform.TransformDirection(Vector2.up));
            {

            }
        }
    }
}
