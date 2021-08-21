using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform camera;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
