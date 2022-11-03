using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarotraumaContentParser;

namespace BarotraumaSaveEditorGui.Services.BarotraumaContentService
{
    internal interface IBarotraumaContentService
    {
        public T GetParsedBarotraumaContent<T>() where T : IBarotraumaContent;

        public void Initialize(params IBarotraumaContent[] content);
    }
}
