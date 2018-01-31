using System.ComponentModel.DataAnnotations;

namespace TonyUtil.Validations
{
    /// <summary>
    /// 验证规则
    /// </summary>
   public interface IValidationRule
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        ValidationResult Validate();
    }
}
