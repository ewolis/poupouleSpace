using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Animator _animator;
    private bool _delete = false;

    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_delete)
        {
            Invoke("Destruct", 0.5f);
            _animator.SetTrigger(HashDestroy);
            _delete = true;

            collision.gameObject.SendMessage("Hit");
        }
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }


    private static readonly int HashDestroy = Animator.StringToHash("Destroy");
}
