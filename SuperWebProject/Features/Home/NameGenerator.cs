using System;
using System.Linq;

namespace netcoretalk.Features.Home
{
    public class NameGenerator
    {
        private readonly string[] names = new []{
            "Joe",
            "Rick",
            "Morty",
            "Summer",
            "Jerry"
        };
        
        public string GetName()
        {
            return names.OrderBy(n => Guid.NewGuid()).FirstOrDefault();
        }
    }
}