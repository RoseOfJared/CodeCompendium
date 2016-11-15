using UnityEngine;
using System.Collections;

public class MYCLASSNAME : MonoBehaviour {

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
	Corrosive
 }
 
 
 [Header("Gun Settings")]
 public int ammoCount = 10; //how much ammo in our clip
 public float damage= 100;
 public int totalAmmo = 120; //how much total ammo we have available
 public int reloadTime = 3; //how long it takes before we've reloaded
 public int reloadAmount = 10; //how many grenades we'll reload
 public float fireRate = 0.1f;
 public float force= 10;
 public float spreadFactor = 0.02f;

 [Header("Polish Effects")]
 public Transform Effect;
 public AudioClip gunshotSound;
 public AudioClip reloadGrenade; //sound clip to reload our grenade launcher
 public Material bulletHole; //material which appears on place when it is shot
 GUIText ammo; //our GUI text that displays our ammo in text format
 GUIText gunName; //Our GUI text that displays the gun name
 
 private float nextFire =0.0f;
 
  
 void  Update (){ 
     Fire ();
     Reload();
     OnGUI();
 }
  
 void  Fire (){
  
     if (ammoCount > 0) {
  
         if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
  
             nextFire = Time.time + fireRate;
  
             InstantiateGrenade();
  
             ammoCount -=1;
  
         }
  
     }
  
 }
  
 //---------------------------------------------------------------------------------
  
 void  InstantiateGrenade (){
     RaycastHit hit;
     Ray ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5f, Screen.height*0.5f, 0));
     
     if (Input.GetMouseButtonDown(0))
     {
         AudioSource.PlayClipAtPoint(gunshotSound, transform.position, 1);
         if (Physics.Raycast (ray, hit, 500))
         {
             FIXME_VAR_TYPE particleClone= Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
             FIXME_VAR_TYPE hitRotation= Quaternion.FromToRotation(Vector3.up, hit.normal);
             Instantiate(bulletHole, hit.point, hitRotation);
             Destroy(particleClone.gameObject, 2);
             hit.transform.SendMessage("ApplyDammage", TheDammage, SendMessageOptions.DontRequireReceiver);
         }
     }
 }
  
 //---------------------------------------------------------------------------------
  
 void  Reload ()
 {
    if(ammoCount < 1 && totalAmmo > 10) { //if we have less than 1 bullet then we can reload
	{
  
		if(Input.GetKeyDown("r")) 
		{
			AudioSource.PlayClipAtPoint(reloadGrenade, transform.position, 1); //plays reload soundclip
			yield return new WaitForSeconds(reloadTime); //waits for "reloadTime" before adding ammo
			ammoCount += reloadAmount; //adds ammo to our "clip" based off the reloadAmount
			totalAmmo -= reloadAmount; //subtracts whatever the reloadAmount was from our total ammo every time we reload
		}
  
	}
  
 }
  
 //---------------------------------------------------------------------------------
  
 void  OnGUI ()
 {
   //displays our GUI Text in the format we want. The sections in "" will appear exactly as their written
	ammo.text = "Ammo: " + ammoCount + "/" +  totalAmmo.ToString();
  
 }
}