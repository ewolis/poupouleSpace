using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 5f;

    private Animator _animator;
    private bool _delete = false;

    void Start()
    {
        InvokeRepeating("MakeAttack", 0f, timeToAttack);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        if (!_delete)
        {
            Invoke("Destruct", 1);
            GetComponent<BoxCollider2D>().enabled = false;
            _delete = true;
            _animator.SetTrigger(HashDestroy);            
        } else
        {
            Destroy(gameObject);
        }
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    private void MakeAttack()
    {
        //Todo: vérification si mega feu
        _animator.SetTrigger(HashAttack);
    }


    private static readonly int HashAttack = Animator.StringToHash("Attack");
    private static readonly int HashDestroy = Animator.StringToHash("Death");
}
