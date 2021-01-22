using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        animator.SetFloat("horizontal",Mathf.Abs( Input.GetAxis("Horizontal")));
        animator.SetFloat("vertical", Mathf.Abs(Input.GetAxis("Vertical")));
    }
}
