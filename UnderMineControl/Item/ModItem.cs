using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thor;
using UnderMineControl.API;
using UnityEngine;

namespace UnderMineControl.Item
{
    class ModItem : ItemData,IItem
    {
        private readonly API.ILogger _logger;
        private readonly IPatcher _patcher;
        public ModItem(API.ILogger logger, IPatcher patcher)
        {
            _logger = logger;
            _patcher = patcher;
        }
        public void Initialise(string guid, string displayName, string description, string flavor, string iconFilePath, RarityType rarity, int goldCost, ItemHint Hint, string slot, List<Tag> tags, List<Requirement> dropRequirements,List<Requirement> discoverRequirements, ExtendedExternalBehaviorTree pickedUpBehaviour,ExtendedExternalBehaviorTree secondaryPickedUpBehaviour,bool isDefault = true, bool isDefaultDiscorvered = true, bool isDepreciated = false, bool autoUnlock = true, bool rerollable = true, ItemData comboPiece = null, ItemData comboResult = null,bool isSpecialDrop = false,bool isSpecialDiscovery=false,int maxDropCount = 1,int userData = 0,string audio = "event:/Items/Items_Land")
        {
            _patcher.SetField(this, "m_guid",guid,typeof(DataObject));
            _patcher.SetField(this, "m_hint", ItemHint.Relic, typeof(ItemData));
            _patcher.SetField(this, "m_slot", slot, typeof(ItemData));
            _patcher.SetField(this, "m_audio", audio, typeof(ItemData));
            _patcher.SetField(this, "m_tags", tags, typeof(ItemData));
            _patcher.SetField(this, "m_maxDropCount", maxDropCount, typeof(ItemData));
            _patcher.SetField(this, "m_isDefault", isDefault, typeof(ItemData));
            _patcher.SetField(this, "m_isDefaultDiscovered", isDefaultDiscorvered, typeof(ItemData));
            _patcher.SetField(this, "m_isDeprecated", isDepreciated, typeof(ItemData));
            _patcher.SetField(this, "m_autoUnlock", autoUnlock, typeof(ItemData));
            _patcher.SetField(this, "m_rerollable", rerollable, typeof(ItemData));
            _patcher.SetField(this, "m_comboPiece", comboPiece, typeof(ItemData));
            _patcher.SetField(this, "m_comboResult", comboResult, typeof(ItemData));
            _patcher.SetField(this, "m_userData", userData, typeof(ItemData));
            _patcher.SetField(this, "m_dropRequirements", dropRequirements, typeof(ItemData));
            _patcher.SetField(this, "m_discoverRequirements", discoverRequirements, typeof(ItemData));
            _patcher.SetField(this, "m_pickedUpBehavior", pickedUpBehaviour, typeof(ItemData));
            _patcher.SetField(this, "m_guid", guid, typeof(DataObject));
            _patcher.SetField(this, "m_displayName", CreateLocId(displayName), typeof(EntityData));
            _patcher.SetField(this, "m_description", CreateLocId(description), typeof(EntityData));
            _patcher.SetField(this, "m_flavor", CreateLocId(flavor), typeof(EntityData));
            _patcher.SetField(this, "m_icon", CreateSprite(iconFilePath), typeof(EntityData));
            _patcher.SetField(this, "m_portrait", CreateSprite(iconFilePath), typeof(EntityData));
            _patcher.SetField(this, "m_rarity", rarity, typeof(EntityData));
            CostGroup gcost = new CostGroup()
            {
                type = CostExt.CostType.Purchase,
                costs = new List<ResourceManager.Resource>()
                {
                    new ResourceManager.Resource(GameData.Instance.GoldResource, goldCost)
                }
            };
            _patcher.SetField(this, "m_costGroups", new List<CostGroup> { gcost }, typeof(ItemData));
        }

        private LocID CreateLocId(string text)
        {
            return new LocID() { Id = -1, Text = text };
        }

        private Sprite CreateSprite(string filepath, int width = 0, int height = 0)
        {
            string workingFilePath = "";//need a relative filepath somehow
            UnityEngine.Texture2D texture = null;
            byte[] fileData;
            if (File.Exists(workingFilePath))
            {
                fileData = File.ReadAllBytes(workingFilePath);
                texture = new UnityEngine.Texture2D(width, height);
                texture.LoadRawTextureData(fileData);
            }
            else
            {
                _logger.Error("Sprite filepath NOT FOUND"+workingFilePath);
            }
            Sprite sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height),new Vector2(texture.width/2, texture.height/2));
            return sprite;
        }
    }
}