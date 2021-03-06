﻿using UnityEngine;
using System.Collections;

public class TriggerTransitionScreens : MonoBehaviour {

	public enum Fade { FadeIn, FadeOut }

	public Fade m_fade;

	void OnTriggerEnter( Collider col ) {
		if( col.tag == "Player" && Network.isServer ) {
			if( m_fade == Fade.FadeIn ) {
				StartCoroutine( GoToLevelTwo() );
			}
			else
				GUIManager.instance.FadeTransitionScreen( true );
		}
	}

	IEnumerator GoToLevelTwo() {
		GUIManager.instance.FadeTransitionScreen( false );
		GUIManager.instance.networkView.RPC( "FadeTransitionScreen", RPCMode.Others, false );
		yield return new WaitForSeconds( 2f );
		GameManager.instance.TransitionToLevel( 2 );
	}
}
