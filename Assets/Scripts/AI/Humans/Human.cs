using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : BasicCharacter
{
    [SerializeField] private GameObject _Target = null;
    [SerializeField] private Construction[] _Constructions;
    [SerializeField] private Resource[] _Resources;
    // [SerializeField] private float m_AttackRange = 2.0f;

    private void Start()
    {
        // Expensive method. Use it with caution
       // PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

       // if (player != null)
           // m_PlayerTarget = player.gameObject;
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

        _MovementBehavior.Target = _Target;
    }

    void HandleRotation()
    {
        if (_MovementBehavior != null && _Target != null)
        {
            _MovementBehavior.DesiredLookatPoint = _Target.transform.position;
        }
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

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        Destroy(gameObject);
    }
}
