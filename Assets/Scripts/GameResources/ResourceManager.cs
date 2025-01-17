﻿using System;
using DefaultNamespace;
using Models;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace GameResources
{
    public class ResourceManager: MonoBehaviour
    {
       [SerializeField] private int _moneyCount;
        public int MoneyCount
        {
            get => _moneyCount;
            private set
            {
                _moneyCount = value;
                onMoneyCountChanged.Invoke();
            }
        }

        [SerializeField] private int _foodCount;
        public int FoodCount
        {
            get => _foodCount;
            private set
            {
                _foodCount = value;
                onFoodCountChanged.Invoke();
            }
        }

        [SerializeField] private int _armyCount;
        public int ArmyCount
        {
            get => _armyCount;
            private set
            {
                _armyCount = value;
                onArmyCountChanged.Invoke();
            }
        }

        public UnityEvent onMoneyCountChanged = new();
        public UnityEvent onFoodCountChanged = new();
        public UnityEvent onArmyCountChanged = new();
        
        public void AddMoney(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Value can't be < 0");
            }

            if (Flags.BookkeepingMistakeEventFlag && BookkeepingEventActionResult(TrySpendMoney, count))
                return;

            MoneyCount += count;
        }

        public bool TrySpendMoney(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Value can't be < 0");
            }

            if (MoneyCount < count)
            {
                return false;
            }

            MoneyCount -= count;
            return true;
        }

        public void AddFood(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Value can't be < 0");
            }
            
            FoodCount += count;
        }
        
        public bool TrySpendFood(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Value can't be < 0");
            }

            if (FoodCount < count)
            {
                return false;
            }

            FoodCount -= count;
            return true;
        }

        public void AddArmy(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Value can't be < 0");
            }
            
            ArmyCount += count;
        }
        
        public bool TrySpendArmy(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Value can't be < 0");
            }

            if (ArmyCount < count)
            {
                return false;
            }

            ArmyCount -= count;
            return true;
        }

        public bool TrySpendResources(BuildingPrice price)
        {
            if (MoneyCount < price.MoneyPrice || FoodCount < price.FoodPrice || ArmyCount < price.ArmyPrice)
            {
                return false;
            }

            MoneyCount -= price.MoneyPrice;
            FoodCount -= price.FoodPrice;
            ArmyCount -= price.ArmyPrice;
            return true;
        }

        private bool BookkeepingEventActionResult(Func<int, bool> action, int count)
        {
            if (Random.value > 0.6)
            {
                action(count);
                return true;
            }
            return false;

        }
    }
}