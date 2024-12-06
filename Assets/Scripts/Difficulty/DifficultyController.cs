﻿using System;
using Coins;
using JetBrains.Annotations;
using Modules;
using UnityEngine;
using Zenject;

namespace DifficultySystem
{
    [UsedImplicitly]
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly CoinSystem _coinSystem;
        private readonly IDifficulty _difficulty;

        public DifficultyController(CoinSystem coinSystem, IDifficulty difficulty, ISnake player)
        {
            _coinSystem = coinSystem;
            _difficulty = difficulty;
        }

        void IInitializable.Initialize()
        {
            _coinSystem.OnAllCoinsCollected += AddDifficulty;
            AddDifficulty();
        }

        private void AddDifficulty()
        {
            _difficulty.Next(out int difficulty);
        }

        void IDisposable.Dispose()
        {
            _coinSystem.OnAllCoinsCollected -= AddDifficulty;
        }
    }
}