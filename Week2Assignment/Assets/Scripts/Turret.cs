using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public float turretSpeed;
    public float boostedSpeed;

    public float totalHealth;
    public float currentHealth;
    public float damage;

    public float totalBoost;
    public float currentBoost;
    public float decreaseRate;
    public float increaseRate;

    public GameObject BonusParticle;
    public GameObject TerrainParticle;
    public GameObject BoostParticle;
    public GameObject HealthParticle;

    public Vector3 pos;

    private void Start()
    {
        currentHealth = totalHealth;
        currentBoost = totalBoost;
    }


    private void Update()
    {

        FollowMouse();

        if (currentBoost > 0)
        {
            Boost();
        }
        //FaceMouse();
        //MoveTurret();

        pos = transform.position;
        boostedSpeed = turretSpeed + 2;
        
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
    
    void FollowMouse()
    {
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), turretSpeed * Time.deltaTime);
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }

    void Boost()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector2.Lerp(transform.position,
                Camera.main.ScreenToWorldPoint(Input.mousePosition), boostedSpeed * Time.deltaTime);

            if (currentBoost>0)
            {
                currentBoost -= decreaseRate;
            }
        }
        else
        {
            if (currentBoost>totalBoost)
            {
                currentBoost = totalBoost;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            Destroy(other.gameObject);
            Instantiate(BonusParticle, gameObject.transform.position, Quaternion.identity);

            GameManager.Instance.score += EnemyManager.Instance.bonusValue;
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(TerrainParticle, gameObject.transform.position, Quaternion.identity);
            
            currentHealth-=damage;
        }

        if (other.gameObject.CompareTag("Boost"))
        {
            Destroy(other.gameObject);
            Instantiate(BoostParticle, gameObject.transform.position, Quaternion.identity);
            
            currentBoost += increaseRate;
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            Instantiate(HealthParticle, gameObject.transform.position, Quaternion.identity);

            currentHealth += 30;
        }


        if (currentHealth>totalHealth)
        {
            currentHealth = totalHealth;
        }
    }
}