using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    private static readonly int Hash_Hit = Animator.StringToHash("Hit");
    private static readonly int Hash_Dead = Animator.StringToHash("Dead");
    private static readonly int Hash_ActionTrigger = Animator.StringToHash("ActionTrigger");
    private static readonly int Hash_ActionId = Animator.StringToHash("ActionId");

    #region Inspector
    [Header("Health")]
    [SerializeField] private Image healthbar;
    [SerializeField] int maxEnemyHealth;
    [SerializeField] int currentEnemyHealth;
    
    [Header("Animation")]
    [SerializeField] Animator animator;

    [Header("AttackTypes")] 
    [SerializeField] private int attackId;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackTime;
    
    #endregion
    
    #region Private Variables

    private float attackTimer;
    private bool canAttack;
    
    #endregion

    private void Awake()
    {
        currentEnemyHealth = maxEnemyHealth;
        RefreshHealthBar();
    }

    private void Update()
    {
        if (canAttack)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer < 0)
            {
                AttackPlayer();
            }
        }
    }

    public void CanAttackPlayer(bool value)
    {
        attackTimer = 0;
        canAttack = value;
    }

    void AttackPlayer()
    {
        animator.SetTrigger(Hash_ActionTrigger);
        animator.SetInteger(Hash_ActionId, attackId);
        attackTimer = attackTime;
    }

    public void GetDamage(int damage)
    {
        if (currentEnemyHealth < 1) return;
        
        currentEnemyHealth -= damage;

        animator.SetTrigger(Hash_ActionTrigger);
        if (currentEnemyHealth < 1)
        {
            OnDeath();
        }
        else
        {
            OnHit();
        }
        
        RefreshHealthBar();
    }

    void RefreshHealthBar()
    {
        //maxEnemyHealth
        //currentEnemyHealth
        healthbar.fillAmount = (float)currentEnemyHealth / (float)maxEnemyHealth;
    }
    
    public void OnDeath()
    {
        animator.SetTrigger(Hash_Dead);
    }
    
    public void OnHit()
    {
        animator.SetTrigger(Hash_Hit);
    }
}
