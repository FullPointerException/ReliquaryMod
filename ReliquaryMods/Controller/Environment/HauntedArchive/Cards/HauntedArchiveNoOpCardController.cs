using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.HauntedArchive
{
    public class HauntedArchiveNoOpCardController : CardController
    {
        public HauntedArchiveNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
