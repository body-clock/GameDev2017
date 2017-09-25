using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float turretSpeed = 5f;
    
    private void Update()
    {
        FaceMouse();
        MoveTurret();
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
        transform.position += move * turretSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            Debug.Log("BONUS!");
            Destroy(other.gameObject);

            GameManager.Instance.score++;

        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.score--;
        }
    }

}