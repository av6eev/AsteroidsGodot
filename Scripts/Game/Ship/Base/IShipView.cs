using Asteroids.Scripts.Game.Bullet.Base;

namespace Asteroids.Scripts.Game.Ship.Base;

public interface IShipView
{
    void Move(float x, float y, double delta);
    void Rotate(float turnDirection, double delta);
    IBulletView InstantiateBullet();
}