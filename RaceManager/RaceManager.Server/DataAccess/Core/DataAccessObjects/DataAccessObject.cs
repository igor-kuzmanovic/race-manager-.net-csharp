using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Core.DataAccessObjects
{
    abstract class DataAccessObject
    {
        public int Id { get; set; }
    }
}