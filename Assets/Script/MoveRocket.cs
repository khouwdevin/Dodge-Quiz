using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject circle, dot, rocket;

    [SerializeField]
    public Animator animator;

    [SerializeField]
    private Text healt_text;

    private Rigidbody2D rb;

    private float speed;

    private Touch joystick;

    private Vector2 touchPos;

    private Vector2 moveDir;

    public static bool gyroenable;

    public static Gyroscope gyro;

    public AudioSource move_audio, hit_audio;

    [SerializeField]
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circle.SetActive(false);
        dot.SetActive(false);

        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        healt_text.text = "Health : " + health;

        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if (gyroenable)
        {
            circle.SetActive(false);
            dot.SetActive(false);

            gyro = Input.gyro;
            gyro.enabled = true;
            TransRocketGyro();
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
            move_audio.Play();
        }

        else {

            gyro = Input.gyro;
            gyro.enabled = false;

            if (Input.touchCount > 0)
            {
                joystick = Input.GetTouch(0);

                touchPos = Camera.main.ScreenToWorldPoint(joystick.position);

                if (joystick.phase == TouchPhase.Began)
                {
                    circle.SetActive(true);
                    dot.SetActive(true);

                    circle.transform.position = touchPos;
                    dot.transform.position = touchPos;
                }

                else if (joystick.phase == TouchPhase.Moved || joystick.phase == TouchPhase.Stationary)
                {
                    TransRocket();
                    move_audio.Play();
                }

                else if (joystick.phase == TouchPhase.Ended)
                {
                    circle.SetActive(false);
                    dot.SetActive(false);

                    rb.velocity = Vector2.zero;
                }
                animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
            }
        }
    }

    private void TransRocket()
    {
        dot.transform.position = touchPos;

        dot.transform.position = new Vector2(
            Mathf.Clamp(dot.transform.position.x,
            circle.transform.position.x - 6.7f,
            circle.transform.position.x + 6.7f),
            Mathf.Clamp(dot.transform.position.y,
            circle.transform.position.y - 6.9f,
            circle.transform.position.y + 6.9f));
        //change the 0.8f !!!!!

        rocket.transform.position = new Vector2(
            Mathf.Clamp(rocket.transform.position.x, -20f, 20f),
            Mathf.Clamp(rocket.transform.position.y, -40f, 40f));

        moveDir = (dot.transform.position - circle.transform.position).normalized;

        rb.velocity = moveDir * speed;

    }

    private void TransRocketGyro()
    {
        moveDir = new Vector2(Input.acceleration.x, Input.acceleration.y);

        rocket.transform.position = new Vector2(
            Mathf.Clamp(rocket.transform.position.x, -20f, 20f),
            Mathf.Clamp(rocket.transform.position.y, -40f, 40f));

        rb.velocity = moveDir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftSatelite"))
        {
            GameManager.player_answer = "left";
        }
        else if (collision.CompareTag("RightSatelite"))
        {
            GameManager.player_answer = "right";
        }
        else if (collision.CompareTag("Obstacle"))
        {
            hit_audio.Play();
        }
    }
}
