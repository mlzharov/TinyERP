using System.Collections.Generic;

namespace Application.Common.Helpers.Html
{
    public class CommandPanel
    {
        public CommandPanel()
        {
            this.Items= new List<CommandPanelItem>();
        }
        public string Title { get; set; }
        public IList<CommandPanelItem> Items { get; set; }
    }
}
