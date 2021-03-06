﻿//using MonobitEngine;//動かすときはコメントアウト消す
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour //動かすときはMonobitEngine.をMonoBehaviourの前につける
{
    Rigidbody rb;
    public float defaultSpeed = 5f;
    public float speed = 5f;//移動速度
    public float jumpForce = 100f;//ジャンプ力
    public float climbForce = 160f;
    private bool Ground = true;
    private float angle = 0;
    private GameObject PL;
    private CapsuleCollider playercharacter;
    private Animator animator;

    void Start()
    {
        PL = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        playercharacter= PL.GetComponent<CapsuleCollider>();

    }
    void Update()
    {
        Move();
        Jump();
        Climb();

        if (Input.GetMouseButton(1))
        {
            rb.AddForce(transform.up * climbForce);
            transform.position += transform.forward * speed * Time.deltaTime * 10;
        }


    }
    public void Move()
    {
        //Cでダッシュ---------------------------------------------------------------------
        if (Input.GetKey(KeyCode.C))
        {
            speed = defaultSpeed * 2.0f;
        }
        else
        {
            speed = defaultSpeed;
        }

        //Wで前進----------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            animator.SetBool("Key_W", true);
        }
        else
        {
            animator.SetBool("Key_W", false);
        }

        //Sで後退---------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            animator.SetBool("Key_S", true);
        }
        else
        {
            animator.SetBool("Key_S", false);
        }

        //Aで左へ---------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.A))
        {
            angle -= 2;
            transform.position += transform.forward * speed / 2 * Time.deltaTime;
            transform.Rotate(new Vector3(0, -90 * Time.deltaTime, 0));
            animator.SetBool("Key_A", true);
        }
        else
        {
            animator.SetBool("Key_A", false);
        }

        //Dで右へ-----------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.D))
        {
            angle += 2;
            transform.position += transform.forward * speed / 2 * Time.deltaTime;
            transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
            animator.SetBool("Key_D", true);
        }
        else
        {
            animator.SetBool("Key_D", false);
        }
        //--------------------------------------------------------------------------------------

        //Xでしゃがむ
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("Key_X", true);
            playercharacter.height = 0.775f;
            //playercharacter.center(0, 0.076, -0.56);
        }
        else
        {
            animator.SetBool("Key_X", false);
            playercharacter.height = 1.55f;
        }
        //
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    public void Jump()
    {
        if (Ground == true)
        {
            if (Input.GetKey(KeyCode.Space))//Spaceでジャンプ
            {
                rb.AddForce(transform.up * jumpForce);
                animator.SetBool("Key_Space", true);
                Ground = false;
            }
        }
        if (!Input.GetKey(KeyCode.Space))
        {
                animator.SetBool("Key_Space", false);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (Ground == false)
            {
                Ground = true;
            }
        }
    }
    ///　崖上り
    public void Climb()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10000000000000000000);
    }
  }