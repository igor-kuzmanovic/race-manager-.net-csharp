using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.Domain
{
    abstract class Entity
    {
        public int Id { get; set; }
    }
}