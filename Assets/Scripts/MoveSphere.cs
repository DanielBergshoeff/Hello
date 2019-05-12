using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public Vector3 direction;
    public float distance = 5.0f;
    public float speed = 1.0f;

    private Vector3 startPosition;
    private float sqrDistance;
    private bool moveDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        sqrDistance = distance * distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection)
            transform.position += direction * Time.deltaTime * speed;
        else
            transform.position -= direction * Time.deltaTime * speed;

        if(((transform.position - startPosition).sqrMagnitude > sqrDistance) && moveDirection || ((transform.position - startPosition).sqrMagnitude > sqrDistance) && !moveDirection) {
            moveDirection = !moveDirection;
        }
    }
}
