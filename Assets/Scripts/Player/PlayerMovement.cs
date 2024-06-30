using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public Rigidbody2D rb;

    private SpriteRenderer _renderer;
    private AudioSource _stepsSource;

    private enum State
    {
        Stay = 0,
        Walk = 1,
        Grind = 2,
    }

    private State _playerState = State.Stay;

    public Animator PlrAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _stepsSource = GetComponent<AudioSource>();
        _stepsSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
  

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x != 0 || direction.y != 0)
        {
            _playerState = State.Walk;
        }

        if (direction.x >= 1)
        {
            _renderer.flipX = false;
            PlrAnimator.SetBool("Walk", true);
        }

        if (direction.x <= -1)
        {
            _renderer.flipX = true;
            PlrAnimator.SetBool("Walk", true); 
        }
    
        if (direction.y >= 1 && direction.x == 0)
        {
            PlrAnimator.SetBool("WalkUpDown", true);
        }

        if (direction.y <= -1 && direction.x == 0)
        {
            PlrAnimator.SetBool("WalkUpDown", true);
        }
    
        if (direction.y == 0 && direction.x == 0)
        {
            _playerState = State.Stay;
            PlrAnimator.SetBool("Walk", false); 
            PlrAnimator.SetBool("WalkUpDown", false);
        }
       
        if (_playerState == State.Walk && _stepsSource.isPlaying == false)
        {
            _stepsSource.Play();
        }

        if (_playerState == State.Stay)
        {
            _stepsSource.Stop();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

}
