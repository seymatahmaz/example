using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 5.0f;
    private bool _laserActive;
    private SpriteRenderer _renderer;
    private bool _isInvincible = false;
    public float invincibleDuration = 2f;     // 2 saniye ölümsüz
    public float blinkSpeed = 0.1f;           // Yanýp sönme hýzý


    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }


    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isInvincible) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            GameManager.instance.LoseLife();
            StartCoroutine(Invincibility());
        }
    }

    private IEnumerator Invincibility()
    {
        _isInvincible = true;

        float elapsed = 0f;

        while (elapsed < invincibleDuration)
        {
            _renderer.enabled = !_renderer.enabled; // Yanýp sönme
            elapsed += blinkSpeed;

            yield return new WaitForSeconds(blinkSpeed);
        }

        _renderer.enabled = true;
        _isInvincible = false;
    }


}