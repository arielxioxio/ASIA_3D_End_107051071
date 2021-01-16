using UnityEngine;
using Invector.vCharacterController;

public class Player: MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private int atkCount;

    private float timer;
    [Header("連擊間隔"), Range(0, 3)]
    public float interval = 1;
    [Header("攻擊中心")]
    public Transform atkpoint;
    [Header("攻擊長度"), Range(0f, 3f)]
    public float atklength;
    [Header("攻擊力"), Range(0, 500)]
    public float atk = 30;

    private void Awake()
    {

        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkpoint.position, atkpoint.forward * atklength);

    }

    private RaycastHit hit;

    private void Attack()
    {

        if (atkCount < 3)
        {




            if (timer < interval)
            {
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    atkCount++;
                    timer = 0;
                    ani.SetInteger("連擊", atkCount);
                }

            }

            else
            {
                atkCount = 0;
                timer = 0;

                if (Physics.Raycast(atkpoint.position, atkpoint.forward, out hit, atklength, 1 << 9))
                {
                    hit.collider.GetComponent<Enemy>().Damage(atk);
                }
            }
        }

        if (atkCount == 3) atkCount = 0;
        ani.SetInteger("連擊", atkCount);
    }

    public void Damage(float damage)
    {
        hp -= 30;
        ani.SetTrigger("受傷");

        if (hp <= 0) Dead();
        
           }
    private void Dead()
    {
        ani.SetTrigger("死亡");

        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true; 
    }


   

}
