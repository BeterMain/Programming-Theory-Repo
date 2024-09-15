using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject deathEffect;
    private GameObject pedestal;
    public float speed = 5f;
    private bool isDead = false;

    [SerializeField]
    private int max_health = 2;
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField]
    private int damage = 15;
    public int Damage // ENCAPSULATION 
    {
        get { return damage; }
        private set { Damage = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = max_health;

        pedestal = GameObject.Find("PedestalGoal");
    }

    // Update is called once per frame
    void Update()
    {
        GoToObject();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DamagePedestal();
        }
    }

    public virtual void GoToObject() // POLYMORPHISM
    {
        Vector3 dir = pedestal.transform.position - transform.position;
        rb.velocity = dir.normalized * speed;

        transform.forward = rb.velocity.normalized;
    }

    public virtual void Hit(int damage) // POLYMORPHISM
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        // Instantiate Death effect
        Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);

        // Destroy self
        Destroy(gameObject);
    }

    public virtual void DamagePedestal()
    {
        if (!isDead)
        {
            // Decrement health of pedestal
            PedestalHealth pedestalHealth = pedestal.GetComponent<PedestalHealth>();
            pedestalHealth.Hit(damage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestal") && !isDead)
        {
            DamagePedestal();

            Die();
        }
    }



}
