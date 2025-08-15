using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float collisionCoolDown = 1f;
    float cooldownTimer = 0f;
    LevelGenerator levelGenerator;

    private void Start() {
       levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        // if (cooldownTimer > 0f)
        // {
        //     cooldownTimer -= Time.deltaTime;
        // }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCoolDown) return;

        levelGenerator.ChangeMoveSpeed(-2f);
        animator.SetTrigger("Hit");
        cooldownTimer = 0f;
    }
}
