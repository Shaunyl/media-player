/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects.DataClasses;

namespace Shauni.Database
{
    public sealed class DatabaseSession
    {
        public T Query<T>() where T : EntityObject, ITraceable<int>, new()
        {
            return new T { };
        }
    }

    public class DatabaseArguments
    {
        public String[] Artist { get; set; }
    }
}
*/