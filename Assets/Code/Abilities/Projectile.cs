using UnityEngine;
using Stats;
using Utilities;

public class Projectile : MonoBehaviour
{
    #region Inspector

    [Header("Relations")]
    [SerializeField]
    protected Rigidbody physics_body = null;

    #endregion


    #region Fields

    private Vector3 direction;
    private float range;
    private float speed;
    private int damage;
    private float distance_traveled;

    #endregion


    #region MonoBehavior

    private void FixedUpdate()
    {
        physics_body.velocity = direction * speed;
        distance_traveled += speed * Time.deltaTime;

        // Once the projectile has travelled it's max distance
        if (distance_traveled > range)
            GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if collision is with enemy, and damage them if so
        if (other.gameObject.layer == Constants.ENEMY_LAYER)
        {
            other.GetComponent<CharacterStats>().Damage(damage);
            GameObject.Destroy(gameObject);
        }
    }

    public void Fire(Vector3 direction, float range, float speed, int damage)
    {
        this.direction = direction;
        this.range = range;
        this.speed = speed;
        this.damage = damage;
        distance_traveled = 0;
    }

    #endregion

}