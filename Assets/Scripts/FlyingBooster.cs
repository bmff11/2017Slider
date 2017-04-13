using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBooster : MonoBehaviour {

    float timeStarted = 0;
    Player player;

    public float 

    void OnCollisionEnter2D(Collision2D coll) {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null) {
            player.canFly = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            timeStarted = Time.time;
        }
    }

    private void Update() {
        if(timeStarted != 0 && timeStarted + 10 < Time.time) {
            timeStarted = 0;
            player.canFly = false;
        }
    }
}
