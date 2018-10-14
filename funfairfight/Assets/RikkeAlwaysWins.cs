using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RikkeAlwaysWins : MonoBehaviour
{
	public Sprite KenWins;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalScript.winner == 0) {
			GetComponent<SpriteRenderer>().sprite = KenWins;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
