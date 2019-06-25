using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour {
	public Camera cam;
	private AudioSource audios;
	private bool[] played=new bool[9];
	private int stringNo;
	private char ch;
    private long[] savedTime=new long[26];
    private long currentTime;
    private bool added=false;
	public ParticleSystem Particle1;
	public ParticleSystem Particle2;



	void Start(){
		ch = gameObject.tag[0];
		audios = GetComponent<AudioSource> ();

		for (char c='c'; c < 'l'; c++) {
			if (ch == c) {
				stringNo = System.Convert.ToInt16(c)-System.Convert.ToInt16('c');
				Debug.Log ("played" + stringNo);
			}
		}
        for(int i = 0; i < savedTime.Length; i++)
        {
            savedTime[i] = 0;
        }
	}
	// Update is called once per frame
	void Update () {
        added = false;
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, cam.nearClipPlane)); 
					//cam.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == gameObject.tag && played [stringNo] == false) {
                currentTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                for (int i = 0; i < savedTime.Length; i++)
                {
                    if (added == false) {
                        if (savedTime[i] == 0)
                        {
                            Debug.Log("Saved with init cond");
                            added = true;
                            savedTime[i] = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                            audioPlay(hit);
                        }
                        else if (savedTime[i] != 0 && savedTime[i]+4000<currentTime)
                        {
                            Debug.Log("Saved with sec cond");
                            added = true;
                            savedTime[i] = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                            audioPlay(hit);
                        }
                        else
                        {
                            Debug.Log("Denied play");
                        }

                }
                }


				} 

			} else {
				played [stringNo] = false;
				Particle1.Stop ();
				Particle2.Stop ();
			}
		}
	}
    void audioPlay(RaycastHit c)
    {
        played[stringNo] = true;
        Transform objectHit = c.transform;
        Debug.Log("Hit the string " + stringNo);
        audios.PlayOneShot(audios.clip, 0.5F);
        Handheld.Vibrate();
		Particle1.Play ();
		Particle2.Play ();
    }
}
