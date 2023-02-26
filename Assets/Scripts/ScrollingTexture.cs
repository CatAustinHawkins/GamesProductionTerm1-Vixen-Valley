using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    public float ScrollY = 0.5f;

    private void Update()
    {
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, OffsetY);
    }
}
