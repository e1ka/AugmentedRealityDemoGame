/*==============================================================================
Copyright (c) 2016 PTC Inc. All Rights Reserved.

Copyright (c) 2013-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// Factory class that adds child class Behaviours
    /// </summary>
    public class VuforiaBehaviourComponentFactory : IBehaviourComponentFactory
    {
        #region PUBLIC_METHODS

        public MaskOutAbstractBehaviour AddMaskOutBehaviour(GameObject gameObject)
        {
            return gameObject.AddComponent<MaskOutBehaviour>();
        }

        public VirtualButtonAbstractBehaviour AddVirtualButtonBehaviour(GameObject gameObject)
        {
            return null;
        }

        public TurnOffAbstractBehaviour AddTurnOffBehaviour(GameObject gameObject)
        {
            return gameObject.AddComponent<TurnOffBehaviour>();
        }

        public ImageTargetAbstractBehaviour AddImageTargetBehaviour(GameObject gameObject)
        {
            return gameObject.AddComponent<ImageTargetBehaviour>();
        }

        public MultiTargetAbstractBehaviour AddMultiTargetBehaviour(GameObject gameObject)
        {
            return null;
        }

        public CylinderTargetAbstractBehaviour AddCylinderTargetBehaviour(GameObject gameObject)
        {
            return null;
        }

        public WordAbstractBehaviour AddWordBehaviour(GameObject gameObject)
        {
            return null;
        }

        public TextRecoAbstractBehaviour AddTextRecoBehaviour(GameObject gameObject)
        {
            return null;
        }

        public ObjectTargetAbstractBehaviour AddObjectTargetBehaviour(GameObject gameObject)
        {
            return null;
        }

        public VuMarkAbstractBehaviour AddVuMarkBehaviour(GameObject gameObject)
        {
            return null;
        }

        public VuforiaAbstractConfiguration CreateVuforiaConfiguration()
        {
            return ScriptableObject.CreateInstance<VuforiaConfiguration>();
        }

        #endregion // PUBLIC_METHODS
    }
}
