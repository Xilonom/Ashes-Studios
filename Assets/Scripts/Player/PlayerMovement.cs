using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public Rigidbody2D rb;

    public Animator PlrAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x >= 1)
        {
            PlrAnimator.SetFloat("walk",1); //анимация ходьбы влево
        }
            if (direction.x <= -1)
            {
                PlrAnimator.SetFloat("walk",-1); //анимация ходьбы вправо
            }
       
       
            if (direction.y != 0 && direction.x == 0)
            {
                 PlrAnimator.SetFloat("walk",1);//анимация ходьбы вверх
            }
       
        
            if (direction.y == 0 && direction.x == 0)
            {
                 PlrAnimator.SetFloat("walk",0); //анимация idle
            }
       

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
