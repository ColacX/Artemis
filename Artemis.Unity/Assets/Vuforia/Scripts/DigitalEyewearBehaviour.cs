/*==============================================================================
Copyright (c) 2015 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using System.Collections;
using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// The DigitalEyewearBehaviour class handles the configuration of
    /// eyewear devices. It is responsible for enabling stereo rendering.
    /// </summary>
    public class DigitalEyewearBehaviour : DigitalEyewearAbstractBehaviour
    {
		public bool steroscopicMode = true;

		private static DigitalEyewearBehaviour mDigitalEyewearBehaviour = null;

        /// <summary>
        /// A simple static singleton getter to the DigitalEyewearBehaviour (if present in the scene)
        /// Will return null if no DigitalEyewearBehaviour has been instanciated in the scene.
        /// </summary>
        public static DigitalEyewearBehaviour Instance
        {
            get
            {
                if (mDigitalEyewearBehaviour == null)
                    mDigitalEyewearBehaviour = FindObjectOfType<DigitalEyewearBehaviour>();

                return mDigitalEyewearBehaviour;
            }
        }

		//public void Start()
		//{
		//	StartCoroutine("CheckStuff");
		//}

		//public IEnumerator CheckStuff()
		//{
		//	while(true)
		//	{
		//		if(Input.GetKeyDown(KeyCode.Escape))
		//		{
		//			steroscopicMode = !steroscopicMode;

		//			if(steroscopicMode)
		//			{
		//				Instance.SetEyewearType(DigitalEyewearAbstractBehaviour.EyewearType.VideoSeeThrough);
		//				Instance.SetViewerActive(true, true);
		//			}
		//			else
		//			{
		//				Instance.SetEyewearType(DigitalEyewearAbstractBehaviour.EyewearType.None);
		//				Instance.SetViewerActive(false, true);
		//			}
		//		}

		//		yield return new WaitForSeconds(1f);
		//	}

		//}
	}
}
