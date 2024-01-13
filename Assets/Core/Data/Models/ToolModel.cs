﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Data.Models
{
    public class ToolModel: Tool, IModel<Tool>
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        [JsonIgnore]
        public new float Price { get; set; }
        [JsonIgnore]
        public new float Durability { get; set; }

        public Tool ToValue()
        {
            return new Tool()
            {
                NameTag = NameTag,
                Price = Price,
                Durability = Durability,
                Material = Material,
                Type = Type,
                Weight = Weight
            };
        }
    }
}