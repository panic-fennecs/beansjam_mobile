using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManagerScript : MonoBehaviour
{
    public GameObject[] Players;
    private Animator animator;
    private bool isShooting;
    private float elapsedTime;
    private float prevAnimChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GlobalScript.winner);
        Players[1 - GlobalScript.winner].SetActive(false);
        Players[GlobalScript.winner].GetComponent<PlayerScript>().HideButtons();
        Players[GlobalScript.winner].GetComponent<PlayerScript>().HideHealthMarks();
        Players[1 - GlobalScript.winner].GetComponent<PlayerScript>().HideButtons();
        Players[1 - GlobalScript.winner].GetComponent<PlayerScript>().HideHealthMarks();

        isShooting = false;
        animator = Players[GlobalScript.winner].GetComponent<Animator>();

        elapsedTime = 0;
        prevAnimChangeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > (prevAnimChangeTime + 0.4f + (isShooting ? 0.0f : 0.2f))) {
            prevAnimChangeTime = elapsedTime;
            isShooting = !isShooting;
			if (animator != null) {
            	animator.SetBool("IsShooting", isShooting);
			}
        }
    }
}
