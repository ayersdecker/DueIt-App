using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using SQLite;
using Xamarin.Forms;
// Class : Block
// Description : Used to Block off sections of time within Schedule OBJ 
//
namespace Due_It
{
    public class Block {



        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RepeatPeriod Repeat { get; set; }
        //public List<Monad> Schedule { get; set; }

        public Block()
        {
            ID = 0;
            Name = "Not Available";
            Description = "Not Available";
            Repeat = RepeatPeriod.never;
            //Schedule = new List<Monad>();
        }
        public Block(int? iD, string name, string description, RepeatPeriod repeat /*List<Monad> schedule*/)
        {
            ID = iD;
            Name = name;
            Description = description;
            Repeat = repeat;
            //Schedule = schedule;
        }
    }
 
}
