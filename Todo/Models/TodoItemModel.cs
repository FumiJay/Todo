using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class TodoItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int TodoId { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
