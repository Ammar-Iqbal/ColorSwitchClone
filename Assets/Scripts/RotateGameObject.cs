using UnityEngine;

public class RotateGameObject : MonoBehaviour
{

    public float rotationSpeed = 50f;
    private void Update()
    {
           transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
