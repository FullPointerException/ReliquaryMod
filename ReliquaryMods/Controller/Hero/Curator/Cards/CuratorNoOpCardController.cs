using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.Curator
{
    public class CuratorNoOpCardController : CardController
    {

        public CuratorNoOpCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }

    }
}
