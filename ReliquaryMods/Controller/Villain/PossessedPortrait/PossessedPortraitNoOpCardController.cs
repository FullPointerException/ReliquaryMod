using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.PossessedPortrait
{
    public class PossessedPortraitNoOpCardController : CardController
    {
        public PossessedPortraitNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
