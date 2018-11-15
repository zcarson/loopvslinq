using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class Foo
    {
        public ColorType Color { get; set; }
        public FlavorType Flavor { get; set; }

        public Foo(ColorType colorType, FlavorType flavorType)
        {
            Color = colorType;
            Flavor = flavorType;
        }
    }
}
