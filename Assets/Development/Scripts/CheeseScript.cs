using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MouseyScript>())
        {
            UIManager.Instance.UpdateCheeseText();
            Destroy(gameObject);
            AudioManager.Instance.PlayCheese();
        }
    }
}
