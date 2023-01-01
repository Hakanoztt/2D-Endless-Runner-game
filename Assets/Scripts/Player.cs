using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public AudioSource audio;

    AudioSource gameOverSound;

    public HeartSystem heartSystem;
    public Spawner spawner;
    public GameObject enemyEffect;
    public GameObject playerEffect;
    public GameObject gameOverPanel;
    public GameObject stopButton;
    public GameObject coinEffect;

    bool control = false;

    public ScoreManager scoreManager;

    Vector2 targetPos;

    public float Yincrement;
    public float speed;

    public float maxHeight;
    public float minHeight;
    public Animator camAnim;
    private float _lastMoveTime;
    private void Start() {
        gameOverSound = GetComponent<AudioSource>();
    }
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        Movement();

        if (Time.time - _lastMoveTime < 0.1f) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight) {
            _lastMoveTime = Time.time;
            camAnim.SetTrigger("Shake");
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            Instantiate(playerEffect, transform.position, transform.rotation);

        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight) {
            _lastMoveTime = Time.time;
            camAnim.SetTrigger("Shake");
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Instantiate(playerEffect, transform.position, transform.rotation);
        }
    }

    void Movement() {
       if (Time.time - _lastMoveTime < 0.1f) return;

        if (Input.touchCount > 0) {

            _lastMoveTime = Time.time;
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.y > 3 && transform.position.y < maxHeight) {

                camAnim.SetTrigger("Shake");
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                Instantiate(playerEffect, transform.position, transform.rotation);
            } else if (touch.deltaPosition.y < -3 && transform.position.y > minHeight) {
                camAnim.SetTrigger("Shake");
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                Instantiate(playerEffect, transform.position, transform.rotation);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            var _enemyEffect = Instantiate(enemyEffect, collision.transform.position, transform.rotation);
            Destroy(_enemyEffect, 3f);
            heartSystem.IncreaseHealth();
            Debug.Log(heartSystem.health);
            Destroy(collision.gameObject);

            if (heartSystem.health == 0) {
                gameOverSound.Play(); 
                spawner.ShutDownSpawner();
                StartCoroutine(TimeScale());
                gameOverPanel.SetActive(true);
                scoreManager.scoreText.color = Color.black;
                scoreManager.scoreText.transform.localPosition = new Vector3(200, -179, 0);

            }
        }

        if (collision.CompareTag("Coin")) {
            scoreManager.score += 5;
            Destroy(collision.gameObject);
            var _coinEffect = Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(_coinEffect, 3f);
        }
    }

    IEnumerator TimeScale() {
        yield return new WaitForSeconds(1.1f);
        Time.timeScale = 0;
    }
}
