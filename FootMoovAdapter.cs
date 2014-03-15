using UnityEngine;
using System.Collections;

namespace FootMoovTeam {
	
	public delegate void OnBackTapEvent(object sender);
	public delegate void OnFrontTapEvent(object sender);

	public abstract class PressureButton {

		// Thresholds
		private const float TAP_ACTIVATION_THRESHOLD = 50f;
		private const float TAP_DELTA_THRESHOLD = 100f;

		private float lastPression = 0f;

		protected Connector connector;

		public PressureButton(Connector connector) {
			this.connector = connector;
		}

		abstract protected float getCurrentPression();

		public bool isTap() {
			float currentPression = getCurrentPression ();

			if ((currentPression - lastPression) > TAP_DELTA_THRESHOLD) {
				return true;
			}
			lastPression = currentPression;
			return false;
		}

		public bool isOverThreshold() {
			return getCurrentPression() > TAP_ACTIVATION_THRESHOLD;
		}
	}

	public class FrontPressureButton : PressureButton {

		public FrontPressureButton(Connector connector) : base(connector) {

		}

		protected override float getCurrentPression() {
			return connector.pression2;
		}

	}
	
	public class BackPressureButton : PressureButton {

		public BackPressureButton(Connector connector) : base(connector) {}

		protected override float getCurrentPression() {
			return connector.pression1;
		}
		
	}

	public class FootMoovAdapter : MonoBehaviour {

		// Last values
		private float lastBackTapValue = 0f;
		private float lastFrontTapValue = 0f;
		
		private PressureButton backButton;
		private PressureButton frontButton;

		// States
		private bool isBackTap = false;
		private bool isFrontTap = false;

		public Connector connector;
		public FootMoovListener listener = new DemoFootMoovListener();
		private event OnFrontTapEvent OnFrontTap;
		private event OnBackTapEvent OnBackTap;

		void Awake() {
			backButton = new BackPressureButton (connector);
			frontButton = new FrontPressureButton (connector);

			OnBackTap += new OnBackTapEvent (listener.OnBackTap);
			OnFrontTap += new OnFrontTapEvent (listener.OnFrontTap);
		}

		void Update () {
			
			UpdateBackTap ();
			UpdateFrontTap ();

		}
		
		private void UpdateBackTap() {
			if (backButton.isTap () && backButton.isOverThreshold() && !isBackTap) {
				isBackTap = true;
				OnBackTap (this);
			} else if(!backButton.isOverThreshold()) {
				isBackTap = false;
			}
		}
		
		private void UpdateFrontTap() {
			if (frontButton.isTap () && frontButton.isOverThreshold() && !isFrontTap) {
				isFrontTap = true;
				OnFrontTap (this);
			} else if(!frontButton.isOverThreshold()) {
				isFrontTap = false;
			}
		}
		
//		private void UpdateBackTap() {
//			float currentPression = connector.pression1;
//			float lastPression = lastBackTapValue;
//			bool isTap = isFrontTap;
//			
//			if (currentPression > TAP_ACTIVATION_THRESHOLD) {
//				if((currentPression - lastPression) > TAP_DELTA_THRESHOLD &&
//				   !isFrontTap && OnFrontTap != null) {
//					isTap = true;
//					OnFrontTap (this);
//				}
//			} else if (currentPression < TAP_ACTIVATION_THRESHOLD) {
//				isFrontTap = false;
//			}
//			lastPression = currentPression;
//			
//			lastFrontTapValue = lastPression;
//			isFrontTap = isTap;
//		}
//		
//		private void UpdateFrontTap() {
//			float currentPression = connector.pression2;
//			float lastPression = lastFrontTapValue;
//			bool isTap = isFrontTap;
//
//			if (currentPression > TAP_ACTIVATION_THRESHOLD) {
//				if((currentPression - lastPression) > TAP_DELTA_THRESHOLD &&
//				   !isFrontTap && OnFrontTap != null) {
//					isTap = true;
//					OnFrontTap (this);
//				}
//			} else if (currentPression < TAP_ACTIVATION_THRESHOLD) {
//				isFrontTap = false;
//			}
//			lastPression = currentPression;
//
//			lastFrontTapValue = lastPression;
//			isFrontTap = isTap;
//		}

//		private void UpdateTap(float currentPression, float lastPression, bool isTap) {
//			if (currentPression > TAP_ACTIVATION_THRESHOLD) {
////				print ("frontTap!");
//				if((currentPression - lastPression) > TAP_DELTA_THRESHOLD &&
//				   !isFrontTap && OnFrontTap != null) {
//					isTap = true;
//					OnFrontTap (this);
//				}
//			} else if (currentPression < TAP_ACTIVATION_THRESHOLD) {
//				isFrontTap = false;
//			}
//			lastPression = currentPression;
//		}
	}
}