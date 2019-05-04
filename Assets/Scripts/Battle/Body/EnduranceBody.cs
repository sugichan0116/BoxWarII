using UnityEngine;

public class EnduranceBody : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 10f;
    private float health;

    [SerializeField]
    private float robustness = 10;

    public TweetBox prefabBox;

    public delegate void EventHandler();

    public event EventHandler OnDestroy;

    protected void Start()
    {
        health = maxHealth;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    float impact = 0f;
    //    GameObject opponent = collision.rigidbody.gameObject;

    //    //落下ダメージ & 接触ダメージ
    //    if (opponent.tag == "Ground")
    //    {
    //        Vector2 velocity = collision.relativeVelocity;
    //        impact += Mathf.Pow(velocity.magnitude, 2) / robustness;
    //    }
    
    //}
    
    public void Impact(float strongth)
    {
        float damage = Mathf.Max(strongth / 2 - robustness, 0f)
            + strongth / 2 * ((robustness >= strongth) ? 0.25f : 1f);

        health -= damage;
        if (prefabBox != null)
        {
            TweetBox box = Builder.Window(prefabBox, transform) as TweetBox;
            box.text = "" + (int)damage;
            box.transform.position += new Vector3(Random.Range(-.5f, .5f), 0);
            box.CloseAuto();
        }

        if (health <= 0f)
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

    public float Health() => health;
    public float MaxHealth() => maxHealth;
    public void AddHealth(float value) => health = Mathf.Clamp(health + value, 0, maxHealth);
    public void AddMaxHealth(float value) => maxHealth += value;

}
