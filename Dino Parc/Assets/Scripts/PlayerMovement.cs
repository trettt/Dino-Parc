using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(x, 0f, z);

        transform.Translate(direction * _MovementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += new Vector3(0f, _MovementSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= new Vector3(0f, _MovementSpeed * Time.deltaTime, 0f);
        }
    }
}
