// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System;
namespace FootMoovTeam
{
	public class DemoFootMoovListener : MonoBehaviour, FootMoovListener
	{
		public DemoFootMoovListener ()
		{

		}
		
		public void OnBackTap(object sender) {
			print("Back Tap!");
		}
		
		public void OnFrontTap(object sender) {
			print("Front Tap!");
		}
	}
}