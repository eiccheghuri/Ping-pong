using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    private string _leftKey, _rightKey;
    [SerializeField]
    private float _leftBoundaryValue, _righBoundaryValue;

    [SerializeField]
    private float _paddleSpeed;

    private void Update()
    {

        PaddleMovement();
       



    }

    public void PaddleMovement()
    {
        if (Input.GetKey(_leftKey) && transform.position.x > _leftBoundaryValue)
        {
            transform.Translate(-transform.right * _paddleSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(_rightKey) && transform.position.x < _righBoundaryValue)
        {
            transform.Translate(transform.right * _paddleSpeed * Time.deltaTime);
        }
    }


}
