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

    //post/upload variables
    [SerializeField] Sprite[] spriteList;
    [SerializeField] SpriteRenderer postRenderer;
    [SerializeField] SpriteRenderer upload;
    [SerializeField] private int postCooldown = 8;
    private bool postOnCooldown = false;
    private bool endOfCooldown = false;
    int pictureIndex = 0;
    [SerializeField] private float fadeSpeed = 1f;
    private float alpha = 1f;
    Color newColor = new Color(1f, 1f, 1f, 1f);
    

    void Update()
    {
        if (!postOnCooldown)
        {

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, rayCast, QueryTriggerInteraction.Collide))
            {
                if (hit.transform.name == "Monster")
                {
                    upload.enabled = true;
                    if (Input.GetKeyDown("space"))
                    {
                        FindObjectOfType<MonsterController>().Dying();
                        upload.enabled = false;
                        StartCoroutine(UploadCooldown());
                        postRenderer.sprite = spriteList[pictureIndex];
                        pictureIndex += 1;

                        if (pictureIndex == spriteList.Length)
                        {
                            pictureIndex = 0;
                        }
                    }
                }
                else
                {
                    upload.enabled = false;
                }
            }
        }
    }

    IEnumerator UploadCooldown()
    {
        postOnCooldown = true;
        postRenderer.enabled = false;
        yield return new WaitForSeconds(postCooldown);
        alpha = 0f;
        endOfCooldown = true;
        postRenderer.enabled = true;
    }


    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");

        rotation += Input.GetAxis("Horizontal");

        transform.position = transform.position + (transform.forward * vertical * speed);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f) * rotationSpeed);


        if (endOfCooldown)
        {
            alpha += fadeSpeed * Time.deltaTime;
            newColor.a = alpha;
            if (alpha >= 1f)
            {
                endOfCooldown = false;
                postOnCooldown = false;
            }
            postRenderer.color = newColor;
        }
    }

    void OnTriggerEnter(Collider col) 
    {
        if (col.transform.tag == "Monster")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/Scenes/DeathScreen.unity");
        }
        else if (col.transform.tag == "End")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/Scenes/WinScreen.unity");
        }

    }

    private void Start()
    {
        postRenderer.sprite = spriteList[pictureIndex];
        pictureIndex += 1;
        if (pictureIndex == spriteList.Length)
        {
            pictureIndex = 0;
        }
    }
}
