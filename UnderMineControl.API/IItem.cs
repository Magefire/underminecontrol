using System.Collections.Generic;
using Thor;
using static Thor.EntityData;
using static Thor.ItemData;

namespace UnderMineControl.API
{
    /// <summary>
    /// Used to create items
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Creates the Item's data
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="displayName"></param>
        /// <param name="description"></param>
        /// <param name="flavor"></param>
        /// <param name="iconFilePath"></param>
        /// <param name="rarity"></param>
        /// <param name="goldCost"></param>
        /// <param name="Hint"></param>
        /// <param name="slot"></param>
        /// <param name="tags"></param>
        /// <param name="dropRequirements"></param>
        /// <param name="discoverRequirements"></param>
        /// <param name="pickedUpBehaviour"></param>
        /// <param name="secondaryPickedUpBehaviour"></param>
        /// <param name="isDefault"></param>
        /// <param name="isDefaultDiscorvered"></param>
        /// <param name="isDepreciated"></param>
        /// <param name="autoUnlock"></param>
        /// <param name="rerollable"></param>
        /// <param name="comboPiece"></param>
        /// <param name="comboResult"></param>
        /// <param name="isSpecialDrop"></param>
        /// <param name="isSpecialDiscovery"></param>
        /// <param name="maxDropCount"></param>
        /// <param name="userData"></param>
        /// <param name="audio"></param>
        void Initialise(string guid, string displayName, string description, string flavor, string iconFilePath, RarityType rarity, int goldCost, ItemHint Hint, string slot, List<Tag> tags, List<Requirement> dropRequirements, List<Requirement> discoverRequirements, ExtendedExternalBehaviorTree pickedUpBehaviour, ExtendedExternalBehaviorTree secondaryPickedUpBehaviour, bool isDefault = true, bool isDefaultDiscorvered = true, bool isDepreciated = false, bool autoUnlock = true, bool rerollable = true, ItemData comboPiece = null, ItemData comboResult = null, bool isSpecialDrop = false, bool isSpecialDiscovery = false, int maxDropCount = 1, int userData = 0, string audio = "event:/Items/Items_Land");
    }
}
