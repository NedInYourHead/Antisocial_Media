using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //forward/backward input and speed multiplier
    private float vertical;
    [SerializeField] private float speed = 0.002f;

    //rotation input and speed multiplier
    private float rotation = 0.0f;
    [SerializeField] private float rotationSpeed = 0.8f;
    

    // monster gameobject to use its box collider
    [SerializeField] private GameObject monster;



    //Raycast arguements
    [SerializeField] private float range = 10.0f;
    RaycastHit hit;
    [SerializeField] private Camera camera;
    //player hitbox isn't counted in the raycast collision
    [SerializeField] LayerMask rayCast;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, rayCast, QueryTriggerInteraction.Collide))
            {
                if (hit.transform.name == "Monster")
                {
                    FindObjectOfType<MonsterController>().Dying();
                    StartCoroutine(Flash());
                }
            }
        }
    }

    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");

        rotation += Input.GetAxis("Horizontal");

        transform.position = transform.position + (transform.forward * vertical * speed);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f) * rotationSpeed);


    }

    IEnumerator Flash()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;

    }

    void OnTriggerEnter(Collider col) 
    {
        if (col.transform.tag == "Monster")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/Scenes/MenuScreen.unity");
        }
        else if (col.transform.tag == "End")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/Scenes/WinScreen.unity");
        }

    }
}
