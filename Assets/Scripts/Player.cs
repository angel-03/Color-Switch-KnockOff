using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpspeed = 10f;
    public Rigidbody2D rb;
    public string CurColor;
    public SpriteRenderer sr;

    public Color colBlue;
    public Color colYellow;
    public Color colPurple;
    public Color colPink;


    public GameObject Textui;


    private void Start()
    {
        Time.timeScale  = 0;
        SetColor();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpspeed;
            Time.timeScale = 1;
            Textui.SetActive(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        
       
        if (collision.tag == CurColor)
        {

        }
        else if (collision.tag == "ColorChanger")
        {
            SetColor();
            Destroy(collision.gameObject);
            return;
        }

        else 
        {
            //Debug.Log("Game Over");
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetColor()
    {
        int number = Random.Range(0, 4);

        switch (number)
        {
            case 0:
                CurColor = "Blue";
                sr.color = colBlue;
                break;
            case 1:
                CurColor = "Yellow";
                sr.color = colYellow;
                break;
            case 2:
                CurColor = "Purple";
                sr.color = colPurple;
                break;
            case 3:
                CurColor = "Pink";
                sr.color = colPink;
                break;

        }
    }
}
