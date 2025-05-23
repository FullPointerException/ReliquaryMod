using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.Mannequin
{
    public class MannequinNoOpCardController : CardController
    {
        public MannequinNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
