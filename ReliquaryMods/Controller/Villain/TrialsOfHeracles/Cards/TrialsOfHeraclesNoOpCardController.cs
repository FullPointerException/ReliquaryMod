using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.TrialsOfHeracles
{
    public class TrialsOfHeraclesNoOpCardController : CardController
    {
        public TrialsOfHeraclesNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
