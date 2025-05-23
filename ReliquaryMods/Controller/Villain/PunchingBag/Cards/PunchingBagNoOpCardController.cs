using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.PunchingBag
{
    public class PunchingBagNoOpCardController : CardController
    {
        public PunchingBagNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
