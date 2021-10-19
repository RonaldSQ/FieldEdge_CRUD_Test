using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldEdge_CRUD_Test.Controllers
{
    public class DisplayWeather
    {
        public void RunWeather()
        {
           Weather.StartWeather();
        }
    }
}