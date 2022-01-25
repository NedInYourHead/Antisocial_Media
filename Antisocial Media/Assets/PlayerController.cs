using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.002f;
    
    private float rotation = 0.0f;
    [SerializeField] private float rotationSpeed = 0.8f;

    private float vertical;

    [SerializeField] private Transform range;
    [SerializeField] private GameObject monster;

    private bool firing = false;

    void Update()
    {
        /*if (Physics.Linecast(transform.position, range.position))
        {*/
        //Debug.Log(Physics.Linecast(transform.position, range.position));
            if (Input.GetKeyDown("space"))
            {
                if (Physics.Linecast(transform.position, range.position, 3, QueryTriggerInteraction.Collide))
                {
                    Debug.Log("Fire");
                    firing = true;
                }
            }
            else
            {
                firing = false;
            }
        /*}*/
    }

    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");

        rotation += Input.GetAxis("Horizontal");

        transform.position = transform.position + (transform.forward * vertical * speed);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f) * rotationSpeed);


    }

    void OnTriggerEnter(Collider monster) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/Scenes/MenuScreen.unity");
    }
}
