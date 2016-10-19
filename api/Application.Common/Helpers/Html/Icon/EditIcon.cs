using Omega.Web.Resources;

namespace Application.Common.Helpers.Html.Icon
{
    public class EditIcon:BaseIcon
    {
        public EditIcon():base(IconType.Delete)
        {
        }

        public EditIcon(string url)
            : base(ResourcesForm.EDIT,url, string.Empty,IconType.Delete)
        {
        }

        public EditIcon(string text, string url, string cssClass, string id, string onClick)
            : base(text, url, cssClass, IconType.Delete, id, onClick)
        {
        }

        public EditIcon(string text, string url, string cssClass)
            : base(text, url, cssClass, IconType.Delete)
        {
        }
    }
}
