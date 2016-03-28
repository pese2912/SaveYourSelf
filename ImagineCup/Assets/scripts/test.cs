using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("WalkFWD", true);
	}
}
