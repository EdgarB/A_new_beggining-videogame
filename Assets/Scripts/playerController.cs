using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public float moveSpeed = 3.0f;
    public float speedLimit = 3.0f;
    public GameObject sceneManager;
    public GameObject gemParticles;
    public GameObject playerDeathParticles;
    private Rigidbody2D body;
    private Animator anim;
    // Use this for initialization
    void Awake () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
    void Start()
    {
        sceneManager = GameObject.FindWithTag("scene_manager");
    }

	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));


        float moveVelocityX = body.velocity.x + direction.x * moveSpeed;
        float moveVelocityY = body.velocity.y + direction.y * moveSpeed;

        if(Mathf.Abs(moveVelocityY) > speedLimit)
        {
            moveVelocityY = direction.normalized.y * speedLimit;
        }

        if (Mathf.Abs(moveVelocityX) > speedLimit)
        {
            moveVelocityX = direction.normalized.x * speedLimit;
        }

        anim.SetFloat("horizontal", direction.x);
        anim.SetFloat("vertical", direction.y);

        body.velocity = new Vector2(moveVelocityX, moveVelocityY);
       

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger!");
        if(col.gameObject.tag == "gem")
        {
            Debug.Log("Gem!");
            sceneManager.GetComponent<sceneManager>().recolectarGema();
            //Aparecer particulas gema con cierto tiempo de vida
            var particles = (GameObject) Instantiate(gemParticles, col.gameObject.transform.position, Quaternion.identity);
            //Desaparecer particulas despues de 5 segundos
            Destroy(particles, 3.0f);


            //Desaparecer gema
            Destroy(col.gameObject);


        }else if(col.gameObject.tag == "portal_out")
        {
            sceneManager.GetComponent<Fading>().changeToNextScene();
        }else if(col.gameObject.tag == "enemy")
        {

            
            var particles = (GameObject) Instantiate(playerDeathParticles, transform.position, transform.rotation);
            Destroy(particles, 3.0f);
            sceneManager.GetComponent<Fading>().resetCurrentScene();
            Destroy(gameObject);
        }
    }

}
