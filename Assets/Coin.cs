using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GetComponent<Collider>().gameObject.GetComponent<Player>();
        if (player !=null)
        {
            gameObject.SetActive(false);
        }
    }

}
