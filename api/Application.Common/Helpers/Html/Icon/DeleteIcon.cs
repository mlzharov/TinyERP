
namespace Application.Common.Helpers.Html.Icon
{
    public class DeleteIcon:BaseIcon
    {
        public DeleteIcon():base(IconType.Delete)
        {
        
        }

        public DeleteIcon(string url)
            : base(ResourcesForm.DELETE,url,string.Empty,IconType.Delete)
        {
        }

        public DeleteIcon(string text, string url, string cssClass, string id, string onClick):base(text, url, cssClass, IconType.Delete, id, onClick)
        {
        }
        public DeleteIcon(string text, string url, string cssClass)
            : base(text, url, cssClass, IconType.Delete)
        {
        }
    }
}
