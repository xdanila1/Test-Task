using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _damage;
    [SerializeField] private IItem[] _dropItems; // нужно сделать абстрактным классом.

    private NavMeshAgent _agent;
    private HealthSystem _AttactedObject;
    private float _delayAttack;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
        _AttactedObject = _target.GetComponent<HealthSystem>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowPath();
        Animate();
    }

    private void FollowPath()
    {
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

        if (_agent.remainingDistance!=0 && _agent.remainingDistance < _agent.stoppingDistance && _agent.remainingDistance < 20)
        {
            
            _anim.SetBool("Run",false);
            Attack();
            print($"{ _agent.remainingDistance} < {_agent.stoppingDistance }  && {_agent.remainingDistance} < 20");
        }

    }
    private void Attack()
    {
        if (Time.time < _delayAttack) return;
        _AttactedObject.TakeDamage(_damage);
        _delayAttack = Time.time + 1 / _fireRate;

    }
}
