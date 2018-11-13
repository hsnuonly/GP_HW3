using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Animator animator;
    public float speed;
    public float jumpPower;
    CapsuleCollider2D collider;
    public LayerMask layerMask;
    bool isJump = false;
    AudioSource audioSource;
    public AudioClip JumpAudio;
    bool immortal = false;
    Renderer renderer;
    public bool debugging = false;

    public float DeadFadeTime = 1f;

    bool climb = false;
    bool onStair = false;

    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        collider = this.GetComponent<CapsuleCollider2D>();
        audioSource = this.GetComponent<AudioSource>();
        renderer = this.GetComponent<Renderer>();

        Debug.Log(RecordManager.LastRecord);
        if (RecordManager.index >= 0)
            this.transform.position = RecordManager.LastRecord - (Vector3)collider.offset;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {

        float deltaX = Input.GetAxis("Horizontal");
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center, Vector2.down, 65535, layerMask);

        if (onStair)
        {
            if (!climb)
            {
                if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
                {
                    climb = true;
                    animator.SetBool("Climb", true);
                    rigidbody.gravityScale = 0;
                }
            }
            else
            {
                if (Input.GetAxis("Vertical") == 0) animator.speed = 0;
                else animator.speed = 1;
            }
            this.transform.Translate(0, Time.deltaTime * speed * Input.GetAxis("Vertical"), 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (hit.distance - collider.bounds.extents.y < 0.1)
            {
                rigidbody.AddForce(Time.deltaTime * jumpPower * Vector2.up);
                audioSource.PlayOneShot(JumpAudio);
            }
        }
        transform.Translate(Time.deltaTime * speed * new Vector3(deltaX, 0, 0));


        animator.SetFloat("SpeedX", Mathf.Abs(deltaX), 0f, Time.deltaTime);
        animator.SetFloat("SpeedY", rigidbody.velocity.y, 0f, Time.deltaTime);
        animator.SetFloat("DistToGround", hit.distance - collider.bounds.extents.y, 0f, Time.deltaTime);
        if (deltaX < 0)
            this.transform.localScale = new Vector3(-1, 1, 1);
        else if (deltaX > 0)
            this.transform.localScale = new Vector3(1, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (!debugging && !immortal && collision.gameObject.tag == "Enemy")
        {
            // renderer.material.shader = Shader.Find("Sprites/Diffuse");
            immortal = true;
            Invoke("immortalCoolDown", 2f);
            animator.SetTrigger("Hurt");
            rigidbody.AddForce(Time.deltaTime * jumpPower * Vector2.up);
            Destroy(collider);
            Invoke("DeadReload", DeadFadeTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Stair")
        {
            onStair = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        onStair = false;
        climb = false;
        animator.SetBool("Climb", false);
        rigidbody.gravityScale = 2;
        animator.speed = 1;
    }

    void immortalCoolDown()
    {
        immortal = false;
        renderer.material.shader = Shader.Find("Sprites/Default");
    }

    void DeadReload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
