using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.002f;
    
    private float rotation = 0.0f;
    [SerializeField] private float rotationSpeed = 0.8f;

    private float vertical;

    [SerializeField] private GameObject monster;

    private bool firing = false;

    [SerializeField] private float range = 10.0f;
    RaycastHit hit;
    public Camera camera;

    [SerializeField] LayerMask rayCast;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, rayCast, QueryTriggerInteraction.Collide))
            {
                if (hit.transform.name == "Monster")
                {
                    Debug.Log("Hit Monster");
                    firing = true;
                }
            }
        }
        else
        {
            firing = false;
        }
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
