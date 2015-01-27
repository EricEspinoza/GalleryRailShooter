﻿using UnityEngine;
using System.Collections;

public class Desk : MonoBehaviour {

	public Target[] m_targets;
	private bool m_allTargetsHit;
	private Room m_room;
	private bool m_active;

	// Use this for initialization
	void Start () {
		m_targets = GetComponentsInChildren<Target>();	
		m_room = transform.parent.GetComponent<Room>();
		m_allTargetsHit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if( m_active ) {
			// If any of the targets have not been hit return
			foreach( Target target in m_targets ) {
				if( target.IsHit() == false) 
					return;
			}

			m_allTargetsHit = true;
		}
	}

	public bool AllTargetsHit() {
		return m_allTargetsHit;
	}

	public void Activate() {
		m_active = true;
	}
}
