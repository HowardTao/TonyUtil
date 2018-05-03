using System;
using System.Threading.Tasks;
using TonyUtil.Domains;
using TonyUtil.Logs.Extensions;

namespace TonyUtil.Applications
{
    /// <summary>
    /// 增删改查服务 -- Save
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TCreateRequest"></typeparam>
    /// <typeparam name="TUpdateRequest"></typeparam>
    /// <typeparam name="TQueryParameter"></typeparam>
    /// <typeparam name="TKey"></typeparam>
   public abstract partial class CrudServiceBase<TEntity,TDto,TRequest,TCreateRequest,TUpdateRequest,TQueryParameter,TKey>
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns></returns>
        public string Create(TCreateRequest request)
        {
            if(request==null) throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromCreateRequest(request);
            if(entity==null) throw new ArgumentNullException(nameof(entity));
            Create(entity);
            return entity.Id.ToString();
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        protected void Create(TEntity entity)
        {
            CreateBefore(entity);
            entity.Init();
            _repository.Add(entity);
            CreateAfter(entity);
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreateBefore(TEntity entity){}

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreateAfter(TEntity entity){AddLog(entity);}

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns></returns>
        public async Task<string> CreateAsync(TCreateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromCreateRequest(request);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await CreateAsync(entity);
            return entity.Id.ToString();
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected async Task CreateAsync(TEntity entity)
        {
            CreateBefore(entity);
            entity.Init();
            await _repository.AddAsync(entity);
            CreateAfter(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public void Update(TUpdateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromUpdateRequest(request);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Update(entity);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>

        protected void Update(TEntity entity)
        {
            var oldEntity = _repository.Find(entity.Id);
            if(oldEntity==null) throw new ArgumentNullException(nameof(oldEntity));
            var changes = oldEntity.GetChanges(entity);
            UpdateBefore(entity);
            _repository.Update(entity);
            UpdateAfter(entity,changes);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        public async Task UpdateAsync(TUpdateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromUpdateRequest(request);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await UpdateAsync(entity);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        protected async Task UpdateAsync(TEntity entity)
        {
            var oldEntity = await _repository.FindAsync(entity.Id);
            if (oldEntity == null) throw new ArgumentNullException(nameof(oldEntity));
            var changes = oldEntity.GetChanges(entity);
            UpdateBefore(entity);
            await _repository.UpdateAsync(entity);
            UpdateAfter(entity,changes);
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void UpdateBefore(TEntity entity) { }

        /// <summary>
        /// 修改后操作
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="changeValues"></param>
        protected virtual void UpdateAfter(TEntity entity,ChangeValueCollection changeValues)
        {
            Log.BusinessId(entity.Id.SafeString()).Content(changeValues.SafeString());
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request"></param>
        public void Save(TRequest request)
        {
            if(request==null) throw new ArgumentNullException(nameof(request));
            SaveBefore(request);
            var entity = ToEntity(request);
            if(entity==null) throw new ArgumentNullException(nameof(entity));
            if (IsNew(request, entity))
            {
                Create(entity);
                request.Id = entity.Id.ToString();
            }
            else
            {
                Update(entity);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request"></param>
        public async Task SaveAsync(TRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            SaveBefore(request);
            var entity = ToEntity(request);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (IsNew(request, entity))
            {
               await CreateAsync(entity);
                request.Id = entity.Id.ToString();
            }
            else
            {
               await UpdateAsync(entity);
            }
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="request"></param>
        protected virtual void SaveBefore(TRequest request) { }

        /// <summary>
        /// 是否创建
        /// </summary>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool IsNew(TRequest request, TEntity entity)
        {
            return string.IsNullOrWhiteSpace(request.Id) || entity.Id.Equals(default(TKey));
        }

        /// <summary>
        /// 保存后操作
        /// </summary>
        protected virtual void SaveAfter()
        {
            WriteLog($"保存{EntityDescription}成功");
        }

        /// <summary>
        /// 提交后操作 - 该方法由工作单元拦截器调用
        /// </summary>
        public void CommitAfter()
        {
            SaveAfter();
        }
    }
}
