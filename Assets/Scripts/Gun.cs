using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] protected float shakeIntensity;
    [SerializeField] protected float shakeTime;

    private Vector3 mousePos;
    private Camera cam;
    private GunUI gunUI;
    [SerializeField] protected Bullet bullet;
    [SerializeField] private float fireDelay;
    [SerializeField] private float reloadDelay;
    [SerializeField] private int loadSize;
    [SerializeField] protected float coneSize;
    [SerializeField] protected GameObject bulletSpot;
    [SerializeField] FMODUnity.EventReference reloadSFX;
    private float fClock;
    private float rClock;
    private int inLoad;


    private PlayerControllerInputAsset input;
    public InputAction playerShoot { get; private set; }
    public InputAction playerAim { get; private set; }
    public InputAction playerReload { get; private set; }

    public bool usingArcadeMachine;
    Vector2 aim;


    // Start is called before the first frame update
    void Awake()
    {
        fClock = 0;
        rClock = 0;
        inLoad = loadSize;
        cam = FindObjectOfType<Camera>();
        gunUI = FindObjectOfType<GunUI>();

        input = new PlayerControllerInputAsset();

        playerShoot = input.Player.Fire;
        playerAim = input.Player.Aim;
        playerReload = input.Player.reload;
        usingArcadeMachine = false;

        playerReload.performed += content => reload();
        

    }

    void OnEnable()
    {
        gunUI.setMax(loadSize);
        playerShoot.Enable();
        playerAim.Enable();
        playerReload.Enable();
    }

    private void OnDisable()
    {
        playerShoot.Disable();
        playerAim.Disable();
        playerReload.Disable();
    }



    // Update is called once per frame
    void Update()
    {
        aim = playerAim.ReadValue<Vector2>();
        
        if (aim.magnitude>0)
        {
            usingArcadeMachine = true;
        }

        Vector3 direction;
        if (!usingArcadeMachine)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos - gameObject.transform.position;
        }
        else
        {
            direction = new Vector3(aim.x, aim.y, 0f);
        }
        
        Vector2 velocity = (new Vector2(direction.x, direction.y)).normalized;

        
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            reload();
        }
        if (getShootInput() && fClock <= 0 && inLoad > 0 && rClock <= 0)
        {
            shoot();
            
            if (inLoad == 0)
            {
                reload();
            }
        }
        Aim(velocity, fClock <= 0 || rClock > 0);


        fClock -= Time.deltaTime;
        rClock -= Time.deltaTime;
    }

    virtual protected bool getShootInput() {

        return playerShoot.ReadValue<float>()>0;
    }

    virtual protected void shoot()
    {
        transform.rotation = Quaternion.AngleAxis(UnityEngine.Random.Range(-coneSize / 2f, coneSize / 2f), new Vector3(0, 0, 1)) * transform.rotation;
        Instantiate(bullet, bulletSpot.transform.position, transform.rotation);
        CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime);
        updateBullets();
    }

    protected void updateBullets()
    {
        fClock = fireDelay;
        inLoad -= 1;
        gunUI.updateUI(inLoad);
    }

    private void Aim(Vector2 dir, bool complete)
    {
        if (!complete)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg)), transform.rotation, .75f * Mathf.Pow(0.5f, Time.deltaTime));
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
        }
    }

    private void reload()
    {
        inLoad = loadSize;
        rClock = reloadDelay;
        FindObjectOfType<GunUI>().reload(reloadDelay);
        FMODUnity.RuntimeManager.PlayOneShot(reloadSFX);
    }

    public int getBullets()
    {
        return inLoad;
    }

    public int getMax()
    {
        return loadSize;
    }

}
