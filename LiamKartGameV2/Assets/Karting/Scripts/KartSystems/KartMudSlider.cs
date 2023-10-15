using UnityEngine;

public class KartMudSlider : KartComponent
{
    [SerializeField] private GameObject slideEffect;
    private float forceMagnitude = 4500f;
    private bool isSliding = false;

    Vector3 randomForce;

    int timerId;

    private void Start()
    {
        if(slideEffect == null)
        {
            slideEffect = transform.Find("Effects").Find("SlideEffect")?.gameObject;
        }

        slideEffect?.SetActive(false);
    }

    public void StartSlide()
    {
        isSliding = true;
        kart.SetCanMove(false);

        //kart.Rigidbody.velocity = Vector3.zero;
        randomForce = (transform.forward * Random.Range(0, 0.5f) + transform.right * Random.Range(-1, 1)) * forceMagnitude;
        Debug.Log(randomForce);

        // If the player is not already free
        timerId = Timer.StartTimer(3f, StopSlide);

        // Stop nitro if used
        GetComponent<KartNitro>()?.StopNitro();

        slideEffect?.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (!isSliding)
            return;

        kart.Rigidbody.AddForce(randomForce, ForceMode.Force);
    }

    public void StopSlide()
    {
        if (Timer.TimerExists(timerId))
        {
            Timer.FinishTimer(timerId);
        }

        if (!isSliding)
            return;

        isSliding = false;
        //kart.Rigidbody.velocity = Vector3.zero;
        kart.SetCanMove(true);
        slideEffect?.SetActive(false);

    }
}
