using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public interface IProductSearch
    {
        void setAvailability(string[] availabilities);

        void setAgeRange(string[] ageRanges);

        void setProductFlags(string[] productFlags);

        void setDeptName(string[] deptNames);

        void setPieceRange(string[] pieceRanges);

        void setPriceRange(string[] priceRanges);

        void setRateRange(string[] rateRanges);

        void setSearchQuery(string query);

        Dictionary<string, string> toParameterMap();
    }
}
