using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _damage;
    [SerializeField] private Item[] _dropItems;
    [SerializeField] private float _rangeAggression =10f;
    [SerializeField] private LayerMask _layerAttakedObject;

    private NavMeshAgent _agent;
    private GameObject _target;
    private HealthSystem _enemyHP;
    private float _delayAttack;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowPath();
        Animate();
    }
    private void FollowPath()
    {
        if (_target == null)
        {
            FindEnemy();
            return;
        }
        if(Vector2.Distance(transform.position,_target.transform.position) <_rangeAggression)
            _agent.SetDestination(_target.transform.position);
    }
    private void Animate()
    {

        if (_agent.velocity != Vector3.zero)
        {

            if (_agent.velocity.x > 0) _sprite.flipX = false;
            else _sprite.flipX = true;
        }
        if (_agent.isStopped) _anim.SetBool("Run", false);
        else _anim.SetBool("Run", true);

        if(_target !=null)
        if (Vector2.Distance(transform.position,_target.transform.position) < _agent.stoppingDistance)
        {
            
            _anim.SetBool("Run",false);
            Attack();

        }

    }
    private void Attack()
    {
        if (Time.time < _delayAttack) return;
        _enemyHP.TakeDamage(_damage);
        _delayAttack = Time.time + 1 / _fireRate;

    }
    private void FindEnemy()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _rangeAggression, _layerAttakedObject );
        foreach (var obj in objects)
        {
            HealthSystem enemy = obj.GetComponent<HealthSystem>();
            if (enemy != null && !enemy.IsDead)
            {
                Debug.DrawLine(transform.position, obj.transform.position, Color.red, 2f);
                _target = obj.gameObject;
                 _enemyHP = enemy;
            }
        }
    }
    public void DropItems()
    {
        foreach (var item in _dropItems)
        {
            GameObject obj = new GameObject(item.Name);
            obj.AddComponent<ItemGameObject>().Item = item;
            obj.transform.position = transform.position;

        }
    }

}
