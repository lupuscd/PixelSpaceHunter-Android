using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //Configuration
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.1f;
    [SerializeField] int health = 300;
    [SerializeField] HealthBar healthBar;

    [Header("Laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Destruction")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionDestructionTime = 1f;

    Coroutine firingCoroutine;
    AudioSource myAudioSource;
    AudioClip laserSound;

    private Touch theTouch;
    private Vector3 touchPosition;
    private Vector3 direction;
    private Rigidbody2D rb;

    //Cached refs
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float shotCounter = 0.3f;
    bool boost = false;
    float boostTime;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        healthBar.SetMaxHealth(health);
        myAudioSource = GetComponent<AudioSource>();
        laserSound = myAudioSource.clip;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {

        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = 0.3f;

            if (boost == true)
            {
                FireDiag();
                boostTime -= Time.deltaTime;
                if (boostTime <= 0f)
                {
                    boost = false;
                }
            }
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        myAudioSource.PlayOneShot(laserSound);
    }

    private void FireDiag()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, projectileSpeed);
        myAudioSource.PlayOneShot(laserSound);
        GameObject laser2 = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, projectileSpeed);
        myAudioSource.PlayOneShot(laserSound);
        GameObject laser3 = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(0.25f, projectileSpeed);
        myAudioSource.PlayOneShot(laserSound);
        GameObject laser4 = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.25f, projectileSpeed);
        myAudioSource.PlayOneShot(laserSound);
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(theTouch.position);
            touchPosition.z = 0f;
            touchPosition.x = Mathf.Clamp(touchPosition.x, xMin, xMax);
            touchPosition.y = Mathf.Clamp(touchPosition.y + 0.25f, yMin, yMax);
            direction = touchPosition - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (theTouch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, explosionDestructionTime);
        FindObjectOfType<Level>().LoadGameOver();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "HealthDrop")
        {
            health = 300;
            healthBar.SetHealth(health);
        }

        if (other.tag == "ROFDrop")
        {
            boost = true;
            boostTime = 0.3f;
        }
    }
}
