using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] int speed = 6;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate;

    [SerializeField] int playerLives = 5;
    [HideInInspector] float nextFire;
    [SerializeField] TextMeshProUGUI TextHP;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void SpaceMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * (Time.deltaTime * speed * horizontalInput));
        transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput));

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.07f)
        {
            transform.position = new Vector3(transform.position.x, -4.07f, 0);
        }

        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, transform.position, quaternion.identity);
            }
        }
    }

    public void LifeSubstraction()
    {
        playerLives--;
        print(playerLives);
        TextHP.text = "HP: " + playerLives;
        if (playerLives < 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void Update()
    {
        SpaceMovement();
        Shoot();
    }

}