using UnityEngine;

public class GunTestWork : MonoBehaviour
{
	public enum FiringType
	{
		SemiAuto,
		FullAuto,
		BurstAuto,
		BoltAction,
		PumpAction,
		LeverAction
	}

	public enum DamageType
	{
		Ballistic,
		Arc,
		Scorch,
		Corrosive, 
		Explosive
	}
 
	
	[Header("Gun Stats")]
	[Tooltip("The damage the gun deals")]
	public int damage = 1;
	[Tooltip("How fast the gun fires")]
	public float fireRate = .25f;
	[Tooltip("The effective range of the gun")]
	public float range = 50f;
	[Tooltip("How many shots can be fired before needing to reload")]
    public int magSize = 10;
	[Tooltip("How much ammo carried for the gun")]
	public int ammoCount;
	[Tooltip("How much is the max ammo")]
	public int maxAmmo;
	[Tooltip("How long does the reload take")]
	public float reloadTime = 3;
	[Tooltip("How spread out bullets are")]
    public float spreadFactor;
	[Tooltip("How much the gun kicks")]
	public float recoil;
	[Tooltip("What typr of gun it is")]
	public FiringType firingType;
	[Tooltip("Whether this has seperate effects")]
	public DamageType damageType;
	[Tooltip("The wait time before next shot")]
	public float timeBetweenShots = .3f;
	

	[Header("Polish")]
	public bool isDebugOn = false;
	public ParticleSystem smokeParticles;
	public GameObject hitParticles;
	public GameObject shootFlare;
	public Transform gunEnd;
	
	private Camera fpsCam;
	private LineRenderer lineRenderer;
	private WaitForSeconds shotLength = new WaitForSeconds(0.07f);
	private AudioSource source;
	private float nextFireTime;
	
	void Awake()
	{
		if(isDebugOn)
		{
			lineRenderer = GetComponent<LineRenderer>();
		}
		
		source = GetComponent<AudioSource>();
		fpsCam = GetComponentInParent<Camera>();
	}
	
	
	void Update()
	{
		//RaycastHit hit;
		//Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		
		CheckFiringType();
		
	}
	
	void AutoShot()
	{
		if(Input.GetButton("Fire1") && Time.time > nextFireTime && ammoCount > 0)
		{
			nextFireTime = Time.time + fireRate;
			ammoCount -= 1;
			
			if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
			{
				if(hit.transform.gameObject.tag == "Enemy")
				{
					hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReciever);
				}
				
				if(hit.transform.gameObject.tag == "Structure")
				{
					Instantiate(bulletTex, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
				}
				
				if(hit.rigidbody != null)
				{
					hit.rigidbody.AddForce(-hit.normal * 100f);
				}
				
				if(isDebugOn)
				{
					lineRenderer.SetPosition(0, gunEnd.position);
					lineRenderer.SetPosition(1, hit.point);
				}
				Instantiate(hitParticles, hit.point, Quaternion.identity);
			}
			StartCoroutine(ShotEffect_cr());
		}
	}
	
	void SemiShot()
	{
		if(Input.GetButtonDown("Fire1") && Time.time > nextFireTime && ammoCount > 0)
		{
			nextFireTime = Time.time + fireRate;
			ammoCount -= 1;
			
			if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
			{
				IDamageable dmgScript = hit.collider.gameObject.GetComponent<EnemyHealth>();
				if(dmgScript != null)
				{
					dmgScript.Damage(damage, hit.point);
				}
				
				if(hit.rigidbody != null)
				{
					hit.rigidbody.AddForce(-hit.normal * 100f);
				}
				
				if(isDebugOn)
				{
					lineRenderer.SetPosition(0, gunEnd.position);
					lineRenderer.SetPosition(1, hit.point);
				}
				Instantiate(hitParticles, hit.point, Quaternion.identity);
			}
			StartCoroutine(ShotEffect_cr());
		}
	}
	
	void BurstShot()
	{
		if(Input.GetButtonDown("Fire1") && Time.time > nextFireTime && ammoCount > 0))
		{
			
		}
	}
	
	void CheckFiringType(FiringType firingType)
	{
		switch(weaponType)
		{
			case firingType.SemiAuto:
			Debug.Log("Semi Auto");
			SemiShot();
			break;
			
			case firingType.FullAuto:
			Debug.Log("Full Auto");
			FullShot();
			break;
		
			case firingType.BurstAuto:
			Debug.Log("Burst Auto");
			BurstShot();
			break;
		
			case weaponType.BoltAction:
			Debug.Log("Bolt Action");
			SemiAuto();
			break;
		
			case weaponType.LeverAction:
			Debug.Log("Lever Action");
			SemiAuto();
			break;
		
			case weaponType.PumpAction:
			Debug.Log("Pump Action");
			SemiAuto();
			break;
		
		}
	}
	
	private IEnumerator ShotEffect_cr()
	{
		lineRenderer.enabled = true;
		source.Play();
		smokeParticles.Play();
		shootFlare.SetActive(true);
		
		yield return shotLength;
		
		lineRenderer.enabled = false;
		shootFlare.SetActive(false);
	}
	
	//Test code for bullet spread
	/*
	
		Vector3 pos = Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane);
		pos += Random.insideUnitCircle * spreadFactor;
		Ray ray = Camera.main.ScreenPointToRay(pos)
		RaycastHit hit;
		
		if(Physics.Raycast(ray, hit, maxDist))
		{
			
		}
	
		if(Time.time > nextShot)
		{
			float randomNumberX = Random.Range(-spreadFactor, spreadFactor);
			float randomNumberY = Random.Range(-spreadFactor, spreadFactor);
			float randomNumberZ = Random.Range(-spreadFactor, spreadFactor);
			
			ray.direction.x += randomNumberX;
			ray.direction.y += randomNumberY;
			ray.direction.z += randomNumberZ;
			
			if(Physics.Raycast(new Ray(rayOrigin, rayOrigin + ray.direction * 100), hit, 1000))
			{
				if(hit.transform.gameObject.tag == "Structure")
				{
					Instantiate(bulletTex, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
				}
			}
			
			if(Physics.Raycast(new Ray(rayOrigin, rayOrigin + ray.direction * 100), hit, 1000))
			{
				if(hit.transform.gameObject.tag == "Enemy")
				{
					hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReciever);
				}
			}
			
			
		}
	
	
	*/
}











