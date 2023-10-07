using Asteroids.Scripts.Game.Ship.Move.Base;
using Asteroids.Scripts.Game.Ship.Shoot.Base;

namespace Asteroids.Scripts.Game.Ship.Base;

public interface IShipModel
{
    IShipShootModel ShootModel { get; set; }
    IShipMoveModel MoveModel { get; set; }
}