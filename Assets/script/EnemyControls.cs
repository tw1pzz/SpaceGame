using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyControls : MonoBehaviour
{
    public int speed = 7;

    [HideInInspector] Score control;
    void Start()
    { 
        control = GameObject.FindGameObjectsWithTag("da")[0].GetComponent<Score>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y <= -7)
        {
            Destroy(this.gameObject);
        }
    }
   void Start1()
    {
        print(Random.Range(-7.5f, 7.5f));

    }

    void Start2()
    {
        print(Random.value);
    }

    void Start3()
    {
        print(Random.insideUnitSphere);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            control.UpdateScore();

        }
        else if (collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }

            Destroy(this.gameObject);

        if (collision.tag == "Finish")
            {
                Destroy(this.gameObject);
            }    
        }
    }   

}
