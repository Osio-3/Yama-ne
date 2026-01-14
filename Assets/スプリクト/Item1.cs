using UnityEngine;

public class Item1 : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("êGÇÍÇΩ: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Score.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
