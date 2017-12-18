
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
		private int _id;
		private string _title;
		private string _created;
		private string _creator;
		private string _changed;
		private string _changer;
		private int? _click=0;
		private int? _sort_id=0;
		private string _content;
		private int? _up=0;
		private int? _support=0;
		private int? _status=0;
        private string _sort_name;
        private string _summary;
        private string _carousel_url;
        private string _thumbnail_url;
        private string _description;


        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        public string carousel_url
        {
            set { _carousel_url = value; }
            get { return _carousel_url; }
        }
        public string thumbnail_url
        {
            set { _thumbnail_url = value; }
            get { return _thumbnail_url; }
        }
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }


        public string sort_name
        {
            set { _sort_name = value; }
            get { return _sort_name; }
        }
        
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string created
		{
			set{ _created=value;}
			get{return _created;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string changed
		{
			set{ _changed=value;}
			get{return _changed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string changer
		{
			set{ _changer=value;}
			get{return _changer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? click
		{
			set{ _click=value;}
			get{return _click;}
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
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? up
		{
			set{ _up=value;}
			get{return _up;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? support
		{
			set{ _support=value;}
			get{return _support;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

