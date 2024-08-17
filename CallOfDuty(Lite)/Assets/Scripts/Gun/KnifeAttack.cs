using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    private Animator animator;

void Start()
    {
    animator = GetComponent<Animator>();
        animator.SetBool("isAttacking", false);
    }

    void Update()
    {
    if (Input.GetButtonDown("Fire1"))
    {
        animator.SetBool("isAttacking", true);
        Invoke("Wait", 1);
    }
}

    void Wait()
    {
        animator.SetBool("isAttacking", false);
    }
}
