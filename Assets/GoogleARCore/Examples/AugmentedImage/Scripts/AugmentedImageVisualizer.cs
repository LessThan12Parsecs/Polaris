//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using DG.Tweening;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;

        /// <summary>
        /// A model for the lower left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameLowerLeft;

        /// <summary>
        /// A model for the lower right corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameLowerRight;

        /// <summary>
        /// A model for the upper left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameUpperLeft;

        /// <summary>
        /// A model for the upper right corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameUpperRight;

        /// <summary>
        /// A model for the Arrows pointing to next waypoint.
        /// </summary>
        public GameObject ArrowPrefab;

        public GameObject arrowObject;

        public GameObject[] Buttons = new GameObject[4];

        private int arrowIndex = -1;

        /// <summary>
        /// A model for the Arrows pointing to next waypoint.
        /// </summary>
        public float Distance;

        bool resetPos;

        GameObject mainCamera;

        public GameObject PhoneObject;
        public GameObject ExitObject;
        public GameObject CouchObject;
        public GameObject PrinterObject;
        public GameObject userObject;

        /// <summary>
        /// The Unity Update method.
        /// </summary>


        // private void Awake() {
        //     // mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //     CouchObject = GameObject.FindGameObjectWithTag("CouchObject");
        //     PrinterObject = GameObject.FindGameObjectWithTag("PrinterObject");
        //     ExitObject = GameObject.FindGameObjectWithTag("ExitObject");
        //     PhoneObject = GameObject.FindGameObjectWithTag("PhoneObject");
        //     DeactivateObjects();
        // }

        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                FrameLowerLeft.SetActive(false);
                FrameLowerRight.SetActive(false);
                FrameUpperLeft.SetActive(false);
                FrameUpperRight.SetActive(false);
                for (int i = 0; i < 4; i++)
                {
                    Buttons[i].SetActive(false);
                }
                resetPos = true;
                return;
            }

            //TODO if image is = x ( ... )
            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;
            
            //TODO check if is better to leave it still until it's not tracking again. 
            FrameLowerLeft.transform.localPosition =
                (halfWidth * Vector3.left) + (halfHeight * Vector3.back);
            FrameLowerRight.transform.localPosition =
                (halfWidth * Vector3.right) + (halfHeight * Vector3.back);
            FrameUpperLeft.transform.localPosition =
                (halfWidth * Vector3.left) + (halfHeight * Vector3.forward);
            FrameUpperRight.transform.localPosition =
                (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);

            FrameLowerLeft.SetActive(true);
            FrameLowerRight.SetActive(true);
            FrameUpperLeft.SetActive(true);
            FrameUpperRight.SetActive(true);
                

            for (int i = 0; i < 4; i++)
            {
                Buttons[i].SetActive(true);
            }
            Buttons[0].transform.DOLocalMove(new Vector3(-0.1275f, 0f, 0.12f), 1f);
            Buttons[1].transform.DOLocalMove(new Vector3(-0.0425f, 0f, 0.12f), 1.2f);
            Buttons[2].transform.DOLocalMove(new Vector3(0.0425f, 0f, 0.12f), 1.4f);
            Buttons[3].transform.DOLocalMove(new Vector3(0.1275f, 0f, 0.12f), 1.6f);
            // if (resetPos) { //TODO not sure if this will work. Also needs to find which point it is.

            //     mainCamera.transform.position = Vector3.zero;
            //     resetPos = false;
            // }
        }

        public void PhoneButtonPressed(){
            // DeactivateObjects();
            // userObject.transform.position = Vector3.zero;
            PhoneObject.SetActive(true);
            arrowObject.SetActive(true); 
            arrowObject.GetComponent<LookAtObject>().ChangeTargetObject(PhoneObject);
        }
        public void CouchButtonPressed(){
            // DeactivateObjects();
            // userObject.transform.position = Vector3.zero;
            CouchObject.SetActive(true);
            arrowObject.SetActive(true);
            arrowObject.GetComponent<LookAtObject>().ChangeTargetObject(CouchObject);
        }
        public void ExitButtonPressed(){
            // DeactivateObjects();
            // userObject.transform.position = Vector3.zero;
            ExitObject.SetActive(true);
            arrowObject.SetActive(true);
            arrowObject.GetComponent<LookAtObject>().ChangeTargetObject(ExitObject);
        }
        public void PrinterButtonPressed(){
            // DeactivateObjects();
            // userObject.transform.position = Vector3.zero;
            PrinterObject.SetActive(true);
            arrowObject.SetActive(true);
            arrowObject.GetComponent<LookAtObject>().ChangeTargetObject(PrinterObject);
        }

        void DeactivateObjects(){
            CouchObject.SetActive(false);
            PrinterObject.SetActive(false);
            ExitObject.SetActive(false);
            PhoneObject.SetActive(false);
        }
    }
}
