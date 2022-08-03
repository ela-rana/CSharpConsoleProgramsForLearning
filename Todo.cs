using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListUsingEnumClassAndArrayList
{
    enum Status
    {
        NotStarted=1,
        InProgress,
        OnHold,
        Completed,
        Deleted
    }   //Here you can also type }; instead of } because semicolon is optional at the end
        //of a class, namespace, or enum block
        //But if its a method it must not have ; after }
        //and if it is a regular code statement it must have ; after }

    internal class Todo
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public Status Status { get; set; }
    }
}
