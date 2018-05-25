using TonyUtil.Ui.Operations.Form;
using TonyUtil.Ui.Operations.Form.Validations;

namespace TonyUtil.Ui.Components {
    /// <summary>
    /// 文本框
    /// </summary>
    public interface ITextBox : IFormControl, IMinLength, IMaxLength, IReadOnly {
    }
}
