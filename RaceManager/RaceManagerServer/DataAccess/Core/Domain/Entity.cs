using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.DataAccess.Core.Domain
{
    abstract class Entity
    {
        public int Id { get; set; }
    }
}