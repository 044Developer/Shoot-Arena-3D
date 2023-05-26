﻿namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt
{
    public interface IPlayerUltHandler
    {
        void SetUpPlayerUlt();
        void AddUltPoints(float newPoints);
        void UseUlt();
    }
}