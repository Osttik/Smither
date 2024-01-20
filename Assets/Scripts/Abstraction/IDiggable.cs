using Assets.Core;
using Assets.Core.Inventory;

namespace Assets.Scripts.Abstraction
{
    public interface IDiggable: IInteractable
    {
        public string RequiredToolType { get; set; }

        public Item Dig(Tool tool);
        public bool IsEmpty();
    }
}
