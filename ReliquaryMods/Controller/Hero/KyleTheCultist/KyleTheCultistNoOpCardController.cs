using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.KyleTheCultist
{
    public class KyleTheCultistNoOpCardController : CardController
    {
        public KyleTheCultistNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
