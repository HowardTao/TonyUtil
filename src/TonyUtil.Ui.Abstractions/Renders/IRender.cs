using System.IO;
using Microsoft.AspNetCore.Html;

namespace TonyUtil.Ui.Renders
{
    /// <summary>
    /// 渲染器
    /// </summary>
   public interface IRender:IHtmlContent
    {
        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer"></param>
        void RenderStartTag(TextWriter writer);
        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer"></param>
        void RenderEndTag(TextWriter writer);
    }
}
