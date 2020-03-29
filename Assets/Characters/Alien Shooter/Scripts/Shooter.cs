using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 5f;
    [SerializeField] private GameObject laser;
    [SerializeField] private float laserSpeed = 500f;

    private Animator _animator;
    private bool _delete = false;

    void Start()
    {
        InvokeRepeating("MakeFire", 0f, timeToAttack);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        if (!_delete)
        {
            Invoke("Destruct", 0.5f);
            GetComponent<BoxCollider2D>().enabled = false;
            _delete = true;
            _animator.SetTrigger(HashDestroy);
        }
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    public void MakeFire()
    {
        _animator.SetTrigger(HashAttack);
        GameObject _fire = Instantiate(laser, transform.position, Quaternion.identity);
        _fire.GetComponent<Rigidbody2D>().AddForce(Vector2.left * laserSpeed);
    }

    private static readonly int HashAttack = Animator.StringToHash("Attack");
    private static readonly int HashDestroy = Animator.StringToHash("Death");
}
