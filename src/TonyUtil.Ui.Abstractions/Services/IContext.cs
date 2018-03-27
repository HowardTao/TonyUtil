using Microsoft.AspNetCore.Mvc.Rendering;

namespace TonyUtil.Ui.Services
{
    /// <summary>
    /// UI上下文
    /// </summary>
   public interface IContext<TModel>
    {
        /// <summary>
        /// HtmlHelper
        /// </summary>
        IHtmlHelper<TModel> Helper { get; }
    }
}
