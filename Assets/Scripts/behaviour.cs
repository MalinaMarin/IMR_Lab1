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

        // for(int i = 0; i < players.Length; i++) {
        //     Debug.Log("x: " + i + " " + players[i].transform.position.x);
        // }

        players = players.Where(val => val.transform.position.x < 10).ToArray();

        Debug.Log("unity test: " + players.Length);
        if(players.Length > 1) {
            Vector3 pos1 = players[0].transform.position;
            Vector3 pos2 = players[1].transform.position;

            float dist = Vector3.Distance(pos1, pos2);
            //float dist = (float) Math.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y) + (pos1.z - pos2.z) * (pos1.z - pos2.z));
            Debug.Log("test: " + (dist < distance) + " " + dist);

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
