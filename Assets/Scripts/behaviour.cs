using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class behaviour : MonoBehaviour {

    [SerializeField]
    public float distance = .45f;

    void Start() {

    }

    void Update() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if(players.Length > 1) {
            Vector3 pos1 = players[0].transform.position;
            Vector3 pos2 = players[1].transform.position;

            float dist = Vector3.Distance(pos1, pos2);

            Animator animator1 = players[0].GetComponent<Animator>();
            Animator animator2 = players[1].GetComponent<Animator>();
            if(dist < distance) {
                animator1.SetBool("attack", true);
                animator2.SetBool("attack", true);
            } else {
                animator1.SetBool("attack", false);
                animator2.SetBool("attack", false);
            }
        }
    }
}
