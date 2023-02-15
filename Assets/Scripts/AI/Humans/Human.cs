using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : BasicCharacter
{
    private GameObject _Target = null;
    [SerializeField] private Construction[] _Constructions;
    [SerializeField] private Resource[] _Resources;
    private NavMeshMovementBehavior _NavMeshMovementBehavior;
    // [SerializeField] private float m_AttackRange = 2.0f;


    protected override void Awake()
    {
        base.Awake();

        _NavMeshMovementBehavior= GetComponent<NavMeshMovementBehavior>();
    }
    private void Start()
    {
        // Expensive method. Use it with caution
        // PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        // if (player != null)
        // m_PlayerTarget = player.gameObject;

        _Target = _Constructions[0].gameObject;
        _MovementBehavior.Target = _Target;
    }

    // Update is called once per frame
    private void Update()
    {
       
        HandleMovement();
        HandleRotation();
        HandleAttacking();
    }

    void HandleMovement()
    {
        if (_MovementBehavior == null)
            return;

       
    }

    void HandleRotation()
    {
        if(_MovementBehavior != null)
            _MovementBehavior.DesiredLookatPoint = _Target.transform.position;
       
    }

    void HandleAttacking()
    {
       // if (m_ShootingBehavior == null) return;

        //if (m_PlayerTarget == null) return;

        // If we are in range of the player, Fire our weapon
        // use sqr magnitude when comparing ranges as it is more efficient
      /*  if ((transform.position - m_PlayerTarget.transform.position).sqrMagnitude < m_AttackRange * m_AttackRange)
        {
            m_ShootingBehavior.PrimaryFire();

            // This is a Kamikaze enemy
            // When it fires, it should destroy itself

            Invoke(KILL_METHODNAME, 0.2f);
        }*/
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if(_NavMeshMovementBehavior != null && collision.gameObject.layer != 6)
        {
            
            _NavMeshMovementBehavior.StopMovement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (_NavMeshMovementBehavior != null && other.gameObject.layer != 6)
        {
            Debug.Log(other);
            _NavMeshMovementBehavior.Target = null;
            _NavMeshMovementBehavior.StopMovement();
        }
    }

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        Destroy(gameObject);
    }
}
