using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float speed = 10.0f;
    private float xRange = 17.0f;

    public float zMin;
    public float zMax;

    public GameObject foodPrefabProjectile;
    public Transform foodPrefabProjectileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Player Horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        // Keep the player on the screen horizontally
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
       
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Player Vertical movement
        verticalInput = Input.GetAxis("Vertical");
        // Keep the player on the screen vertically 
        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }
        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Spawn food projectile when space pressed 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a food projectile from the player
            Instantiate(foodPrefabProjectile, foodPrefabProjectileSpawnPoint.position, foodPrefabProjectile.transform.rotation);

        }
    }
}
