using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.ForbiddenWing
{
    public class ForbiddenWingNoOpCardController : CardController
    {
        public ForbiddenWingNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
