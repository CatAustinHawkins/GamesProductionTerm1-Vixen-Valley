using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Transform CameraTransform;//get the cameras position

    public float ShakeDuration = 0f;//how long to shake the camera, set to 0 so it doesnt automatically start shaking

    public float ShakeAmount = 0.05f;//how much to shake the camera
    public float DecreaseFactor = 1.0f;//how quickly the camera should slow down

    public Vector3 OriginalPosition;//get the cameras original position

    private void Awake()
    {
        if(CameraTransform == null)
        {
            CameraTransform = GetComponent(typeof(Transform)) as Transform;//get the cameras transform position
        }
    }

    private void OnEnable()
    {
        OriginalPosition = CameraTransform.localPosition;//set original position to the cameras position 
    }

    private void Update()
    {
        if(ShakeDuration > 0)
        {
            CameraTransform.localPosition = OriginalPosition + UnityEngine.Random.insideUnitSphere * ShakeAmount;//move the camera around based on Random and the ShakeAmount

            ShakeDuration -= Time.deltaTime * DecreaseFactor;//reduce the shake duration until it reaches 0.
        }
        else
        {
            ShakeDuration = 0f;//stop camera shake
            CameraTransform.localPosition = OriginalPosition;//reset camera position to original
        }
    }


    public void CameraBeginShake()//function triggered by another script
    {
        ShakeDuration = 0.5f;//make the camera shake for 0.5f time.
    }

}
