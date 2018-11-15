using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjects
{
    public class FooCollection
    {
        public List<Foo> Collection { get; set; }

        public FooCollection()
        {
            Collection = new List<Foo>();

            foreach (ColorType color in Enum.GetValues(typeof(ColorType)))
            {
                foreach(FlavorType flavor in Enum.GetValues(typeof(FlavorType)))
                {
                    Collection.Add(new Foo(color, flavor));
                }
            }
        }

        public Foo GetFooByFlavorAndColorLoop(ColorType color, FlavorType flavor)
        {
            foreach (Foo foo in Collection)
            {
                if (foo.Flavor == flavor && foo.Color == color)
                    return foo;
            }

            return new Foo(color, flavor);
        }

        public Foo GetFooByFlavorAndColorLinq(ColorType color, FlavorType flavor)
        {
            return Collection.First(x => x.Flavor == flavor && x.Color == color);
        }
    }
}
