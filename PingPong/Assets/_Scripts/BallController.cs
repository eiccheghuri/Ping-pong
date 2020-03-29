using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speedUp;

    private bool _setSpeed=false;
    private float _xSpeed;
    private float _ySpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!GameController.Instance._gameOver)
        {
            if (!_setSpeed)
            {
                _setSpeed = true;
                _xSpeed = Random.Range(1f, 2f) * (Random.Range(0, 2) * 2 - 1);
                _ySpeed = Random.Range(1f, 2f) * (Random.Range(0, 2) * 2 - 1);
            }
            MoveBall();
        }

        
    }


    public void MoveBall()
    {
        _rigidbody.velocity = new Vector2(_xSpeed,_ySpeed);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.CompareTag("wall"))
        {
            
            _xSpeed *= -1;
        }

        if(other.gameObject.CompareTag("paddle"))
        {
            _ySpeed *= -1;
            if(_ySpeed>0)
            {
                _ySpeed += _speedUp;
            }
            else
            {
                _ySpeed -= _speedUp;
            }

            if(_xSpeed>0)
            {
                _xSpeed += _speedUp;
            }
            else
            {
                _xSpeed -= _speedUp;
            }



        }


       


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("endone"))
        {
            Debug.Log("collision happen");
             GameController.Instance._scoreTwo++;

             GameController.Instance._inPlay = false;
             GameController.Instance._scoreTwoText.text = GameController.Instance._scoreTwo.ToString();
            _setSpeed = false;
            _rigidbody.velocity = Vector2.zero;
            this.transform.position = Vector2.zero;


        }
        else if(other.gameObject.CompareTag("endtwo"))
        {
            Debug.Log("collision happen");
            GameController.Instance._scoreOne++;

            GameController.Instance._inPlay = false;
            GameController.Instance._scoreOneText.text = GameController.Instance._scoreOne.ToString();
            _setSpeed = false;
            _rigidbody.velocity = Vector2.zero;
            this.transform.position = Vector2.zero;


        }


    }



}
