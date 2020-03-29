using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovni : MonoBehaviour
{
    [SerializeField] private bool startToTop = true;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToToggle = 5f;
    private float _move = 1;

    void Start()
    {
        if (!startToTop)
        {
            _move *= -1;
        }

        InvokeRepeating("Toggle", timeToToggle, timeToToggle);
    }

    void Update()
    {
        
        transform.Translate(Vector2.up * (_move * speed * Time.deltaTime));
    }

    private void Toggle()
    {
        _move *= -1;
    }
}
