using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x <= -6)
        {
            GameObject.Destroy(gameObject);
        }

    }
}
