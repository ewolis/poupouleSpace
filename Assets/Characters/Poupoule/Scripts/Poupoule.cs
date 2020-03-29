using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poupoule : MonoBehaviour
{
    [SerializeField] private float run = 5f;
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject megaFire;
    [SerializeField] private float fireSpeed = 500f;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    public bool inChargeMode = false;

    private int tactileMove = 0;

    #region Life Cycle

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessPhysics();

        if (tactileMove != 0)
        {
            transform.Translate(Vector2.up * (tactileMove * speed * Time.deltaTime));
        }
        else
        {
            float move = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * (move * speed * Time.deltaTime));
        }

        transform.Translate(Vector2.right * (run * Time.deltaTime));
    }

    public void TopStart()
    {
        tactileMove = 1;
    }

    public void TopStop()
    {
        tactileMove = 0;
    }

    public void BottomStart()
    {
        tactileMove = -1;
    }

    public void BottomStop()
    {
        tactileMove = 0;
    }

    private void FixedUpdate()
    {
        //TODO: Mapping des touches
        if (Input.GetKeyDown(KeyCode.X))
        {
            MakeCharge();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            MakeFire();
        }
    }

    #endregion

    #region Triggers

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("[Poupoule] OnCollisionEnter2D > " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Limit"))
        {
            return;
        }

        if (!inChargeMode)
        {
            MakeHurt();
        }

        collision.gameObject.SendMessage("Hit");
    }

    #endregion


    #region Action

    private void MakeHurt()
    {
        //TODO: Ajouter un son
        _animator.SetTrigger(HashHit);
    }

    public void MakeCharge()
    {
        //TODO: Ajouter un son

        inChargeMode = true;
        _animator.SetTrigger(HashCharge);
    }

    public void MakeEndCharge()
    {
        Debug.Log("[Poupoule] MakeEndCharge");

        inChargeMode = false;
    }

    public void MakeFire()
    {
        //Todo: vérification si mega feu
        _animator.SetTrigger(HashFire);

        GameObject _fire = Instantiate(fire, transform.position, Quaternion.identity);
        _fire.GetComponent<Rigidbody2D>().AddForce(Vector2.right * fireSpeed);
    }

    #endregion

    #region Physics

    private void ProcessPhysics()
    {
        
    }

    #endregion

    #region Hashing
    private static readonly int HashSpeed = Animator.StringToHash("Speed");

    private static readonly int HashHit = Animator.StringToHash("Hit");
    private static readonly int HashCharge = Animator.StringToHash("Charge");
    private static readonly int HashWin = Animator.StringToHash("Win");
    private static readonly int HashFire = Animator.StringToHash("Fire");
    #endregion
}
