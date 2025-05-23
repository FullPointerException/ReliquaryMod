using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Reliquary.Hydra
{
    public class HydraCharacterCardController : VillainCharacterCardController
    {
        public HydraCharacterCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {

        }

        public override void AddSideTriggers()
        {
            
        }
    }
}