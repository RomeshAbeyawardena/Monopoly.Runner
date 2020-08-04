using MonopolyRunner.Domains.Contracts;
using MonopolyRunner.Domains.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains
{
    public class PropertyGameSquare : GameSquare
    {
        public PropertyGameSquare(
            string name,
            long value,
            long houseUnitCost,
            long hotelUnitCost,
            IEnumerable<long> houseRentUnitCosts, 
            IEnumerable<long> hotelRentUnitCosts,
            GameSquareType propertyType = GameSquareType.Property)
            : base(name, null, value, propertyType)
        {
            HouseUnitCost = houseUnitCost;
            HotelUnitCost = hotelUnitCost;
            HouseRentUnitCosts = houseRentUnitCosts;
            HotelRentUnitCosts = hotelRentUnitCosts;
        }

        public int TotalHouses { get; private set; }
        public int TotalHotels { get; private set; }

        public long HouseUnitCost { get; }
        public long HotelUnitCost { get; }

        public IEnumerable<long> HouseRentUnitCosts { get; }
        public IEnumerable<long> HotelRentUnitCosts { get; }

        public long CalculateRent()
        {
            var houseRentUnitCost =  HouseRentUnitCosts.GetByIndex(TotalHouses);
            var hotelLeaseUnitCost =  HouseRentUnitCosts.GetByIndex(TotalHotels);

            return hotelLeaseUnitCost + houseRentUnitCost;
        }
    }
}
