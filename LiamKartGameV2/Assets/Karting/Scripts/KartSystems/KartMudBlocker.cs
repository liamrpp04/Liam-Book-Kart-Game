using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class KartMudBlocker : KartComponent
{
    [SerializeField] private int targetKeyRepeatTimes = 10;
    [SerializeField] private int secondsBlockedIA = 3;

    int keyRepeatTimes;
    float timerIA;
    bool isBlocked;

    MudObstacle mudObstacle;

    Vector3 defaultScale;
    Vector3 targetScale;
    private void Start()
    {
        defaultScale = transform.localScale;
        targetScale = defaultScale + Vector3.up * 0.122f;

    }

    public void Block(MudObstacle mudObstacle)
    {
        if (isBlocked) return;

        if (mudObstacle.hasPlayer)
        {
            return;
        }

        this.mudObstacle = mudObstacle;
        this.mudObstacle.hasPlayer = true;

        kart.Rigidbody.velocity = Vector3.zero;
        kart.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        kart.SetCanMove(false);
        keyRepeatTimes = 0;
        timerIA = 0;

        // Stop nitro if used
        GetComponent<KartNitro>()?.StopNitro();

        isBlocked = true;
        // UI
        if (isPlayer) MudBlockerHUD.Show();
    }

    public void Release()
    {
        this.mudObstacle.hasPlayer = false;
        mudObstacle = null;
        kart.Rigidbody.constraints = RigidbodyConstraints.None;
        kart.SetCanMove(true);
        transform.position = transform.position + Vector3.up * 0.14f;
        transform.localScale = defaultScale;

        isBlocked = false;
        // UI
        if (isPlayer) MudBlockerHUD.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlocked)
        {
            transform.position = Vector3.MoveTowards(transform.position, mudObstacle.transform.position, 0.1f);
            transform.localScale = Vector3.MoveTowards(transform.localScale, defaultScale, 0.005f);

            if (isPlayer)
            {
                bool isAttempt = MobileControlsHUD.Instance.IsMobile ? Input.GetMouseButtonDown(0) : Input.GetKeyDown(KeyCode.Space);
                if (isAttempt)
                {
                    SFXManager.PlaySound("mudPunch");
                    keyRepeatTimes++;

                    transform.localScale = targetScale;

                    if (keyRepeatTimes >= targetKeyRepeatTimes)
                    {
                        Release();
                    }
                }
            }
            else
            {
                timerIA += Time.deltaTime;
                if (timerIA >= secondsBlockedIA)
                {
                    Release();
                }
                //... IA
            }
        }
    }
}
