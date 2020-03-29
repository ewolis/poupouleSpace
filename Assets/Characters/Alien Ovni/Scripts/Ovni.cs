using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovni : MonoBehaviour
{
    [SerializeField] private bool startToTop = true;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToToggle = 5f;
    [SerializeField] private float timeToWait = 0f;
    private float _move = 0;

    void Start()
    { 
        Invoke("Started", timeToWait);
    }

    private void Started()
    {
        if (!startToTop)
        {
            _move = -1;
        } else
        {
            _move = 1;
        }

        InvokeRepeating("Toggle", timeToToggle, timeToToggle);
    }

    void Update()
    {
        if (_move != 0)
        {
            transform.Translate(Vector2.up * (_move * speed * Time.deltaTime));
        }
    }

    private void Toggle()
    {
        _move *= -1;
    }
}
