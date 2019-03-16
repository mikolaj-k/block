using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Player;
    public Text ScoreText;

    void Update()
    {
        if (Player != null)
            ScoreText.text = ((int)Player.position.z).ToString();
    }
}
