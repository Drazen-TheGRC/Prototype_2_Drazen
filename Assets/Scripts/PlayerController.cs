using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x < -14 )
        {
            transform.position = new Vector3(-14, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 14)
        {
            transform.position = new Vector3(14, transform.position.y, transform.position.z);
        }
       
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}
