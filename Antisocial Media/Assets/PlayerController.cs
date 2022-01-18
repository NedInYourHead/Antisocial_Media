using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.002f;
    
    private float rotation = 0.0f;
    [SerializeField] private float rotationSpeed = 0.8f;

    private float vertical;

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        
        rotation += Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f) * rotationSpeed);
        transform.position = transform.position + (transform.forward * vertical * speed);
    }
}
