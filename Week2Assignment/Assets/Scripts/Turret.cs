using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public float turretSpeed;
    public float slowedSpeed;

    public float totalHealth;
    public float currentHealth;
    public float damage;

    public GameObject BonusParticle;
    public GameObject TerrainParticle;

    public Vector3 pos;

    private void Start()
    {
        currentHealth = totalHealth;
    }


    private void Update()
    {
        FaceMouse();
        MoveTurret();

        pos = transform.position;
        slowedSpeed = turretSpeed - 7;
        
        float screenRatio = Screen.width / Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        
        
        //vertical bounds
        if (pos.y > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize;
            Debug.Log("left the top");
        }
        if (pos.y < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize;
            Debug.Log("left the bottom");
        }
        
        //horizontal bounds
        if (pos.x > widthOrtho)
        {
            pos.x = widthOrtho;
            Debug.Log("left the right");
        }
        if (pos.x < -widthOrtho)
        {
            pos.x = -widthOrtho;
            Debug.Log("left the left");
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("End");
        }
        
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        //converting our mousePosition from a screen to a world point
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        //subtracting our position from the mouse position in order to determine 
        //which direction we should be facing
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
        
        //facing our object towards mouse
        transform.up = direction;
    }

    void MoveTurret()
    {
        //move with WASD
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (Input.GetMouseButton(0))
        {
            transform.position += move * slowedSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += move * turretSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            Debug.Log("BONUS!");
            Destroy(other.gameObject);
            Instantiate(BonusParticle, gameObject.transform.position, Quaternion.identity);

            GameManager.Instance.score+=10;

        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(TerrainParticle, gameObject.transform.position, Quaternion.identity);
            
            currentHealth-=damage;
        }
    }

}