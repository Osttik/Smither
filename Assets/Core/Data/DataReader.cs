using Assets.Core.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Assets.Core.Data
{
    public class DataReader
    {
        public Dictionary<string, Material> Materials { get; set; } = new Dictionary<string, Material>();
        public Dictionary<string, OreMix> OreMixes { get; set; } = new Dictionary<string, OreMix>();
        public Dictionary<string, Ore> Ores { get; set; } = new Dictionary<string, Ore>();
        public Dictionary<string, Tool> Tools { get; set; } = new Dictionary<string, Tool>();

        public void ReadOres() 
        {
            
            var materials = new List<MaterialModel>() {
                new() { NameTag="iron_material", Id = Guid.NewGuid(), Price = 10, Durability = 50 },
                new() { NameTag="rock_material", Id = Guid.NewGuid(), Price = 0.1f, Durability = 1  },
                new() { NameTag="coal_material", Id = Guid.NewGuid(), Price = 3, Durability = 1 },
                new() { NameTag="supfidium_material", Id = Guid.NewGuid(), Price = 50, Durability = 10 },
                new() { NameTag="titan_material", Id = Guid.NewGuid(), Price = 30, Durability = 200 },
                new() { NameTag="gold_material", Id = Guid.NewGuid(), Price = 40, Durability = 10 },
                new() { NameTag="copper_material", Id = Guid.NewGuid(), Price = 15, Durability = 20 },
                new() { NameTag="geneve_material", Id = Guid.NewGuid(), Price = 100, Durability = 250 }
            };
            Write("materials.json", JsonConvert.SerializeObject(materials));
            var ores = new List<OreModel>()
            {
                new() { Id = Guid.NewGuid(), NameTag = "iron_ore", Rarity = 5, Weight = 6, MaterialId = materials.First(m => m.NameTag == "iron_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "rock_ore", Rarity = 1, Weight = 10, MaterialId = materials.First(m => m.NameTag == "rock_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "coal_ore", Rarity = 3, Weight = 4, MaterialId = materials.First(m => m.NameTag == "coal_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "supfidium_ore", Rarity = 20, Weight = 2, MaterialId = materials.First(m => m.NameTag == "supfidium_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "titan_ore", Rarity = 50, Weight = 2, MaterialId = materials.First(m => m.NameTag == "titan_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "gold_ore", Rarity = 30, Weight = 3, MaterialId = materials.First(m => m.NameTag == "gold_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "copper_ore", Rarity = 10, Weight = 7, MaterialId = materials.First(m => m.NameTag == "copper_material").Id },
                new() { Id = Guid.NewGuid(), NameTag = "geneve_ore", Rarity = 75, Weight = 0.2f, MaterialId = materials.First(m => m.NameTag == "geneve_material").Id },
            };
            Write("ores.json", JsonConvert.SerializeObject(ores));
            var mixes = new List<OreMixModel>()
            {
                new() { Id = Guid.NewGuid(), NameTag = "siple_mix", RequiredToolType = "pickaxe", OresIds = ores.Where(o => new List<string>() { "iron_ore", "rock_ore", "coal_ore", "copper_ore", "geneve_ore" }.Contains(o.NameTag)).Select(x => x.Id).ToList() },
                new() { Id = Guid.NewGuid(), NameTag = "middle_mix", RequiredToolType = "pickaxe", OresIds = ores.Where(o => new List<string>() { "rock_ore", "coal_ore", "gold_ore", "geneve_ore" }.Contains(o.NameTag)).Select(x => x.Id).ToList() },
                new() { Id = Guid.NewGuid(), NameTag = "rare_mix", RequiredToolType = "pickaxe", OresIds = ores.Where(o => new List<string>() { "supfidium_ore", "rock_ore", "titan_ore", "gold_ore", "geneve_ore" }.Contains(o.NameTag)).Select(x => x.Id).ToList() },
                new() { Id = Guid.NewGuid(), NameTag = "pile_mix", RequiredToolType = "shovel", OresIds = ores.Where(o => new List<string>() { "rock_ore", "coal_ore", "copper_ore" }.Contains(o.NameTag)).Select(x => x.Id).ToList() },
            };
            Write("oreMixes.json", JsonConvert.SerializeObject(mixes));
            var tools = new List<ToolModel>()
            {
                new() { Id = Guid.NewGuid(), Type = "pickaxe", Weight = 5, MaterialId = materials.First(m => m.NameTag == "iron_material").Id, NameTag = "iron_pickaxe" },
                new() { Id = Guid.NewGuid(), Type = "shovel", Weight = 3, MaterialId = materials.First(m => m.NameTag == "iron_material").Id, NameTag = "iron_shovel" }
            };
            Write("tools.json", JsonConvert.SerializeObject(mixes));
            

            var deserialisedMaterials = JsonConvert.DeserializeObject<List<MaterialModel>>(Read("materials.json"));
            Materials = deserialisedMaterials.Select(m => ById(m.Id, deserialisedMaterials)).ToDictionary(m => m.NameTag);

            var deserialisedOres = JsonConvert.DeserializeObject<List<OreModel>>(Read("ores.json"));
            Ores = deserialisedOres.Select(m => ById(m.Id, deserialisedOres, deserialisedMaterials)).ToDictionary(m => m.NameTag);

            var deserialisedOresMixes = JsonConvert.DeserializeObject<List<OreMixModel>>(Read("oreMixes.json"));
            OreMixes = deserialisedOresMixes.Select(m => ById(m.Id, deserialisedOresMixes, deserialisedOres, deserialisedMaterials)).ToDictionary(m => m.NameTag);

            var deserialisedTools = JsonConvert.DeserializeObject<List<ToolModel>>(Read("tools.json"));
            Tools = deserialisedTools.Select(m => ById(m.Id, deserialisedTools, deserialisedMaterials)).ToDictionary(m => m.NameTag);
        }

        public Material ById(Guid id, List<MaterialModel> models)
        {
            return models.FirstOrDefault(x => x.Id == id).ToValue();
        }

        public Ore ById(Guid id, List<OreModel> models, List<MaterialModel> materialsModels)
        {
            var ore = models.FirstOrDefault(x => x.Id == id);
            if (ore == null) return ore;

            ore.Material = ById(ore.MaterialId, materialsModels);

            return ore.ToValue();
        }

        public OreMix ById(Guid id, List<OreMixModel> models, List<OreModel> oreModels, List<MaterialModel> materialsModels)
        {
            var oreMix = models.FirstOrDefault(x => x.Id == id);
            if (oreMix == null) return oreMix;

            oreMix.MixedOres = new List<Ore>();

            foreach (var oreId in oreMix.OresIds) 
            {
                oreMix.MixedOres.Add(ById(oreId, oreModels, materialsModels));
            }

            return oreMix.ToValue();
        }

        public Tool ById(Guid id, List<ToolModel> models, List<MaterialModel> materialsModels)
        {
            var tool = models.FirstOrDefault(x => x.Id == id);
            if (tool == null) return tool;

            tool.Material = ById(tool.MaterialId, materialsModels);

            return tool.ToValue();
        }

        public string Read(string path)
        {
            return File.ReadAllText("Assets/Resources/" + path);
        }

        public void Write(string path, string text)
        {
            File.WriteAllText("Assets/Resources/" + path, text);
        }
    }
}
