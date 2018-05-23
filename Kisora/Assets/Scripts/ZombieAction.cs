using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAction : MonoBehaviour
{

    private CharacterController controller;
    private Animator animator;
    private Vector3 kisoraDestination;
    private Vector3 randDestination;
    private Vector3 velocity;
    private Vector3 direction;
    private float waitTime;
    private float currentTime;
    private GameObject kisora;

    private AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        velocity = Vector3.zero;
        kisora = GameObject.Find("Kisora");
        waitTime = 2.0f;
        currentTime = 0.0f;
        randDestination = RandDestination();
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        kisoraDestination = new Vector3(kisora.transform.position.x, kisora.transform.position.y, kisora.transform.position.z);

        if (Vector3.Distance(kisoraDestination, transform.position) > 50) {
            animator.SetBool("isAttack", false);

            if (Vector3.Distance(randDestination, transform.position) < 0.5) {
                currentTime += Time.deltaTime;
                if (currentTime > waitTime) {
                    animator.SetBool("isWalk", true);
                    randDestination = RandDestination();
                    currentTime = 0.0f;

                    Walk(randDestination, 0.5f);
                } else {
                    animator.SetBool("isWalk", false);
                }
            } else {
                animator.SetBool("isWalk", true);

                Walk(randDestination, 0.5f);
            }
        } else if (Vector3.Distance(kisoraDestination, transform.position) < 1.5) {
            animator.SetBool("isWalk", false);
            Attack();

            direction = (kisoraDestination - transform.position).normalized;
            transform.LookAt(new Vector3(kisoraDestination.x, transform.position.y, kisoraDestination.z));
        } else {
            animator.SetBool("isWalk", true);
            animator.SetBool("isAttack", false);

            Walk(kisoraDestination, 1.0f);
        }
    }

    private void Walk(Vector3 destination, float speed)
    {
        if (controller.isGrounded) {
            velocity = Vector3.zero;
            direction = (destination - transform.position).normalized;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            velocity = direction * speed;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private Vector3 RandDestination()
    {
        Vector3 random = Random.insideUnitCircle * 10;
        Debug.Log(random);
        return transform.position + new Vector3(random.x, 0, random.y);
    }



    private void Attack()
    {
        animator.SetBool("isAttack", true);

        kisora.SendMessage("Damage", animator.gameObject.name);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.gameObject.name.Equals("Kisora"))
        //{
        //    Debug.Log(Vector3.Distance(kisoraDestination, transform.position));
        //}
    }
}
