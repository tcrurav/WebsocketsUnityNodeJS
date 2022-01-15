using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    private float movementX;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        movementX = 0;
        movementZ = 0;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementX != 0 || movementZ != 0)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
            transform.position += movement * speed;

            movementX = 0;
            movementZ = 0;

            GameObject.Find("Connection").GetComponent<ConnectionScript>().SetUserChangedPosition();
        }
        
    }
}
