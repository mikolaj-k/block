using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject Player;
    public GameObject DestroyedVersion;

    public string ObstacleName = "Obstacle";

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != ObstacleName) return;
        if (Player == null) return;

        Instantiate(DestroyedVersion, Player.transform.position + new Vector3(-2, -0.3f, 0.8f), Player.transform.rotation);
        Destroy(Player);
        FindObjectOfType<GameManager>().EndGame();
    }
}
