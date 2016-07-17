using System.Collections.Generic;

namespace Siver.Jeff.ObjectPrinter.Tests.Objects
{
    public class ObjectContainer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<ObjectDetail> Children { get; set; }

        public static ObjectContainer Builder()
        {
            var parent = new ObjectContainer {Id = 1, Description = "parent object"};
            var child1 = new ObjectDetail {Id = 2, Description = "child 1", Parent = parent};
            var child2 = new ObjectDetail { Id = 3, Description = "child 2", Parent = parent};
            parent.Children = new[] {child1, child2};
            return parent;
        }
    }

    public class ObjectDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ObjectContainer Parent { get; set; }
    }
}
