﻿using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    [SerializeField] GameObject playa;
    [SerializeField] float speed = 2f;
    public bool active;

    private void FixedUpdate() {
        if (active) {
            Vector3 move = new Vector3(speed * Time.fixedDeltaTime, 0, 0);
            transform.Translate(move);
            playa.transform.Translate(move, transform);
        }
    }
}