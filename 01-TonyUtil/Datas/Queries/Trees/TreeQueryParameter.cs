﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TonyUtil.Datas.Queries.Trees
{
    /// <summary>
    /// 树型查询参数
    /// </summary>
    /// <typeparam name="TParentId">父编号类型</typeparam>
    public class TreeQueryParameter<TParentId>:QueryParameter,ITreeQueryParameter<TParentId>
    {

        /// <summary>
        /// 父编号
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// 级数
        /// </summary>
        public int? Level { get; set; }

        private string _path = string.Empty;
        /// <summary>
        /// 路径
        /// </summary>
        public string Path
        {
            get => _path == null ? string.Empty : _path.Trim();
            set => _path = value;
        }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }

        public TreeQueryParameter()
        {
            Order = "SortId";
        }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescription()
        {
            base.AddDescription();
            AddDescription("ParentId",ParentId);
            AddDescription("Level",Level);
            AddDescription("Path",Path);
            AddDescription("Enabled",Enabled);
        }
    }

    /// <summary>
    /// 树型查询参数
    /// </summary>
    public class TreeQueryParameter : TreeQueryParameter<Guid?>, ITreeQueryParameter { }
}
