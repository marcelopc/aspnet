using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public abstract class BaseEntity
    {
		[Key]
        public Guid id { get; set; }
		private DateTime? _createAt;

		public DateTime? createAt
		{
			get { return  _createAt; }
			set {  _createAt = (value == null ? DateTime.UtcNow : value); }
		}

		private DateTime? _updateAt;

		public DateTime? updateAt
        {
			get { return _updateAt; }
			set { _updateAt = (value == null ? DateTime.UtcNow : value);  }
		}


	}
}
