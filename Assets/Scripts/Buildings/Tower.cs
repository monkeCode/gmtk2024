﻿namespace Buildings
{
    public class Tower: BuildingBase
    {
        protected override int Income => Constants.Buildings.TowerIncome;

        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            ResourceManager.AddArmy(Income);
        }
    }
}