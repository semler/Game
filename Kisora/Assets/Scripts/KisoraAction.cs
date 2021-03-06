﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KisoraAction : MonoBehaviour
{
    static int hp = 1000;

    private CharacterController controller;
    private Animator animator;

    //private GameObject kisora;

    private AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);





    }


    private void Damage(string name)
    {
        if (hp == 0)
        {
            Dead("self");
        } else {
            animator.SetBool("isDamage", true);
            hp--;
        }
    }

    private void Dead(string name)
    {
        animator.SetBool("isDead", true);
    }

    private void Attack(string name)
    {
        animator.SetBool("isAttack", true);
    }

    private void Jump(string name)
    {
        animator.SetBool("isJump", true);
    }

    private void Run(string name)
    {
        animator.SetBool("isRun", true);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("???????????");
        if (hit.gameObject.name.Equals("Zombie")) {
            Debug.Log(hit.gameObject);
        }

    }

}
