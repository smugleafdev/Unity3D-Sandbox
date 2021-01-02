﻿using System.Collections;
using UnityEngine;

public class EnemyBehaviorManager : MonoBehaviour {

    Transform target;
    [SerializeField] float turnSpeed = 25f;
    EnemyAttackManager enemyEmitterManager;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float attackSpeed = 3f;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyEmitterManager = transform.GetComponentInChildren<EnemyAttackManager>();
        StartCoroutine("AttackTargetDelay");
    }

    void Update() {
        FaceTarget();
    }

    private void FaceTarget() {
        // Debug.Log("Facing " + target);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void AttackTarget() {
        enemyEmitterManager.Attack();
    }

    IEnumerator AttackTargetDelay() {
        yield return new WaitForSeconds(attackSpeed);
        AttackTarget();
        StartCoroutine("AttackTargetDelay");
    }
}
