using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biuropodrozyprojekt
{
    internal class CityClass
    {
        private int CityId;
        private string CityName;
        private int CountryId;

        public int CityIdGS { get => CityId; set => CityId = value; }
        public string CityNameGS { get => CityName; set => CityName = value; }
        public int CountryIdGS { get => CountryId; set => CountryId = value; }
    }
}
