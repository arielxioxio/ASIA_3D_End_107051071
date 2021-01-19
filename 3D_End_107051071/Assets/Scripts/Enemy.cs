using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 30)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 30)]
    public float stopDistance=2.5f;
    [Header("攻擊冷卻時間"), Range(0, 30)]
    public float cd = 2f;
    [Header("攻擊中心")]
    public Transform atkpoint;
    [Header("攻擊長度"), Range(0f, 3f)]
    public float atklength;
    [Header("攻擊力"), Range(0,500)]
    public float atk = 30;


    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        player = GameObject.Find("生氣").transform;
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    private void Update()
    {
        Track();
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkpoint.position, atkpoint.forward * atklength);

    }

    private RaycastHit hit;
    public float hp = 100;


    private void Attack()
    {
        if (nav.remainingDistance < stopDistance) 
        {
            timer += Time.deltaTime;

            Vector3 pos =player.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);

            


           
            if (timer >= cd)
            {
                ani.SetTrigger("攻擊");
                timer = 0;

                if (Physics.Raycast(atkpoint.position, atkpoint.forward,out hit, atklength, 1 << 8))
                {
                    hit.collider.GetComponent<Player>().Damage(atk);
                }
            }

         }
    }

    public void Damage(float damage)
    {
        hp -= 30;
        ani.SetTrigger("受傷");

        if (hp <= 0) Dead();

    }
    private void Dead()
    {
        nav.isStopped = true;
        enabled = false;
        ani.SetBool ("死亡",true);

 
    }

    private void Track()
    {
        nav.SetDestination(player.position);

        ani.SetBool("跑步", nav.remainingDistance > stopDistance);
    }
}
