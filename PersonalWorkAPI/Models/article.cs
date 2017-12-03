
using System;
namespace PersonalWorkAPI.Model
{
	/// <summary>
	/// article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class article
	{
		public article()
		{}
		#region Model
		private int _article_id;
		private string _article_title;
		private string _article_created;
		private string _article_creator;
		private string _article_changed;
		private string _article_changer;
		private int? _article_click=0;
		private int? _sort_id=0;
		private string _article_content;
		private int? _article_up=0;
		private int? _article_support=0;
		private int? _article_status=0;
        private string _sort_name;

        public string sort_name
        {
            set { _sort_name = value; }
            get { return _sort_name; }
        }
        
		/// <summary>
		/// auto_increment
		/// </summary>
		public int article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_title
		{
			set{ _article_title=value;}
			get{return _article_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_created
		{
			set{ _article_created=value;}
			get{return _article_created;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_creator
		{
			set{ _article_creator=value;}
			get{return _article_creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_changed
		{
			set{ _article_changed=value;}
			get{return _article_changed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_changer
		{
			set{ _article_changer=value;}
			get{return _article_changer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? article_click
		{
			set{ _article_click=value;}
			get{return _article_click;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_content
		{
			set{ _article_content=value;}
			get{return _article_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? article_up
		{
			set{ _article_up=value;}
			get{return _article_up;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? article_support
		{
			set{ _article_support=value;}
			get{return _article_support;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? article_status
		{
			set{ _article_status=value;}
			get{return _article_status;}
		}
		#endregion Model

	}
}

