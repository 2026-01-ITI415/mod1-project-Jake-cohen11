using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    public static float bottomY = -20f;
    public int points = 10;
    public float fallSpeed = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        // If the apple hits the Ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Increase score first
            ScoreManager.instance.AddScore(points);

            // Then destroy the apple
            Destroy(gameObject);
        }

        // If the apple hits the Ground
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            ScoreManager.instance.LoseLife();
        }
    }

    void Update ()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        if ( transform.position.y < bottomY )
        {
            Destroy( this.gameObject );
            
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
        }
    }
}
