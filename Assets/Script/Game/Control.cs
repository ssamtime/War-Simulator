using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    //private 변수 외부에 노출시켜줌
   
    [SerializeField] LayerMask[] layer;
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] int attack;
    [SerializeField] float speed;
    [SerializeField] Slider Gauge;
   
    private RaycastHit hit;
    Animator animator;

    private int count;

    private void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = currentHealth;
    }

    void Update()
    {
        Gauge.value = (float)currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            speed = 0;
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Ray ray = new Ray(
            new Vector3(transform.position.x,1,transform.position.z),transform.forward);

        if(Physics.Raycast(ray, out hit, 2.0f, layer[0]))
        {
            speed = 0;
            animator.SetBool("Attack State", true);

            //Gizmos.DrawRay(transform.position, transform.forward * 2.0f);
            
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime - count >= 1)
                {
                    count++;
                    SoundManager.Instance.Sound(1);
                    hit.transform.GetComponent<Control>().currentHealth -= attack;
                }
               
            }
            
        }

        else if(Physics.Raycast(ray, out hit, 2.0f, layer[1]))
        {
            speed = 0;
            animator.SetBool("Idle State", true);
        }
        else
        {
            speed = 2;
            animator.SetBool("Attack State", false);
            animator.SetBool("Idle State", false);
        }
    }
}
