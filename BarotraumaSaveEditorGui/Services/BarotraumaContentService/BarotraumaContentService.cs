using BarotraumaContentParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarotraumaSaveEditorGui.Services.BarotraumaContentService
{
    internal class BarotraumaContentService : IBarotraumaContentService
    {
        private bool _initialized;
        private HashSet<IBarotraumaContent> _content = new HashSet<IBarotraumaContent>();

        public void Initialize(params IBarotraumaContent[] content)
        {
            _initialized = true;
            foreach(var contentPart in content)
            {
                _content.Add(contentPart);
            }
        }

        public T GetParsedBarotraumaContent<T>() where T : IBarotraumaContent
        {
            if(!_initialized)
            {
                throw new InvalidOperationException("Initialize this service with the parsed content first!");
            }

            if(!_content.Any(c => c.GetType() == typeof(T)))
            {
                throw new InvalidOperationException("Content file not found!");
            }
            return (T) _content.Single(c => c.GetType() == typeof(T));
        }
    }
}
