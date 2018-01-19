using System.Collections.Generic;
using System.Text;
using TonyUtil.Validations;

namespace TonyUtil.Domains
{
    /// <summary>
    /// 领域层顶级基类
    /// </summary>
   public class DomainBase<T>:IDomainObject,ICompareChange<T> where T:IDomainObject
    {

        #region 字段
        /// <summary>
        /// 描述
        /// </summary>
        private StringBuilder _description;
        /// <summary>
        /// 验证规则集合
        /// </summary>
        private readonly List<IValidationRule> _rules;
        /// <summary>
        /// 验证处理器
        /// </summary>
        private IValidationHandler _handler;
        /// <summary>
        /// 变更值集合
        /// </summary>
        private ChangeValueCollection _changeValues;
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化领域层顶级基类
        /// </summary>
        protected DomainBase()
        {
            _rules = new List<IValidationRule>();
            _handler = new ThrowHandler();
        }
        #endregion

        #region SetValidationHandler（设置验证处理器）
        /// <summary>
        /// 设置验证处理器
        /// </summary>
        /// <param name="handler"></param>
        public void SetValidationHandler(IValidationHandler handler)
        {
            if (handler == null) return;
            _handler = handler;
        }
        #endregion

        #region AddValidationRules（添加验证规则列表）
        /// <summary>
        /// 添加验证规则列表
        /// </summary>
        /// <param name="rules">验证规则列表</param>
        public void AddValidationRules(IEnumerable<IValidationRule> rules)
        {
            if (rules == null) return;
            foreach (var rule in rules)
            {
                AddValidationRule(rule);
            }
        } 
        #endregion

        #region AddValidationRule（添加验证规则）
        /// <summary>
        /// 添加验证规则
        /// </summary>
        /// <param name="rule">验证规则</param>
        public void AddValidationRule(IValidationRule rule)
        {
            if (rule == null) return;
            _rules.Add(rule);
        }
        #endregion

        #region Validate（验证）
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public ValidationResultCollection Validate()
        {
            var result = GetValidationResults();
            HandleValidationResults(result);
            return result;
        }

        /// <summary>
        /// 获取验证结果
        /// </summary>
        /// <returns></returns>
        private ValidationResultCollection GetValidationResults()
        {
            var result = DataAnnotationValidation.Validate(this);
            Validate(result);
            foreach (var rule in _rules)
            {
                result.Add(rule.Validate());
            }
            return result;
        }

        /// <summary>
        /// 验证并添加到验证结果集合
        /// </summary>
        /// <param name="results">验证结果集合</param>
        protected virtual void Validate(ValidationResultCollection results) { }

        /// <summary>
        ///处理 验证结果
        /// </summary>
        /// <param name="results">验证结果集合</param>
        private void HandleValidationResults(ValidationResultCollection results)
        {
            if(results.IsValid) return;
            _handler.Handle(results);
        }
        #endregion

        #region GetChanges（获取变更属性）
        public ChangeValueCollection GetChanges(T other)
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}
