using TT.Entity.Controller;

namespace TT.Entity.Base
{
    public interface IHit
    {
        void TakeHit(EntityController attacker);
    }
}