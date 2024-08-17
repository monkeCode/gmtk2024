﻿namespace UI.ResourcesInfo
{
    public class ArmyCounter: ResourceCounterBase
    {
        protected override string Template { get; set; } = "Army: ";

        protected override void Start()
        {
            base.Start();
            resourceManager.onArmyCountChanged.AddListener(HandleOnArmyCountChanged);
        }

        private void HandleOnArmyCountChanged()
        {
            SetCount(resourceManager.ArmyCount);
        }
    }
}