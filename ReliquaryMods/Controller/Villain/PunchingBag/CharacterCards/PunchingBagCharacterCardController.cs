using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.PunchingBag
{
    public class PunchingBagCharacterCardController : VillainCharacterCardController
    {
        public PunchingBagCharacterCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {

        }

        public override void AddSideTriggers()
        {
            
        }
    }
}