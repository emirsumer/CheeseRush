using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        MouseyScript mousey = other.gameObject.GetComponent<MouseyScript>();
        if (mousey != null)
        {
            mousey.OnHitObstacle();
        }
    }
}
