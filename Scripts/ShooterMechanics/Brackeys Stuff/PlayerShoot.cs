using UnityEngine;

public class PlayerShoot : Monobehaviour
{
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }


	void Update()
    {
       // if()
        //{

        //}

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            //We hit something
            Debug.Log("We hit " + hit.collider.name);

        }
    }

}
