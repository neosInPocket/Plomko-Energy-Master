using UnityEngine;

public class MirrorBall : MonoBehaviour
{
    public void Initialize(float yPosition)
    {
        transform.position = new Vector2(0, yPosition);
    }
}
