﻿using MonopolyRunner.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains.Constants
{
    public static class GameSquares
    {
        public const ushort PassGo = 0;
        public const ushort GoToJail = 29;
        public const ushort FreeParking = 39;
        public const ushort SuperTax = 47;
        
        public static IGameSquare Create(
            GameSquareType type,
            string name = default,
            string description = default,
            long value = default,
            long houseUnitCost = default,
            long hotelUnitCost = default,
            long[] houseRentUnitCosts = default, 
            long[] hotelRentUnitCosts = default)
        {
           
            var gameSquare = type == GameSquareType.Property 
                || type == GameSquareType.RailwayStation 
                || type == GameSquareType.Utility
                ? new PropertyGameSquare(
                    name, 
                    value, 
                    houseUnitCost, 
                    hotelUnitCost, 
                    houseRentUnitCosts, 
                    hotelRentUnitCosts, 
                    type) 
                : new GameSquare(name, description, value, type);
            return gameSquare;
        }

        public static IEnumerable<IGameSquare> TraditionalGame => new [] { 
            Create(GameSquareType.PassGo), 
            Create(GameSquareType.Property, name: "Old Kent Road",
                value: 60, 
                houseUnitCost: 20, 
                hotelUnitCost: 40, 
                houseRentUnitCosts: new long [] {34, 40, 80, 120, 250},
                hotelRentUnitCosts: new long [] { 0, 80, 140, 350 }),
            Create(GameSquareType.CommunityChest),
            Create(GameSquareType.Property, name: "Whitechapel Road", 
                value: 60,
                houseUnitCost: 20, 
                hotelUnitCost: 40, 
                houseRentUnitCosts: new long [] {34, 40, 80, 120, 250},
                hotelRentUnitCosts: new long [] { 0, 80, 140, 350 }),
            Create(GameSquareType.IncomeTax, name: "Income Tax", value: 200),
            Create(GameSquareType.RailwayStation, name: "Kings Cross Station", 
                value: 200,
                houseUnitCost: 10, 
                hotelUnitCost: 30, 
                houseRentUnitCosts: new long [] {10, 20, 80, 100, 250},
                hotelRentUnitCosts: new long [] { 0, 80, 140, 350 }),
            Create(GameSquareType.Property, name: "The Angel, Islington", 
                value: 100,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.Chance),
            Create(GameSquareType.Property, name: "Euston Road", 
                value: 100,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.Property, name: "Pentonville Road", 
                value: 100,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.JustVisitingJail),
            Create(GameSquareType.Property, name: "Pall Mall", 
                value: 140,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.Utility, name: "Electric Company", 
                value: 150,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.Property, name: "WhiteHall", 
                value: 140,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.Property, name: "Northumberland Avenue", 
                value: 160,
                houseUnitCost: 5, 
                hotelUnitCost: 10, 
                houseRentUnitCosts: new long [] {8, 10, 40, 80, 140},
                hotelRentUnitCosts: new long [] { 0, 50, 150, 250 }),
            Create(GameSquareType.RailwayStation, name: "Marylebone Station", value: 200),
            Create(GameSquareType.Property, name: "Bow Street", value: 180),
            Create(GameSquareType.CommunityChest),
            Create(GameSquareType.Property, name: "Marlborough Street", value: 180),
            Create(GameSquareType.Property, name: "Vine Street", value: 200),
            Create(GameSquareType.FreeParking),
            Create(GameSquareType.Property, name: "Strand", value: 220),
            Create(GameSquareType.Chance),
            Create(GameSquareType.Property, name: "Fleet Street", value: 220),
            Create(GameSquareType.Property, name: "Trafalgar Square", value: 240),
            Create(GameSquareType.RailwayStation, name: "Fenchurch Street Station", value: 200),
            Create(GameSquareType.Property, name: "Leicester Square", value: 260),
            Create(GameSquareType.Property, name: "Coventry Street", value: 260),
            Create(GameSquareType.Utility, name: "Water Works", value: 150),
            Create(GameSquareType.Property, name: "Piccadilly", value: 280),
            Create(GameSquareType.GoToJail),
            Create(GameSquareType.Property, name: "Regent Street", value: 300),
            Create(GameSquareType.Property, name: "Oxford Street", value: 300),
            Create(GameSquareType.CommunityChest),
            Create(GameSquareType.Property, name: "Bond Street", value: 320),
            Create(GameSquareType.RailwayStation, name: "Liverpool Street Station", value: 200),
            Create(GameSquareType.Chance),
            Create(GameSquareType.Property, name: "Park Lane", value: 350),
            Create(GameSquareType.IncomeTax, name: "Super Tax", value: 300),
            Create(GameSquareType.Property, name: "Mayfair", value: 400),
        };
    }
}
