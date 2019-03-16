using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Player;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
            transform.position = Player.position + Offset;
    }
}
