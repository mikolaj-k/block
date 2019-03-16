using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Swipe SwipeControls;
    public Rigidbody Rigidbody;
    public Transform player;
    public float ForwardForce = 500f;
    public float SidewaysForce = 500f;
    public float JumpForce = 500f;
    public int Jumps = 2;

    private bool _onGround = true;
    private Touch _touch = new Touch() { position = new Vector2(Screen.width / 2f, Screen.height / 2f) };


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground")
            _onGround = true;
    }

    void OnCollisionExit()
    {
        _onGround = false;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
        }
        else
        {
            _touch = new Touch() { position = new Vector2(Screen.width / 2f, Screen.height / 2f) };
        }

        if (Rigidbody == null || player == null) return;

        Rigidbody.AddForce(0, 0, ForwardForce * Time.fixedDeltaTime);

        if (_onGround)
        {
            Jumps = 2;
        }

        if ((Input.GetKey(KeyCode.D) || _touch.position.x > Screen.width / 2f) && !SwipeControls.SwipeUp)
        {
            Rigidbody.AddForce(SidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if ((Input.GetKey(KeyCode.A) || _touch.position.x < Screen.width / 2f) && !SwipeControls.SwipeUp)
        {
            Rigidbody.AddForce(-SidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody.AddTorque(500f, 0, 0, ForceMode.VelocityChange);
        }

        if ((Input.GetKeyDown(KeyCode.W) || SwipeControls.SwipeUp && Jumps > 0) && Jumps > 0)
        {
            Jumps--;
            Rigidbody.AddForce(0, JumpForce * Time.fixedDeltaTime, 0, ForceMode.VelocityChange);
        }

        if (player.position.y < -5)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
