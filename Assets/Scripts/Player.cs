using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (h != 0f || v != 0f)
        {
            _animator.Play("Movement");
            _animator.SetFloat("Horizontal", h);
            _animator.SetFloat("Vertical", v);

            transform.position += new Vector3(h, v, 0f) * Time.deltaTime * speed;
        }
        else
        {
            _animator.Play("Idle");
        }

    }
}
