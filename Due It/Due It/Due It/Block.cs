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

        public Block()
        {
            ID = 0;
        }
        public Block(int? iD)
        {
            ID = iD;
        }
    }
 
}
