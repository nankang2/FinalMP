using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public int damage = 1;
    public float attackCooldown = 1.5f;

    private float lastAttackTime = -999f;

    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player != null && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            if (animator != null)
                animator.SetTrigger("Attack");

            player.TakeDamage(damage);
        }
    }
}