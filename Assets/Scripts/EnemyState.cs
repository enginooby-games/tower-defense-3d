﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// rigidbody component will receive collision event from childrent containing colliders

[RequireComponent(typeof(Rigidbody))]
public class EnemyState : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int scoreOnDeath = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
