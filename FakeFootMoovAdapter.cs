using UnityEngine;
using System.Collections;

namespace FootMoovTeam {
	
	public class FakeFootMoovAdapter : MonoBehaviour {

		public MorseFootMoovListener listener;
		private event OnFrontTapEvent OnFrontTap;
		private event OnBackTapEvent OnBackTap;

		void Awake() {
			OnBackTap += new OnBackTapEvent (listener.OnBackTap);
			OnFrontTap += new OnFrontTapEvent (listener.OnFrontTap);
		}

		void Update () {
			
			UpdateBackTap ();
			UpdateFrontTap ();

		}
		
		private void UpdateBackTap() {
			if (Input.GetKeyUp (KeyCode.B)) {
				OnBackTap (this);
			}
		}
		
		private void UpdateFrontTap() {
			if (Input.GetKeyUp (KeyCode.F)) {
				OnFrontTap (this);
			}
		}
	}
}