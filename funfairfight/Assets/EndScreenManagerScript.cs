using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManagerScript : MonoBehaviour
{
    public int winner;
    public GameObject[] Players;
    private Animator[] animators;
    private bool isShooting;
    private float elapsedTime;
    private float prevAnimChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        animators = new[] {Players[0].GetComponent<Animator>(), Players[1].GetComponent<Animator>()};

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
            animators[winner].SetBool("IsShooting", isShooting);
        }
    }
}
