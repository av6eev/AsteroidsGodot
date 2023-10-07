using Asteroids.Scripts.Game.Ship.Base;
using Asteroids.Scripts.Game.Ship.Move.Base;
using Asteroids.Scripts.Game.Ship.Shoot.Base;

namespace Asteroids.Scripts.Game.Ship;

public class ShipModel : IShipModel
{
    public IShipShootModel ShootModel { get; set; }
    public IShipMoveModel MoveModel { get; set; }
}