using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    public float flap;

    public Rigidbody2D rb;
    public GameObject panel_go;
    public GameObject text;

    public AudioController sfx;

    bool gameover = false;
    public bool start = false;
 
    public void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if(!gameover)
        {
            if (rb.velocity.y < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -10));
            }

            if (Input.GetKeyDown("space"))
            {
                if(!start)
                {
                    rb.gravityScale = 2;
                    text.SetActive(false);
                    start = true;
                }

                else
                {
                    sfx.playFlap();
                    _flap();
                }
            }

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (!start)
                    {
                        rb.gravityScale = 2;
                        text.SetActive(false);
                        start = true;
                    }
                    else
                    {
                        sfx.playFlap();
                        _flap();
                    }
                }
            }

            if (transform.position.y >= 4.7f && start)
            {
                transform.position = new Vector2(0, 4.7f);
            }
        }
    }

    void _flap()
    {
        rb.velocity = Vector2.up * flap;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 10));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("scorer"))
        {
            sfx.playHit();
            panel_go.SetActive(true);
            Time.timeScale = 0;
            gameover = true;
            //sfx.playGameOver();
        }
    }

    public void _restart()
    {
        SceneManager.LoadScene(0);
    }
}
