using UnityEngine;

public class ScaleGameObject : MonoBehaviour
{
    // Set the minimum and maximum scales
    public Vector3 minScale = new Vector3(1f, 1f, 1f);
    public Vector3 maxScale = new Vector3(2f, 2f, 2f);

     
    public float animationSpeed = 2f;

    private void Update()
    {
        // Calculate the scale factor
        float scaleFactor = Mathf.PingPong(Time.time * animationSpeed, 1f);

         
        transform.localScale = Vector3.Lerp(minScale, maxScale, scaleFactor);
    }
}
