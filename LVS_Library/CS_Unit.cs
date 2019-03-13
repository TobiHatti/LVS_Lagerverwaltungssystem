﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS_Library
{
    public class Unit
    {
        private int id;
        private string si_unit;
        private string description;
        private string name;

        /// <summary>
        /// Generates a new Unit for usage in a Storage or Item
        /// </summary>
        /// <param name="SI Unit"></param>
        /// <param name="Description"></param>
        /// <param name="Name"></param>
        public Unit(string _si_unit, string _name, string _description, int _id)
        {
            SI_Unit = _si_unit;
            Description = _description;
            Name = _name;
            ID = _id;
        }




        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string SI_Unit
        {
            get
            {
                return si_unit;
            }
            set
            {
                si_unit = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Error by Weidlböck der Seidlcöck
        /// </summary>
        /// <param name="unit"></param>
        public static void Save(Unit unit)
        {
            SQL_methods.SQL_exec(string.Format(
                "INSERT INTO units " +
                "(unit_si, unit_name, unit_description)" +
                "VALUES " +
                "('{0}', '{1}', '{2}')",
                unit.SI_Unit, unit.Name, unit.Description));
        }

        public static void Remove(Unit unit)
        {
            SQL_methods.SQL_exec(string.Format(
                "DELETE FROM units " +
                "WHERE id = '{0}'",
                unit.ID));
        }

        public static List<Unit> Load()
        {
            List<Unit> units = new List<Unit>();

            string sql = "SELECT * FROM units";
            OdbcCommand cmd = new OdbcCommand(sql, DB.Connection);
            SQL_methods.Open();
            OdbcDataReader sqlReader = cmd.ExecuteReader();

            Unit loadedUnit;

            while(sqlReader.Read())
            {
                loadedUnit = new Unit((string)sqlReader["unit_si"],(string)sqlReader["unit_name"],(string)sqlReader["unit_description"],(int)sqlReader["id"]);

                units.Add(loadedUnit);
            }

            return units;
        }
    }
}
